using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Data_Objects
{
    public class ConfigDataObject
    {
        public Guid Id { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
    }
}
