using Microsoft.AspNetCore.DataProtection;
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
    public class Person:Timespan
    {
       
        

        [Column(Order = 0), Display(Name = "No. Documento"), Required(ErrorMessage = "El campo número de documento es obligatorio")]
        public string Id { get; set; }
        [Column(Order = 1), Display(Name = "Nombres"), Required(ErrorMessage = "El campo nombres es obligatorio"),DataType(DataType.Text)]
      
        public string Names { get; set; }
        [Column(Order = 2), Display(Name = "Apellidos"), Required(ErrorMessage = "El campo apellidos es obligatorio")]
        
        public string LastNames { get; set; }
        [Column(Order = 3), Display(Name = "Tipo de Identificación"), Required(ErrorMessage = "El campo tipo de identificación es obligatorio")]
        
        public Type_Identification? Type_Indetification { get; set; }
        [Column(Order = 4), Display(Name = "Teléfono Movíl"), Required(ErrorMessage = "El campo Teléfono Movíl es obligatorio")]
        
        public string cel1 { get; set; }
        [Column(Order = 5), Display(Name = "Otro Teléfono")]
        
        public string cel2 { get; set; }
        [Column(Order = 6), Display(Name = "Correo"), Required(ErrorMessage = "El campo correo eléctronico es obligatorio"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column(Order = 7), Display(Name = "Dirección"), Required(ErrorMessage = "El campo dirección es obligatorio"), DataType(DataType.Text)]
        public string Address { get; set; }
        [Column(Order = 8), Display(Name = "Fecha de Nacimiento"), Required(ErrorMessage = "El campo fecha de nacimiento es obligatorio"),DataType(DataType.Date)]
        public DateTime? BornDate { get; set; }
        [NotMapped]
        public string encryptedId { get; set; }
        [Column(Order = 9), Display(Name = "Provincia"), Required(ErrorMessage = "El campo provincia es obligatorio")]
        public Province? Province { get; set; }
        [Column(Order = 10), Display(Name = "Municipio"), Required(ErrorMessage = "El campo municipio es obligatorio")]
        public Municipality? Municipality { get; set; }

        [Column(Order = 11), Display(Name = "Estado Civil"), Required(ErrorMessage = "El campo estado civil es obligatorio")]
        public Marital_Status? Marital_Status { get; set; }

        [Column(Order = 12), Display(Name = "Nacionalidad"), Required(ErrorMessage = "El campo nacionalidad es obligatorio")]
        public Nationality? Nationality { get; set; }
        public DateTime? LastDateBuroConsult { get; set; }

        [Column(TypeName = "xml",Order =13)]
        public string Buro { get; set; }
        [Column(Order = 12), Display(Name = "Dependientes"), Required(ErrorMessage = "El campo dependientes es obligatorio")]
        public Dependents Dependents { get; set; }
        [Column(Order = 12), Display(Name = "Tipo de Vivienda"), Required(ErrorMessage = "El campo tipo de vivienda es obligatorio")]
        public Type_Dwelling Dwelling { get; set; }

        public List<Application> Applications { get; set; }
        public List<JobInfo> Jobs { get; set; }
    }
}
