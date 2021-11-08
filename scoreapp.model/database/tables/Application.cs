using scoreapp.model.database.pivots;
using scoreapp.model.enums;
using scoreapp.model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.database.tables
{
    public class Application:Timespan
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public Person Person { get; set; }
        [Column(Order = 2)]
        public CarInfo Vehicle { get; set; }
        [Column(Order = 3)]
        public Application_Status Status { get; set; }
        [Column(Order = 4)]
        public int Score { get; set; }
        [Column(Order = 5, TypeName = "decimal(18,2)"), Display(Name = "Monto a solicitar"), Range(20000, double.MaxValue, ErrorMessage = "El monto mínimo de la solicitud es de $20,000.00 pesos.")]
        public decimal Amount { get; set; }
        [Column(Order = 6, TypeName = "decimal(18,2)"), Display(Name = "Ingresos Mensuales"), Range(0, double.MaxValue, ErrorMessage = "El rango de aceptación es de {0} hasta {1}")]
        [DataType(DataType.Currency), Required(ErrorMessage = "El monto mínimo debe ser cero (0.00)")]

        public decimal? Incomes { get; set; } = 0;

        [Column(Order = 7, TypeName = "decimal(18,2)"), Display(Name = "Otros Ingresos"), Range(0, double.MaxValue, ErrorMessage = "El rango de aceptación es de {0} hasta {1}")]
        [DataType(DataType.Currency), Required(ErrorMessage = "El monto mínimo debe ser cero (0.00)")]
        public decimal? OtherIncomes { get; set; } = 0;
        [acceptConditionValidation(ErrorMessage = "Debe permitir que esta entidad pueda verificar su hístorial créditicio")]
        [Column(Order = 8)]
        public bool AcceptCondition { get; set; } = false;
        [Range(1, 60, ErrorMessage = "El rango de aceptación es de {1} hasta {2} meses"), Column(Order = 9), Display(Name = "Plazo en Meses"),
            Required(ErrorMessage = "Este campo es requerido")]
        public int? Terms { get; set; }

        public Offices Office { get; set; }

        public User ExecutiveAssigned { get; set; }
        
        public User OfficialAssignTo { get; set; }

        public List<ApplicationGroup> Groups { get; set; }

    }
}
