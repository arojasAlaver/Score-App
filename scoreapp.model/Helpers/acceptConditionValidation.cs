using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.Helpers
{
    public class acceptConditionValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Object.Equals(value,true);
        }


    }
}
