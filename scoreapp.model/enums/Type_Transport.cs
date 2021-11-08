using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_Transport
    {
        [Display(Name = "Transporte Público")]
        transporte_publico,
        [Display(Name = "Transporte Privado")]
        transporte_privado
    }
}
