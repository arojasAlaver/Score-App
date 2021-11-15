using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Data_Objects
{
    public class StatusDto
    {
        public int ApplicationId { get; set; }
        public Application_Status Status { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; } = 0;
    }
}
