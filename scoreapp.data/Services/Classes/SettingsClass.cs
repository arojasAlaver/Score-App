using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using scoreapp.data.Data_Objects;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Classes
{
    public class SettingsClass : ISettings
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _configs;
        public SettingsClass(Context db,IDataProtectionProvider provider)
        {
            _db = db;
            _provider = provider;
            _configs = _db.Settings.AsNoTracking().ToList();
        }
        public List<Config> Index()
        {
            IDataProtector _protector = _provider.CreateProtector(Config.private_key);
            return _db.Settings.Select(x => new Config 
            {
                Id = x.Id,
                Setting = _protector.Unprotect(x.Setting),
                Value = _protector.Unprotect(x.Value),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public List<Config> Store(List<Config> _settings)
        {
            IDataProtector _protector = _provider.CreateProtector(Config.private_key);
            _settings.ForEach(x =>
            {
                
               
                if (_configs.SingleOrDefault(y => y.Id == x.Id)!= null)
                {
                    
                    _db.Update(new Config 
                    {
                        Id = x.Id,
                        Setting = _protector.Protect(x.Setting),
                        Value = _protector.Protect(x.Value)
                    });
                }
                else
                {
                    _db.Add(new Config
                    {
                        Id = Guid.NewGuid(),
                        Setting = _protector.Protect(x.Setting),
                        Value = _protector.Protect(x.Value)
                    });
                }
            });
            _configs.ForEach(x =>
            {
                if(_settings.SingleOrDefault(y => y.Id == x.Id)==null)
                {
                    _db.Settings.Remove(x);
                }
            });
            return _settings;
        }
    }
}
