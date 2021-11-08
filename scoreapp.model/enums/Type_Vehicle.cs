using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_Vehicle
    {
        [Display(Name ="Automovil")]
        automovil,
        [Display(Name = "Minivan")]
        minivan,
        [Display(Name = "Jeepeta")]
        jeepeta,
        [Display(Name = "Camioneta")]
        camioneta,
        [Display(Name = "Camión")]
        camion,
        [Display(Name = "Autobus")]
        autobus
    }
}
