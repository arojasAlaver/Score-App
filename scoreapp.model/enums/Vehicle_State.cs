using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Vehicle_State
    {
        [Display(Name = "Nuevo")]
        NUEVO,
        [Display(Name = "Usado")]
        USADO
    }
}
