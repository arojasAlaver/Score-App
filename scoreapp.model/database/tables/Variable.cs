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
    public class Variable:Timespan
    {
        [Column(Order = 0), Key]
        public Guid Id { get; set; }
        [Column(Order = 1), Display(Name = "Nombre de Variable"), Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }
        [Column(Order = 2), Display(Name = "Puntaje"), Required(ErrorMessage = "Este campo es obligatorio")]
        public int Score { get; set; }
        [Column(Order = 3), Display(Name = "Estatus de Variable"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Variable_Status Status { get; set; }
        public Group Group { get; set; }
    }
}
