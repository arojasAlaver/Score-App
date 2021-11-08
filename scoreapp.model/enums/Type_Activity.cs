using System;
using System.ComponentModel.DataAnnotations;

namespace scoreapp_model_enums
{
    public enum Type_Activity
    {
        [Display(Name = "Actividades auxiliares de la intermediacion financiera")]
        ACTIVIDADES_AUXILIARES_DE_LA_INTERMEDIACION_FINANCIERA,
        [Display(Name = "Actividades de asociaciones N.C.P")]
        ACTIVIDADES_DE_ASOCIACIONES_N_C_P,
        [Display(Name = "Actividades de edición, impresión y reproducción de grab")]
        ACTIVIDADES_DE_EDICION_E_IMPRESION_Y_DE_REPRODUCCION_DE_GRAB,
        [Display(Name = "Actividades de esparcimiento, culturales y depo")]
        ACTIVIDADES_DE_ESPARCIMIENTO_Y_ACTIVIDADES_CULTURALES_Y_DEPO,
        [Display(Name = "Actividades de transporte complementarias y auxiliares")]
        ACTIVIDADES_DE_TRANSPORTE_COMPLEMENTARIAS_Y_AUXILIARES_ACTI,
        [Display(Name = "Actividades finqueras")]
        ACTIVIDADES_FINQUERAS,
        [Display(Name = "Actividades inmobiliarias")]
        ACTIVIDADES_INMOBILIARIAS,
        [Display(Name = "Administración pública y defensa planes de seguridad social")]
        ADMINISTRACION_PUBLICA_Y_DEFENSA__PLANES_DE_SEGURIDAD_SOCIAL,
        [Display(Name = "AFP")]
        AFP,
        [Display(Name = "Agencias de bienes raices")]
        AGENCIAS_DE_BIENES_RAICES,
        [Display(Name = "Agricultura, ganadería, caza y actividades de servicios conex")]
        AGRICULTURA_GANADERIA_CAZA_Y_ACTIVIDADES_DE_SERVICIOS_CONEX,
        [Display(Name = "Almacenes")]
        ALMACENES,
        [Display(Name = "Alquiler de maquinaria y equipo sin operario y de efecto")]
        ALQUILER_DE_MAQUINARIA_Y_EQUIPO_SIN_OPERARIOS_Y_DE_EFECTOS,
        [Display(Name = "Cambista de divisas informales")]
        CAMBISTAS_DE_DIVISAS_INFORMALES,
        [Display(Name = "Captación, depuración y distribución de agua")]
        CAPTACION_DEPURACION_Y_DISTRIBUCION_DE_AGUA,
        [Display(Name = "Casino")]
        CASINO,
        [Display(Name = "Comercio al por mayor y en comisión")]
        COMERCIO_AL_POR_MAYOR_Y_EN_COMISION_EXCEPTO_EL_COMERCIO_DE,
        [Display(Name = "Comercio al por menor excepto vehiculos")]
        COMERCIO_AL_POR_MENOR_EXCEPTO_EL_COMERCIO_DE_VEHICULOS_AUTO,
        [Display(Name = "Comercio de joyas y metales preciosos")]
        COMERCIO_DE_JOYAS_Y_METALES_PRECIOSOS,
        [Display(Name = "Compañía fiduciaria no financiera")]
        COMPAÑIA_FIDUCIARIA_NO_FINANCIERA,
        [Display(Name = "Compañía de seguros autroizados")]
        COMPAÑIAS_DE_SEGUROS_AUTORIZADOS,
        [Display(Name = "Compañía prestadoras de servicios")]
        COMPAÑIAS_PRESTADORAS_DE_SERVICIOS,
        [Display(Name = "Compañía prestadoras de servicios maritimos")]
        COMPAÑIAS_PRESTADORAS_DE_SERVICIOS_MARITIMOS,
        [Display(Name = "Construcción")]
        CONSTRUCCION,
        [Display(Name = "Correo y telecomunicaciones")]
        CORREO_Y_TELECOMUNICACIONES,
        [Display(Name = "Curtido y adobo de cueros fabriación de maletas")]
        CURTIDO_Y_ADOBO_DE_CUEROS_FABRICACION_DE_MALETAS_BOLSOS_DE,
        [Display(Name = "Dealer de vehiculos")]
        DEALER_DE_VEHICULOS,
        [Display(Name = "Desarrolladores de inmuebles")]
        DESARROLLADORES_DE_INMUEBLES,
        [Display(Name = "Elaboración de productos alimenticios y bebidas")]
        ELABORACION_DE_PRODUCTOS_ALIMENTICIOS_Y_BEBIDAS,
        [Display(Name = "Elaboración de productos de tabaco")]
        ELABORACION_DE_PRODUCTOS_DE_TABACO,
        [Display(Name = "Eliminación de desperdicios y aguas residuales saneamiento")]
        ELIMINACION_DE_DESPERDICIOS_Y_AGUAS_RESIDUALES_SANEAMIENTO,
        [Display(Name = "Empresa de comercio exterios exportación importación")]
        EMPRESA_DE_COMERCIO_EXTERIOR_EXPORTACION_IMPORTACION,
        [Display(Name = "Empresa de servicios médicos")]
        EMPRESAS_DE_SERVICIOS_MEDICOS,
        [Display(Name = "Empresas farmaceuticas por internet no reconocidas")]
        EMPRESAS_FARMACEUTICAS_POR_INTERNET_NO_RECONOCIDAS,
        [Display(Name = "Empresas farmaceuticas reconocidas")]
        EMPRESAS_FARMACEUTICAS_RECONOCIDAS,
        [Display(Name = "Empresas que operan a traves de internet e business")]
        EMPRESAS_QUE_OPERAN_A_TRAVES_DE_INTERNET_E_BUSINESS,
        [Display(Name = "Enseñanza")]
        ENSENANZA,
        [Display(Name = "Explotación de otras minas y canteras")]
        EXPLOTACION_DE_OTRAS_MINAS_Y_CANTERAS,
        [Display(Name = "Extracción de carbon y lignito extracción de turba")]
        EXTRACCION_DE_CARBON_Y_LIGNITO_EXTRACCION_DE_TURBA,
        [Display(Name = "Extracción de minerales de uranio y torio")]
        EXTRACCION_DE_MINERALES_DE_URANIO_Y_TORIO,
        [Display(Name = "Extracción de minerales metaliferos")]
        EXTRACCION_DE_MINERALES_METALIFEROS,
        [Display(Name = "Extracción de petroleo crudo y gas")]
        EXTRACCION_DE_PETROLEO_CRUDO_Y_GAS_EXCEPTO_LAS_ACTIVIDADES_D,
        [Display(Name = "Fabricación de coque productos de la refinación del petroleo")]
        FABRICACION_DE_COQUE_PRODUCTOS_DE_LA_REFINACIONDEL_PETROL,
        [Display(Name = "Fabricación de equipos y aparatos de radio, televisión y común")]
        FABRICACION_DE_EQUIPO_Y_APARATOS_DE_RADIO_TELEVISION_Y_COMUN,
        [Display(Name = "Fabricación de intrumentos médicos ópticos y de precisión")]
        FABRICACION_DE_INSTRUMENTOS_MEDICOS_OPTICOS_Y_DE_PRECISION,
        [Display(Name = "Fabricación de maquinaria de oficina contabilidad e informa")]
        FABRICACION_DE_MAQUINARIA_DE_OFICINA_CONTABILIDAD_E_INFORMA,
        [Display(Name = "Fabricación de maquinaria y aparatos electricos C.P")]
        FABRICACION_DE_MAQUINARIA_Y_APARATOS_ELECTRICOSN_C_P,
        [Display(Name = "Fabricación de maquinaria y equipo N.C.P")]
        FABRICACION_DE_MAQUINARIA_Y_EQUIPO_N_C_P,
        [Display(Name = "Fabricación de metales comunes")]
        FABRICACION_DE_METALES_COMUNES,
        [Display(Name = "Fabricación de muebeles industrias manufactureras N.C.P")]
        FABRICACION_DE_MUEBLES_INDUSTRIAS_MANUFACATURERAS_N_C_P,
        [Display(Name = "Fabricación de otros productos minerales no metálicos")]
        FABRICACION_DE_OTROS_PRODUCTOS_MINERALES_NO_METALICOS,
        [Display(Name = "Fabricación de otros tipos de quipo de transporte")]
        FABRICACION_DE_OTROS_TIPOS_DE_EQUIPO_DE_TRANSPORTE,
        [Display(Name = "Fabricación de papel y de productos de papel")]
        FABRICACION_DE_PAPEL_Y_DE_PRODUCTOS_DE_PAPEL,
        [Display(Name = "Fabricación de prendas de vestir, adobo y teñido de pieles")]
        FABRICACION_DE_PRENDAS_DE_VESTIR_ADOBO_Y_TENIDO_DE_PIELES,
        [Display(Name = "Fabricación de productos de caucho y plástico")]
        FABRICACION_DE_PRODUCTOS_DE_CAUCHO_Y_PLASTICO,
        [Display(Name = "Fabricación de productos elaborados de metal excepto maquin")]
        FABRICACION_DE_PRODUCTOS_ELABORADOS_DE_METAL_EXCEPTO_MAQUIN,
        [Display(Name = "Fabricación de sustancias y productos químicos")]
        FABRICACION_DE_SUSTANCIAS_Y_PRODUCTOS_QUIMICOS,
        [Display(Name = "Fabricación de vehiculos automotores, remolques y semirremolques")]
        FABRICACION_DE_VEHICULOS_AUTOMOTORES_REMOLQUES_Y_SEMIRREMOL,
        [Display(Name = "Fabricación e hilatura de firbas textiles, tejedura de productos")]
        FABRICACION_E_HILATURA_DE_FIBRAS_TEXTILES_TEJEDURA_DE_PRODUC,
        [Display(Name = "Financiación de planes de seguros y de pensiones")]
        FINANCIACION_DE_PLANES_DE_SEGUROS_Y_DE_PENSIONES_EXCEPTO_LO,
        [Display(Name = "Hogares privados con servicio doméstico")]
        HOGARES_PRIVADOS_CON_SERVICIO_DOMESTICO,
        [Display(Name = "Hoteles no pertenecientes a cadenas reconocidas")]
        HOTELES_NO_PERTENECIENTES_A_CADENAS_RECONOCIDAS,
        [Display(Name = "Hoteles y restaurantes")]
        HOTELES_Y_RESTAURANTES,
        [Display(Name = "Informática y actividades conexas")]
        INFORMATICA_Y_ACTIVIDADES_CONEXAS,
        [Display(Name = "Instituciones financieras no bancarias casa de cambios")]
        INSTITUCIONES_FINANCIERAS_NO_BANCARIAS_CASA_DE_CAMBIOS,
        [Display(Name = "Intermediación financiera excepto la financiación de planes")]
        INTERMEDIACION_FINANCIERA_EXCEPTO_LA_FINANCIACION_DE_PLANES,
        [Display(Name = "Investigación y desarrollo")]
        INVESTIGACION_Y_DESARROLLO,
        [Display(Name = "Jubilados")]
        JUBILADOS,
        [Display(Name = "Militares y guardias de seguridad")]
        MILITARES_Y_GUARDIAS_DE_SEGURIDAD,
        [Display(Name = "Moteles")]
        MOTELES,
        [Display(Name = "Negocios de empresas de corretajes y corredores")]
        NEGOCIOS_DE_EMPRESAS_DE_CORRETAJES_Y_CORREDORES,
        [Display(Name = "Negocios de ventas de armas autorizados")]
        NEGOCIOS_DE_VENTAS_DE_ARMAS_AUTORIZADOS,
        [Display(Name = "Night club")]
        NIGHT_CLUB,
        [Display(Name = "No aplica")]
        NO_APLICA,
        [Display(Name = "O.N.G fundaciones de caridad o no lucrativas")]
        ONG_FUNDACIONES_DE_CARIDAD_O_NO_LUCRATIVAS,
        [Display(Name = "Organizaciones religiosas")]
        ORGANIZACIONES_RELIGIOSAS,
        [Display(Name = "Organizaciones y organos extraterritoriales")]
        ORGANIZACIONES_Y_ORGANOS_EXTRATERRITORIALES,
        [Display(Name = "Otras actividades de servicios")]
        OTRAS_ACTIVIDADES_DE_SERVICIOS,
        [Display(Name = "Otras actividades empresariales")]
        OTRAS_ACTIVIDADES_EMPRESARIALES,
        [Display(Name = "Pesca explotación de criaderos de peces y granjas piscicolas")]
        PESCA_EXPLOTACION_DE_CRIADEROS_DE_PECES_Y_GRANJASPISCICOLAS,
        [Display(Name = "Producción de madera y fabriación de productos de madera")]
        PRODUCCION_DE_MADERA_Y_FABRICACION_DE_PRODUCTOS_DE_MADERA_Y,
        [Display(Name = "Profesionales independientes, abogados, notarios, contadores")]
        PROFESIONALES_INDEPENDIENTES_ABOGADOS_NOTARIOS_CONTADORES,
        [Display(Name = "Puesto de bolsas o intermediarios de valores regulados")]
        PUESTOS_DE_BOLSAS_O_INTERMEDIARIOS_DE_VALORES_REGULADOS,
        [Display(Name = "Reciclamiento")]
        RECICLAMIENTO,
        [Display(Name = "Restaurante")]
        RESTAURANTE,
        [Display(Name = "Servicios sociales y de salud")]
        SERVICIOS_SOCIALES_Y_DE_SALUD,
        [Display(Name = "Silvicultura extracción de madera y actividades de servicio")]
        SILVICULTURA_EXTRACCION_DE_MADERA_Y_ACTIVIDADES_DE_SERVICI,
        [Display(Name = "Sin actividad económica")]
        SIN_ACTIVIDAD_ECONOMICA,
        [Display(Name = "Sociedades off shore")]
        SOCIEDADES_OFF_SHORE,
        [Display(Name = "Suministro de electricidad y gas")]
        SUMINISTRO_DE_ELECTRICIDAD_Y_GAS,
        [Display(Name = "Supermercados")]
        SUPERMERCADOS,
        [Display(Name = "Transporte por vía acuática")]
        TRANSPORTE_POR_VIA_ACUATICA,
        [Display(Name = "Transporte por vía aerea")]
        TRANSPORTE_POR_VIA_AEREA,
        [Display(Name = "Transporte por vía terrestre o tuberias")]
        TRANSPORTE_POR_VIA_TERRESTRE_TRANSPORTE_POR_TUBERIAS,
        [Display(Name = "Venta de artículos de cuero y piel")]
        VENTA_DE_ARTICULOS_DE_CUEROS_Y_PIELES,
        [Display(Name = "Venta, mantenimiento y reparación de vehiculos automotores")]
        VENTA_MANTENIMIENTO_Y_REPARACION_DE_VEHICULOS_AUTOMOTORES_Y

    }
}
