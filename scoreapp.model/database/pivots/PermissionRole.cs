using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.pivots
{
    public class PermissionRole
    {
        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

    }
}
