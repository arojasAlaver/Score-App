using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Novell.Directory.Ldap;
using Novell.Directory.Ldap.Controls;
using scoreapp.data.Data_Objects;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Classes
{
    public class AuthenticationClass : IAuthentication
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        public AuthenticationClass(Context db, IDataProtectionProvider provider)
        {
            _db = db;
            _allSettings = _db.Settings.ToList();
            _provider = provider;
        }
        [SupportedOSPlatform("windows")]
        public User Login(string Username, string Password)
        {
            IDataProtector _protector = _provider.CreateProtector(Config.private_key);
            
            try
            {
                User _user = _db.Users.Include(x => x.Role).ThenInclude(x => x.Permissions).ThenInclude(x => x.Permission)
                    .SingleOrDefault(x => x.Username.Trim().ToLower() == Username.Trim().ToLower());

                if (_user != null)
                {
                    if (_user.IsLocal)
                    {
                        var password = new PasswordHasher<User>();
                        var Result = password.VerifyHashedPassword(_user, _user.Password, Password);

                        if (Result == PasswordVerificationResult.Success)
                            return _user;
                        throw new Exception("La contraseña ingresada no corresponde a este usuario.");
                    }
                    else
                    {
                        using (DirectoryEntry entry = new DirectoryEntry("LDAP://alaver.local/dc=alaver,dc=local", 
                            $@"{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Domain").Value)}\{Username}"
                            , Password, AuthenticationTypes.ServerBind))
                        {

                            DirectorySearcher search = new DirectorySearcher(entry);
                            //search.PropertiesToLoad.Add("uid");
                            search.Filter = $"(&(objectCategory=person)(objectClass=user)(mail={Username}@alaver.com.do))";

                            foreach (SearchResult result in search.FindAll())
                            {
                                if (result != null)
                                {
                                    //DirectoryEntry de = result.GetDirectoryEntry();
                                    //string description = de.Properties["description"].Value.ToString();
                                    //string displayName = de.Properties["displayName"].Value.ToString();
                                    //string name = de.Properties["name"].Value.ToString();
                                    //string mail = de.Properties["mail"].Value.ToString();


                                }
                            }
                        }
                    }
                    
                    return _user;
                }
                else
                {
                    throw new Exception("El usuario que está intentando ingresar no esta autorizado. Comuniquese con seguridad.");
                }
                
            }
            catch (DirectoryServicesCOMException ex)
            {

                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
