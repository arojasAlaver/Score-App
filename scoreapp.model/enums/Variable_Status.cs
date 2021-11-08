using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Variable_Status
    {
        [Display(Name = "Activado")]
        Active,
        [Display(Name = "Inactivado")]
        Inactive
    }
}
