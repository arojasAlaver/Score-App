using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Nationality
    {
        [Display(Name = "Dominicano(a)")]
        dominicano,
        [Display(Name = "Extranjero Residente")]
        extranjero_residente,
        [Display(Name = "Nacional No Residente")]
        nacional_no_residente,
        [Display(Name = "Extrajero No Residente")]
        extranjero_no_residente
    }
}
