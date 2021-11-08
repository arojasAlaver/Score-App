using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class CarInfo:Timespan
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1), Display(Name = "Marca del vehiculo"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Brand_Vehicle? Brand { get; set; }
        [Column(Order = 2), Display(Name = "Módelo del vehiculo"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Model_Vehicle? Model { get; set; }
        [Column(Order = 3), Display(Name = "Año de fabricación"), Required(ErrorMessage = "Este campo es obligatorio")]
        public int? Year { get; set; }
        [Column(Order = 4), Display(Name = "Estado del vehiculo"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Vehicle_State? Vehicle_State { get; set; }

        public List<Application> Applications { get; set; }


    }
}
