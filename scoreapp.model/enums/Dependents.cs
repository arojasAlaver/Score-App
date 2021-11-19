using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Dependents
    {
        [Display(Name = "Sin Carga")]
        Sin_Carga,
        [Display(Name = "Entre 1 y 2")]
        Entre_1_y_2,
        [Display(Name = "Entre 3 y 5")]
        Entre_3_y_5,
        [Display(Name = "Mas de 5")]
        Mas_de_5
        
    }
}
