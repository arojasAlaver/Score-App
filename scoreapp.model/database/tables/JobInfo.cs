using scoreapp.model.enums;
using scoreapp_model_enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class JobInfo:Timespan
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public Person Person { get; set; }
        [Column(Order = 2),Display(Name = "Nombre de la compañía"),Required(ErrorMessage = "Este campo es obligatorio")]
        public string CompanyName { get; set; }
        [Column(Order = 3), Display(Name = "Télefono de la compañía"), Required(ErrorMessage = "Este campo es obligatorio")]
        public string CompanyPhone { get; set; }
        [Column(Order = 4), Display(Name = "Tipo de empresa"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Type_Activity? TypeActivity { get; set; }
        [Column(Order = 5), Display(Name = "Ocupación"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Type_Job? TypeJob { get; set; }
        [Column(Order = 6), Display(Name = "Dirección"), Required(ErrorMessage = "Este campo es obligatorio")]
        public string Address { get; set; }
        [Column(Order = 7), Display(Name = "Provincia"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Province? Province { get; set; }
        [Column(Order = 8), Display(Name = "Municipio"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Municipality? Municipality { get; set; }
        [Column(Order = 9), Display(Name = "Tiempo laborando (En Meses)"), Required(ErrorMessage = "Este campo es obligatorio"),]
        public int TimeInCompany { get; set; }

    }
}
