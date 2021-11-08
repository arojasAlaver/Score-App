using scoreapp.model.database.pivots;
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
    public class Group:Timespan
    {
        [Column(Order = 0), Key]
        public Guid Id { get; set; }
        [Column(Order = 1), Display(Name = "Nombre del Grupo"), Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }
        [Column(Order = 2), Display(Name = "Estatus de Grupo"), Required(ErrorMessage = "Este campo es obligatorio")]
        public Group_Status Status { get; set; }
        
        public List<Variable> Variables { get; set; }
        public List<ApplicationGroup> Applications { get; set; }
    }
}
