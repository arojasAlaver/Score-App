using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using scoreapp.Hubs;
using scoreapp.model.database.tables;
using scoreapp.notifications.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace scoreapp.notifications.Services.Classes
{
    public class ApplicationNotification : IApplicationNotification
    {
        public readonly IConfiguration _config;
        public readonly IHubContext<ApplicationNotificationHub> _notify;
        SqlTableDependency<Application> _dependency;

        public ApplicationNotification(IHubContext<ApplicationNotificationHub> notify, IConfiguration config)
        {
            _notify = notify;
            _config = config;
        }
        public void Config()
        {
            ApplicationChanges();
        }

        public void ApplicationChanges()
        {
            _dependency = new SqlTableDependency<Application>(_config.GetConnectionString("SQLServer1"),"tbl_applications");
            _dependency.OnChanged += _dependency_OnChanged;
            _dependency.OnError += _dependency_OnError;
            _dependency.Start();
        }

        private void _dependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            if (_dependency != null)
                _dependency.Stop();
        }

        private void _dependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Application> e)
        {
            switch (e.ChangeType)
            {
                case TableDependency.SqlClient.Base.Enums.ChangeType.None:
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Delete:
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Insert:

                    _notify.Clients.All.SendAsync("ApplicationNotify", (Application)e.Entity);
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Update:
                    _notify.Clients.All.SendAsync("ApplicationNotify", (Application)e.Entity);
                    break;
            }    
        }
    }
}
