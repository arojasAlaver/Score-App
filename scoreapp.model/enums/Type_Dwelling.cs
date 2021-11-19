using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_Dwelling
    {
        [Display(Name = "Casa Propia")]
        Casa_Propia,
        [Display(Name = "Casa Alquilada")]
        Casa_Alquilada
        
    }
}
