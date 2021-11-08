using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class Audit:Timespan
    {
        [NotMapped]
        public const string private_key = "public class Audit:Timespan";
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Action { get; set; }
        [Column(Order = 2)]
        public string TableName { get; set; }
        [Column(Order = 3)]
        public string KeyValues { get; set; }
        [Column(Order = 4)]
        public string OldValues { get; set; }
        [Column(Order = 5)]
        public string NewValues { get; set; }
    }
}
