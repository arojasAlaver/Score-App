using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_User
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Ejecutivo de Negocios")]
        Ejecutivo,
        [Display(Name = "Oficial de Negocios")]
        Oficial
    }
}
