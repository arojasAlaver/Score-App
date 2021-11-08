using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using scoreapp.model;
using scoreapp.model.database.pivots;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace scoreapp.data
{
    public class Context : DbContext
    {
        protected readonly IHttpContextAccessor _httAccessor;
        private readonly ILogger<Context> _log;
        private readonly IDataProtectionProvider _provider;
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<CarInfo> Cars { get; set; }
        public DbSet<JobInfo> Jobs { get; set; }
        public DbSet<Config> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<PermissionRole> PermissionRole { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroup { get; set; }
        

        public Context(DbContextOptions<Context> Options) : base(Options)
        {

            _httAccessor = this.GetService<IHttpContextAccessor>();
            _log = this.GetService<ILogger<Context>>();
            _provider = this.GetService<IDataProtectionProvider>();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasMany(x => x.Applications).WithOne(y => y.Person);
            modelBuilder.Entity<Person>().HasMany(x => x.Jobs).WithOne(y => y.Person);
            modelBuilder.Entity<Person>().ToTable("tbl_Persons");

            modelBuilder.Entity<Application>().HasOne(x => x.Person).WithMany(y => y.Applications);
            modelBuilder.Entity<Application>().HasOne(x => x.Vehicle).WithMany(y => y.Applications);
            modelBuilder.Entity<Application>().ToTable("tbl_Applications");

            modelBuilder.Entity<CarInfo>().HasMany(x => x.Applications).WithOne(y => y.Vehicle);
            modelBuilder.Entity<CarInfo>().ToTable("tbl_Vehicles");

            modelBuilder.Entity<JobInfo>().HasOne(x => x.Person).WithMany(y => y.Jobs);
            modelBuilder.Entity<JobInfo>().ToTable("tbl_Jobs");

            modelBuilder.Entity<Audit>().ToTable("tbl_Audits");

            modelBuilder.Entity<Config>().ToTable("tbl_Settings");
            modelBuilder.Entity<Config>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(y => y.Users);
            modelBuilder.Entity<User>().ToTable("tbl_Users").Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>().HasMany(x => x.Permissions).WithOne(y => y.Role);
            modelBuilder.Entity<Role>().HasMany(x => x.Users).WithOne(y => y.Role);
            modelBuilder.Entity<Role>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Role>().ToTable("tbl_Roles");

            modelBuilder.Entity<Permission>().HasMany(x => x.Roles).WithOne(y => y.Permission);
            modelBuilder.Entity<Permission>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Permission>().ToTable("tbl_Permissions");
            


            modelBuilder.Entity<Group>().HasMany(x => x.Variables).WithOne(y => y.Group);
            modelBuilder.Entity<Group>().HasMany(x => x.Applications).WithOne(y => y.Group);
            modelBuilder.Entity<Group>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Group>().ToTable("tbl_Groups");


            modelBuilder.Entity<Variable>().HasOne(x => x.Group).WithMany(y => y.Variables);
            modelBuilder.Entity<Variable>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Variable>().ToTable("tbl_Variables");

            modelBuilder.Entity<PermissionRole>().HasKey(x => new { x.PermissionId, x.RoleId });
            modelBuilder.Entity<PermissionRole>().ToTable("PermissionRole");

            modelBuilder.Entity<ApplicationGroup>().HasKey(x => new { x.ApplicationId, x.GroupId });
            modelBuilder.Entity<ApplicationGroup>().ToTable("ApplicationGroup");

            IDataProtector _protector = this.GetService<IDataProtectionProvider>().CreateProtector(Config.private_key);

            modelBuilder.Entity<Config>().HasData(new List<Config>
            {
                new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("ProxyHost"),
                    Value = _protector.Protect("172.16.0.56"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("ProxyPort"),
                    Value = _protector.Protect("8080"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Buro.Api"),
                    Value = _protector.Protect("https://www.datacredito2.com/dcrservice_ws.asmx"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Buro.Username"),
                    Value = _protector.Protect("LUIS.PAULINO.ALAVER"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Buro.Password"),
                    Value = _protector.Protect("Sucursal01"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Ldap.Host"),
                    Value = _protector.Protect("ALAVER.LOCAL"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Ldap.Port"),
                    Value = _protector.Protect("389"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Ldap.DN"),
                    Value = _protector.Protect("DC=ALAVER,DC=LOCAL"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Buro.TotalDays"),
                    Value = _protector.Protect("90"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Ldap.Username"),
                    Value = _protector.Protect("EPAYIT"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Ldap.Password"),
                    Value = _protector.Protect("Alaver22"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,new Config()
                {
                    Id = Guid.NewGuid(),
                    Setting = _protector.Protect("Score.Accepted"),
                    Value = _protector.Protect("0"),
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
            });


            var _listPermission = new List<Permission>
            {
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Config.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Config.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Config.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Config.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },

                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.User.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.User.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.User.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.User.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },

                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Role.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Role.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Role.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Role.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },

                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Permission.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Permission.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Permission.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Permission.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },

                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Applications.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Applications.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Applications.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.Applications.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.GroupVariable.View",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.GroupVariable.Create",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.GroupVariable.Edit",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
                ,
                new Permission
                {
                    Id = Guid.NewGuid(),
                    Description = "Permission.GroupVariable.Delete",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
            };


            modelBuilder.Entity<Permission>().HasData(_listPermission);
            var _listRole = new List<Role>
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Description = "Administrador",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Description = "Basico",
                    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                }
            };
            modelBuilder.Entity<Role>().HasData(_listRole);

            var PermissionRole = new List<PermissionRole>();
            var _admin = _listRole.SingleOrDefault(x => x.Description == "Administrador");

            foreach (var item in _listPermission)
            {
                PermissionRole.Add(new model.database.pivots.PermissionRole { PermissionId = item.Id, RoleId = _admin.Id });
            }

            modelBuilder.Entity<PermissionRole>().HasData(PermissionRole);
            var user = new User
            {
                Id = 1,
                Username = "Admin",
                DisplayName = "Alaver Admin",
                Mail = "",
                IsLocal = true,
                EmployerCode = 0,
                Picture = null,
                TypeUser = model.enums.Type_User.None,
                CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            var password = new PasswordHasher<User>();
            string Password = password.HashPassword(user, "1WlRuNENCjWreTFm0mLaM2");
            user.Password = Password;

            modelBuilder.Entity<User>().HasData(new
            {
                Id = 1,
                Username = "Admin",
                DisplayName = "Alaver Admin",
                Mail = "",
                Password = user.Password,
                IsLocal = true,
                EmployerCode = user.EmployerCode,
                Picture= user.Picture,
                TypeUser = user.TypeUser,
                RoleId = _admin.Id,
                CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            });
            


        }

        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {

                var update = ChangeTracker.Entries().Where(x => x.State.HasFlag(EntityState.Modified) && !x.Entity.GetType().Name.Equals("PermissionRole")).ToList();
                var create = ChangeTracker.Entries().Where(x => x.State.HasFlag(EntityState.Added) && !x.Entity.GetType().Name.Equals("PermissionRole")).ToList();
                var delete = ChangeTracker.Entries().Where(x => x.State.HasFlag(EntityState.Deleted)).ToList();

                if (update.Count > 0)
                {
                    foreach (var entidad in update)
                    {
                        ((Timespan)entidad.Entity).UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }

                if (create.Count > 0)
                {
                    foreach (var entidad in create)
                    {
                        ((Timespan)entidad.Entity).CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ((Timespan)entidad.Entity).UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }

                var auditEntries = OnBeforeSaveChanges();
                var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

                await OnAfterSaveChanges(auditEntries);
                return result;
            }
            catch (DbUpdateException ex)
            {
                _log.LogError(ex.Message);
                return 0;

            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return 0;
            }
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            try
            {
                ChangeTracker.DetectChanges();
                var auditEntries = new List<AuditEntry>();
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                        continue;

                    var auditEntry = new AuditEntry(entry);
                    auditEntry.TableName = entry.Metadata.GetTableName();
                    auditEntries.Add(auditEntry);

                    foreach (var property in entry.Properties)
                    {
                        if (property.IsTemporary)
                        {
                            auditEntry.TemporaryProperties.Add(property);
                            continue;
                        }

                        string propertyName = property.Metadata.Name;
                        if (property.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                            continue;
                        }

                        switch (entry.State)
                        {
                            case EntityState.Added:
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                auditEntry.Action = "Insert";
                                auditEntry.CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                auditEntry.UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                break;

                            case EntityState.Deleted:
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.Action = "Delete";
                                auditEntry.CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                auditEntry.UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;

                            case EntityState.Modified:
                                if (property.IsModified)
                                {
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                    auditEntry.Action = "Update";
                                    auditEntry.CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    auditEntry.UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                break;
                        }
                    }
                }

                foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
                {
                    Audits.Add(auditEntry.ToAudit(_provider));
                }

                return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return null;
            }

        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            try
            {
                if (auditEntries == null || auditEntries.Count == 0)
                    return Task.CompletedTask;


                foreach (var auditEntry in auditEntries)
                {
                    foreach (var prop in auditEntry.TemporaryProperties)
                    {
                        if (prop.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                        else
                        {
                            auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                    }


                    Audits.Add(auditEntry.ToAudit(_provider));
                }

                return SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return null;
            }

        }


        public class AuditEntry
        {

            public AuditEntry(EntityEntry entry)
            {
                Entry = entry;
            }

            public EntityEntry Entry { get; }
            public string TableName { get; set; }
            public string Action { get; set; }
            public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
            public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
            public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
            public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }



            public bool HasTemporaryProperties => TemporaryProperties.Any();

            public Audit ToAudit(IDataProtectionProvider _provider)
            {

                var audit = new Audit();
                IDataProtector _protector = _provider.CreateProtector(Audit.private_key);
                return new Audit
                {
                    TableName = _protector.Protect(TableName),
                    Action = _protector.Protect(Action),
                    KeyValues = _protector.Protect(JsonConvert.SerializeObject(KeyValues)),
                    OldValues = OldValues.Count == 0 ? null : _protector.Protect(JsonConvert.SerializeObject(OldValues)),
                    NewValues = OldValues.Count == 0 ? null : _protector.Protect(JsonConvert.SerializeObject(NewValues)),
                    CreatedAt = CreatedAt,
                    UpdatedAt = UpdatedAt
                };
            }
        }
    }
}
