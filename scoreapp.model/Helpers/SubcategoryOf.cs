using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.Helpers
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SubcategoryOf:Attribute
    {
        public Province _province { get; private set; }
        public Type_Vehicle _type_vehicle { get; private set; }
        public Brand_Vehicle _brand_vehicle { get; private set; }
        public SubcategoryOf(Province province)
        {
            _province = province;
        }

        public SubcategoryOf(Type_Vehicle type_vehicle, Brand_Vehicle brand_vehicle)
        {
            _type_vehicle = type_vehicle;
            _brand_vehicle = brand_vehicle;
        }
    }
}
