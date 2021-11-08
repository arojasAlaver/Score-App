using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Interfaces
{
    public interface IEmailNotify
    {
        public void SendEmail(Application app);
    }
}
