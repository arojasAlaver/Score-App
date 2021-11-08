using scoreapp.data.Data_Objects;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Interfaces
{
    public interface ISettings
    {
        public List<Config> Index();
        public List<Config> Store(List<Config> _settings);
        public Task<int> SaveChangesAsync();
    }
}
