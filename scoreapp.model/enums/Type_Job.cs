using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Type_Job
    {
        [Display(Name = "Médicina")]
        MEDICINA,
        [Display(Name = "Enseñanza/Maestros")]
        ENSENANZA_MAESTROS,
        [Display(Name = "Informática/Computadoras")]
        INFORMATICA_COMPUTADORAS,
        [Display(Name = "Técnicos")]
        TECNICOS,
        [Display(Name = "Abogados")]
        ABOGADOS,
        [Display(Name = "Religiosos")]
        RELIGIOSOS,
        [Display(Name = "Pensionados/Retirados")]
        PENSIONADOS_RETIRADOS,
        [Display(Name = "Militares/Policias")]
        MILITARES_POLICIAS,
        [Display(Name = "Colmadero")]
        COLMADERO,
        [Display(Name = "Cominicación/Periodista")]
        COMUNICACION_PERIODISTA,
        [Display(Name = "Sin ningúna profesión u oficio")]
        SIN_NINGUNA_PROFESION_U_OFC,
        [Display(Name = "Ingenieria/arquitectura")]
        INGENIERIA_ARQUITECTURA,
        [Display(Name = "Maestro Constructor")]
        MAESTRO_CONSTRUCTOR,
        [Display(Name = "Agricultura/Ganadería")]
        AGRICULTURA_GANADERIA,
        [Display(Name = "Licenciaturas AMD Merc Cont")]
        LICENCIATURAS_AMD_MERC_CONT,
        [Display(Name = "Cafetería")]
        CAFETERIA,
        [Display(Name = "Artista")]
        ARTISTA,
        [Display(Name = "Chofer de carro público")]
        CHOFER_DE_CARRO_PUBLICO,
        [Display(Name = "Otras ocupaciones")]
        OTRAS_OCUPACIONES,
        [Display(Name = "Préstamista/Cambista")]
        PRESTAMISTA_CAMBISTA,
        [Display(Name = "Enfermeras")]
        ENFERMERAS,
        [Display(Name = "Empresa")]
        EMPRESA,
        [Display(Name = "Motoconcho")]
        MOTOCONCHO,
        [Display(Name = "Compra/Venta")]
        COMPRAVENTA,
        [Display(Name = "Carpintería")]
        CARPINTERIA,
        [Display(Name = "Electricista")]
        ELECTRICISTA,
        [Display(Name = "Electromecanica")]
        ELECTROMECANICO,
        [Display(Name = "Fotografo")]
        FOTOGRAFO,
        [Display(Name = "Herrería")]
        HERRERIA,
        [Display(Name = "Mecánico")]
        MECANICO,
        [Display(Name = "Sastre")]
        SASTRE,
        [Display(Name = "Salón de belleza")]
        SALON_DE_BELLEZA,
        [Display(Name = "Taxista")]
        TAXISTA,
        [Display(Name = "Técnico refrigeración")]
        TECNICO_REFRIGERACION,
        [Display(Name = "Transporte escolar")]
        TRANSPORTE_ESCOLAR,
        [Display(Name = "Venta de empanadas")]
        VENTA_DE_EMPANADAS,
        [Display(Name = "Desabollador")]
        DESABOLLADOR,
        [Display(Name = "Estilista")]
        ESTILISTA_DE_UÑAS,
        [Display(Name = "Frutero")]
        FRUTERO,
        [Display(Name = "Pica pollo")]
        PICA_POLLO,
        [Display(Name = "Pintor")]
        PINTOR,
        [Display(Name = "Plomero")]
        PLOMERO,
        [Display(Name = "Pollero")]
        POLLERO,
        [Display(Name = "Albañil")]
        ALBAÑIL,
        [Display(Name = "Autopintura")]
        AUTOPINTURA,
        [Display(Name = "Gomero")]
        GOMERO,
        [Display(Name = "Peluquero")]
        PELUQUERO,
        [Display(Name = "Guagua expreso")]
        GUAGUA_EXPRESO,
        [Display(Name = "Mecánico pasolas motores")]
        MECANICO_PASOLAS_MOTORES,
        [Display(Name = "Venta de ropa paca")]
        VENTA_DE_ROPA_PACA,
        [Display(Name = "Zapatero")]
        ZAPATERO,
        [Display(Name = "Doméstica")]
        DOMESTICA,
        [Display(Name = "Ebanista")]
        EBANISTA,
        [Display(Name = "Ventorillo")]
        VENTORRILLO,
        [Display(Name = "Empleado privado")]
        EMPLEADO_PRIVADO,
        [Display(Name = "Palero")]
        PALERO,
        [Display(Name = "Empleado público")]
        EMPLEADO_PUBLICO,

    }
}
