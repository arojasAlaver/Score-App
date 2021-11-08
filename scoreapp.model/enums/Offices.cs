using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Offices
    {
        [Display(Name = "Oficina Principal")]
        OFICINA_PRINCIPAL,
        [Display(Name = "Sucursal Santiago")]
        SUCURSAL_SANTIAGO,
        [Display(Name = "Oficina Ranchito")]
        OFICINA_RANCHITO,
        [Display(Name = "Sucursal Villa Rosa")]
        SUCURSAL_VILLA_ROSA,
        [Display(Name = "Oficina Cutupú")]
        OFICINA_CUTUPU,
        [Display(Name = "Oficina La Sirena")]
        OFICINA_LA_SIRENA,
        [Display(Name = "Sucursal Cotui")]
        SUCURSAL_COTUI,
        [Display(Name = "Sucursal Jarabacoa")]
        SUCURSAL_JARABACOA,
        [Display(Name = "Agencia Ave. Riva")]
        AGENCIA_AVE_RIVAS,
        [Display(Name = "Sucursal Constanza")]
        SUCURSAL_CONSTANZA,
        [Display(Name = "Agencia Padre Adolfo")]
        AGENCIA_PADRE_ADOLFO,
        [Display(Name = "Sucursal Chefito Batista")]
        CHEFITO_BATISTA,
        [Display(Name = "Sucursal Jima")]
        SUCURSAL_JIMA,
        [Display(Name = "Sucursal Santo Domingo")]
        SUCURSAL_SANTO_DOMINGO,
        [Display(Name = "Oficina San Francisco")]
        OFICINA_SAN_FRANCISCO,
        [Display(Name = "Oficina Moca")]
        OFICINA_MOCA,
        [Display(Name = "Agencia El Paseo Santiago")]
        AGENCIA_EL_PASEO_SANTIAGO,
        [Display(Name = "Agencia SFM Plaza Platinum")]
        AGENCIA_SFM_PLAZA_PLATINUM,
        [Display(Name = "Sucursal Fantino")]
        SUCURSAL_FANTINO,
        [Display(Name = "Sucursal Plaza Lope de Vega")]
        SUCURSAL_PLAZA_LOPE_DE_VEGA
    }
}
