using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Marital_Status
    {
        [Display(Name ="Casado(a)")]
        casado,
        [Display(Name = "Union Libre")]
        union_libre,
        [Display(Name = "Viudo(a)")]
        viudo,
        [Display(Name = "Divorciado(a)")]
        divorciado,
        [Display(Name = "Separado(a)")]
        separado,
        [Display(Name = "Soltero(a)")]
        soltero
    }
}
