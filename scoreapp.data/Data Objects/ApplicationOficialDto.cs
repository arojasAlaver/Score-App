using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Data_Objects
{
    public class ApplicationOficialDto
    {
        public int ApplicationId { get; set; }
        public int OficialId { get; set; }
        public Boolean Notify { get; set; }
    }
}
