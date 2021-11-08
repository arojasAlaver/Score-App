using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using scoreapp.data;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace scoreapp.Api
{
    [Route("api/4039b714-caeb-4c65-9eb9-621ac530813e")]
    [ApiController]
    public class UsersManagmentController : ControllerBase
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        private readonly IWebHostEnvironment _env;
        public UsersManagmentController(Context db, IDataProtectionProvider provider, IWebHostEnvironment env)
        {
            _db = db;
            _allSettings = _db.Settings.ToList();
            _provider = provider;
            _env = env;
        }

        [SupportedOSPlatform("windows")]
        [HttpGet]
        [Authorize(Policy = "Users")]
        [Route("Get")]
        [AjaxOnly]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<User> Users = new List<User>();
                await Task.Run(new Action(() =>
                {

                    IDataProtector _protector = _provider.CreateProtector(Config.private_key);
                    using (DirectoryEntry entry = new DirectoryEntry("LDAP://alaver.local/dc=alaver,dc=local",
                        $@"ALAVER\{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Ldap.Username").Value)}",
                        $"{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Ldap.Password").Value)}", AuthenticationTypes.ServerBind))
                    {

                        DirectorySearcher search = new DirectorySearcher(entry);
                        search.PropertiesToLoad.Add("displayName");
                        search.PropertiesToLoad.Add("mail");
                        search.PropertiesToLoad.Add("description");
                        search.PropertiesToLoad.Add("name");
                        search.PropertiesToLoad.Add("mailNickname");
                        search.PropertiesToLoad.Add("distinguishedName");
                        search.Filter = $"(&(objectCategory=User)(objectClass=person))";


                        foreach (SearchResult result in search.FindAll())
                        {

                            if (result != null)
                            {

                                if (!result.Properties["distinguishedName"][0].ToString().ToLower().Contains("desvinculado") &&
                                    result.Properties["distinguishedName"][0].ToString().ToLower().Contains("alvp") && result.Properties.Count == 7)
                                {
                                    var user = _db.Users.SingleOrDefault(x => x.Username == result.Properties["mailNickname"][0].ToString());

                                    var newUser = new User
                                    {

                                        DisplayName = result.Properties["displayName"].Count > 0 ? result.Properties["displayName"][0].ToString() : "Nulo",
                                        Mail = result.Properties["mail"].Count > 0 ? result.Properties["mail"][0].ToString() : "Nulo",
                                        IsLocal = false,
                                        Username = result.Properties["mailNickname"].Count > 0 ? result.Properties["mailNickname"][0].ToString() : "Nulo",
                                        EmployerCode = result.Properties["description"].Count > 0 ? Convert.ToInt32(result.Properties["description"][0].ToString())
                                        : 0,
                                        Id = user != null ? user.Id : 0,
                                        Exists = user != null ? true : false

                                    };
                                    if (System.IO.File.Exists(Path.GetFullPath(Path.Combine(_env.WebRootPath, "images", $"{newUser.EmployerCode}.jpg"))))
                                        newUser.Picture = $"images/{ newUser.EmployerCode}.jpg";
                                    else
                                        newUser.Picture = "images/Add User-rafiki.svg";
                                    Users.Add(newUser);
                                }

                                //string description = de.Properties["description"].Value.ToString();


                            }
                        }
                    }


                }));
                return Ok(Users);


            }
            catch (DirectoryServicesCOMException ex)
            {

                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Policy = "UsersCreate")]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]User User)
        {
            foreach (var item in _db.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted))
            {
                item.State = EntityState.Detached;
            }
            var data = _db.Users.AsNoTracking().SingleOrDefault(x => x.EmployerCode == User.EmployerCode);
            if (data !=null)
            {
                _db.Users.Remove(data);
                
            }
            else
            {
                User.TypeUser = model.enums.Type_User.Oficial;
                _db.Users.Add(User);
                
            }

            if (Convert.ToBoolean(await _db.SaveChangesAsync()))
            {
                User.Exists = !User.Exists;
                if (!User.Exists)
                    User.Id = 0;
                
            }
            
            return Ok(User);
        }

        [HttpPost]
        [Authorize(Policy = "RolesCreate")]
        [Route("PostRole")]
        public async Task<IActionResult> PostRole([FromBody]Role _role)
        {
            _role.Id = Guid.NewGuid();
            _db.Roles.Add(_role);
            await _db.SaveChangesAsync();
            return Ok(_role);
        }

        [HttpPost]
        [Authorize(Policy = "RolesEdit")]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole([FromBody] Role _role)
        {
            _db.Roles.Update(_role);
            await _db.SaveChangesAsync();
            return Ok(_role);
        }
    }
}
public static class HttpRequestExtensions
{
    private const string RequestedWithHeader = "X-Requested-With";
    private const string XmlHttpRequest = "XMLHttpRequest";

    public static bool IsAjaxRequest(this HttpRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException("request");
        }
        else if (request.Headers.ContainsKey("Postman-Token"))
        {
            return false;
        }

        else if (request.Headers != null)
        {
            return request.Headers[RequestedWithHeader] == XmlHttpRequest;
        }

        return false;
    }
}

public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
{
    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        
        return routeContext.HttpContext.Request.IsAjaxRequest();
    }
}