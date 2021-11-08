using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.pivots
{
    public class ApplicationGroup
    {
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
