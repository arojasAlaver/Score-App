using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model
{
    public class Timespan
    {
        [Column(Order = 49)]
        public DateTime CreatedAt { get; set; }
        [Column(Order = 50)]
        public DateTime UpdatedAt { get; set; }
    }
}
