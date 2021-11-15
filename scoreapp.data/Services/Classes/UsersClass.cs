using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.pivots;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Classes
{
    public class UsersClass : IUsers
    {
        private readonly Context _db;
        private readonly IWebHostEnvironment _env;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        public UsersClass(Context db, IWebHostEnvironment env, IDataProtectionProvider provider)
        {
            _db = db;
            _env = env;
            _provider = provider;
            _allSettings = _db.Settings.ToList();
        }
        [SupportedOSPlatform("windows")]
        public List<User> Index()
        {
            try
            {
                IDataProtector _protector = _provider.CreateProtector(Config.private_key);
                
                List <User> Users = new List<User>();
                using (DirectoryEntry entry = new DirectoryEntry($"LDAP://{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "	Ldap.Host").Value)}/{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Ldap.DN").Value)}", 
                    $@"{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Ldap.Username").Value)}", 
                    $"{_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Ldap.Password").Value)}", 
                    AuthenticationTypes.ServerBind))
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
                                result.Properties["distinguishedName"][0].ToString().ToLower().Contains("alvp") && result.Properties.Count ==7)
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
                                    Id = user != null ? user.EmployerCode : 0,
                                    Exists = user != null ? true : false

                                };
                                if (File.Exists(Path.GetFullPath(Path.Combine(_env.WebRootPath, "images", $"{newUser.EmployerCode}.jpg"))))
                                    newUser.Picture = $"images/{ newUser.EmployerCode}.jpg";
                                else
                                    newUser.Picture = "images/Add User-rafiki.svg";
                                Users.Add(newUser) ;
                            }
                            
                            //string description = de.Properties["description"].Value.ToString();


                        }
                    }
                }

                return Users;
                

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

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                return ms.ToArray();
            }
        }

        public User Get(int Id)
        {
            return _db.Users.Include(x => x.Role).SingleOrDefault(x => x.Id == Id);
        }

        public List<Role> Get()
        {
            IDataProtector _protector = _provider.CreateProtector(Role.PrivateKey);
            
            return _db.Roles.Include(x => x.Permissions).Select(x => new Role 
            {
                Id = x.Id,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                EncryptedId = _protector.Protect(x.Id.ToString()),
                HasPermissionAssigned = x.Permissions.Count>0 ?true: false

            }).ToList();
        }

        public void Post(User User, Guid RoleId)
        {
            User = _db.Users.AsNoTracking().SingleOrDefault(x => x.Id == User.Id);
            User.Role = _db.Roles.AsNoTracking().SingleOrDefault(x => x.Id == RoleId);
            _db.Users.Update(User);
            _db.SaveChangesAsync();
        }

        public List<Permission> GetAllPermissions()
        {
            IDataProtector _protector = _provider.CreateProtector(Permission.PrivateKey);

            return _db.Permissions.Select(x => new Permission 
            {
                Id = x.Id,
                Description =x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                EncryptedId = _protector.Protect(x.Id.ToString())
            }).OrderBy(x => x.Description).ToList();
        }

        public Role Get(Guid RoleId)
        {
            IDataProtector _protector = _provider.CreateProtector(Permission.PrivateKey);

            return _db.Roles.Include(x => x.Permissions).ThenInclude(y => y.Permission).SingleOrDefault(x => x.Id == RoleId);

        }

        public void Post(Role Role, List<Permission> Permissions)
        {
            Role = _db.Roles.AsNoTracking().Include(x => x.Permissions).ThenInclude(x => x.Permission).SingleOrDefault(x => x.Id == Role.Id);
            foreach (Permission item in Permissions)
            {
                if (item.IsSelected)
                {
                    if (Role.Permissions != null)
                    {
                        if (!Role.Permissions.Any(x => x.Permission.Id == item.Id))
                        {
                            _db.PermissionRole.Add(new model.database.pivots.PermissionRole
                            {
                                PermissionId = item.Id,
                                RoleId = Role.Id
                            });
                        }
                    }
                        
                }
                else
                {
                    if (Role.Permissions != null)
                    {
                        if (Role.Permissions.Any(x => x.PermissionId == item.Id))
                        {
                            
                            _db.PermissionRole.Remove(new PermissionRole
                            {
                                PermissionId = item.Id,
                                RoleId = Role.Id
                            });
                        }
                    }
                }
                
            }

            
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public User edit(int Id)
        {
            return _db.Users.SingleOrDefault(x => x.Id == Id);
        }

        public User Update(User user)
        {
            _db.Users.Attach(user);
            _db.Entry(user).Property(x => x.TypeUser).IsModified = true;

            return user;
        }
    }
}
