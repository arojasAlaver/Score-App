using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_Identification
    {
        [Display(Name = "Cédula")]
        Cedula,
        [Display(Name = "Pasaporte")]
        Pasaporte
    }
}