using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class User:Timespan
    {
        public int Id { get; set; }
        public int EmployerCode { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public bool IsLocal { get; set; } = false;
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Picture { get; set; }
        [NotMapped]
        public bool Exists { get; set; }
        public Type_User TypeUser { get; set; } = Type_User.Oficial;
        public Role Role { get; set; }

        [InverseProperty("ExecutiveAssigned")]
        public List<Application> ExecutiveAssigned { get; set; }
        [InverseProperty("OfficialAssignTo")]
        public List<Application> ApplicationsAssigned { get; set; }
    }
}
