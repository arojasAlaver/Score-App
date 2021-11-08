using scoreapp.model.database.pivots;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class Role : Timespan
    {

        [Column(Order = 0)]
        public Guid Id { get; set; }
        [Column(Order = 1), Required(ErrorMessage = "Este campo es requerido")]
        public string Description { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }
        [NotMapped]
        public const string PrivateKey  = "public class Role : Timespan";
        [NotMapped]
        public Boolean HasPermissionAssigned { get; set; }


        public List<PermissionRole> Permissions { get; set; }

        public List<User> Users { get; set; }
    }
}
