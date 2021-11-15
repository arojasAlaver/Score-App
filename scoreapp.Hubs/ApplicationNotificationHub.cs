using Microsoft.AspNetCore.SignalR;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.Hubs
{
    public class ApplicationNotificationHub:Hub
    {
        public async Task ApplicationNotify(Application app)
        {
            await Clients.All.SendAsync("ApplicationNotify",null);
        }
    }
}
