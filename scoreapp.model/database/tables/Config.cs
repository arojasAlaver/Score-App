using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class Config:Timespan
    {
        [NotMapped]
        public const string private_key = "public class Config:Timespan";

        [Column(Order = 0),Key]
        public Guid Id { get; set; }
        [Column(Order = 1)]
        public string Setting { get; set; }
        [Column(Order = 2)]
        public string Value { get; set; }
        
    }
}
