using scoreapp.model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Municipality
    {
        [SubcategoryOf(Province.Azua), Display(Name = "Azua")]
        Azua,
        [SubcategoryOf(Province.Azua), Display(Name = "Estebanía")]
        Estebanía,
        [SubcategoryOf(Province.Azua), Display(Name = "Guayabal")]
        Guayabal,
        [SubcategoryOf(Province.Azua), Display(Name = "Las Charcas")]
        Las_Charcas,
        [SubcategoryOf(Province.Azua), Display(Name = "Las Yayas de Viajama")]
        Las_Yayas_de_Viajama,
        [SubcategoryOf(Province.Azua), Display(Name = "Padre Las Casas")]
        Padre_Las_Casas,
        [SubcategoryOf(Province.Azua), Display(Name = "Peralta")]
        Peralta,
        [SubcategoryOf(Province.Azua), Display(Name = "Pueblo Viejo")]
        Pueblo_Viejo,
        [SubcategoryOf(Province.Azua), Display(Name = "Sabana Yegua")]
        Sabana_Yegua,
        [SubcategoryOf(Province.Azua), Display(Name = "Tábara Arriba")]
        Tábara_Arriba,
        [SubcategoryOf(Province.Bahoruco), Display(Name = "Galván")]
        Galván,
        [SubcategoryOf(Province.Bahoruco), Display(Name = "Los Ríos")]
        Los_Ríos,
        [SubcategoryOf(Province.Bahoruco), Display(Name = "Neiba")]
        Neiba,
        [SubcategoryOf(Province.Bahoruco), Display(Name = "Tamayo")]
        Tamayo,
        [SubcategoryOf(Province.Bahoruco), Display(Name = "Villa Jaragua")]
        Villa_Jaragua,
        [SubcategoryOf(Province.Barahona), Display(Name = "Barahona")]
        Barahona,
        [SubcategoryOf(Province.Barahona), Display(Name = "Cabral")]
        Cabral,
        [SubcategoryOf(Province.Barahona), Display(Name = "El Peñón")]
        El_Peñon,
        [SubcategoryOf(Province.Barahona), Display(Name = "Enriquillo")]
        Enriquillo,
        [SubcategoryOf(Province.Barahona), Display(Name = "Fundación")]
        Fundacion,
        [SubcategoryOf(Province.Barahona), Display(Name = "Jaquimeyes")]
        Jaquimeyes,
        [SubcategoryOf(Province.Barahona), Display(Name = "La Cienaga")]
        La_Cienaga,
        [SubcategoryOf(Province.Barahona), Display(Name = "Las Salinas")]
        Las_Salinas,
        [SubcategoryOf(Province.Barahona), Display(Name = "Paraiso")]
        Paraiso,
        [SubcategoryOf(Province.Barahona), Display(Name = "Polo")]
        Polo,
        [SubcategoryOf(Province.Barahona), Display(Name = "Vicente Noble")]
        Vicente_Noble,
        [SubcategoryOf(Province.Dajabon), Display(Name = "Dajabón")]
        Dajabon,
        [SubcategoryOf(Province.Dajabon), Display(Name = "El Pino")]
        El_Pino,
        [SubcategoryOf(Province.Dajabon), Display(Name = "Loma de Cabrera")]
        Loma_De_Cabrera,
        [SubcategoryOf(Province.Dajabon), Display(Name = "Partido")]
        Partido,
        [SubcategoryOf(Province.Dajabon), Display(Name = "Restauración")]
        Restauracion,
        [SubcategoryOf(Province.Distrito_Nacional), Display(Name = "Distrito Nacional")]
        Distrito_Nacional,
        [SubcategoryOf(Province.Duarte), Display(Name = "Arenoso")]
        Arenoso,
        [SubcategoryOf(Province.Duarte), Display(Name = "Castillo")]
        Castillo,
        [SubcategoryOf(Province.Duarte), Display(Name = "Eugenio María de Hostos")]
        Eugenio_Maria_De_Hostos,
        [SubcategoryOf(Province.Duarte), Display(Name = "Las Guaranas")]
        Las_Guaranas,
        [SubcategoryOf(Province.Duarte), Display(Name = "Pimentel")]
        Pimentel,
        [SubcategoryOf(Province.Duarte), Display(Name = "San Francisco de Macorís")]
        San_Francisco_De_Macoris,
        [SubcategoryOf(Province.Duarte), Display(Name = "Villa Riva")]
        Villa_Riva,
        [SubcategoryOf(Province.El_Seibo), Display(Name = "El Seibo")]
        El_Seibo,
        [SubcategoryOf(Province.El_Seibo), Display(Name = "Miches")]
        Miches,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "Banica")]
        Banica,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "Comendador")]
        Comendador,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "El Llano")]
        El_Llano,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "Hondo Valle")]
        Hondo_Valle,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "Juan Santiago")]
        Juan_Santiago,
        [SubcategoryOf(Province.Elías_Piña), Display(Name = "Pedro Santana")]
        Pedro_Santana,
        [SubcategoryOf(Province.Espaillat), Display(Name = "Cayetano Germosen")]
        Cayetano_Germosen,
        [SubcategoryOf(Province.Espaillat), Display(Name = "Moca")]
        Moca,
        [SubcategoryOf(Province.Espaillat), Display(Name = "San Víctor")]
        San_Victor,
        [SubcategoryOf(Province.Espaillat), Display(Name = "Gaspar Hernandez")]
        Gaspar_Hernandez,
        [SubcategoryOf(Province.Espaillat), Display(Name = "Jamao al Norte")]
        Jamao_Al_Norte,
        [SubcategoryOf(Province.Hato_Mayor), Display(Name = "El Valle")]
        El_Valle,
        [SubcategoryOf(Province.Hato_Mayor), Display(Name = "Hato Mayor")]
        Hato_Mayor,
        [SubcategoryOf(Province.Hato_Mayor), Display(Name = "Sabana de la Mar")]
        Sabana_De_La_Mar,
        [SubcategoryOf(Province.Hermanas_Mirabal), Display(Name = "Salcedo")]
        Salcedo,
        [SubcategoryOf(Province.Hermanas_Mirabal), Display(Name = "Tenares")]
        Tenares,
        [SubcategoryOf(Province.Hermanas_Mirabal), Display(Name = "Villa Tapia")]
        Villa_Tapia,
        [SubcategoryOf(Province.Independencia), Display(Name = "Cristobal")]
        Cristobal,
        [SubcategoryOf(Province.Independencia), Display(Name = "Duverge")]
        Duverge,
        [SubcategoryOf(Province.Independencia), Display(Name = "Jimaní")]
        Jimani,
        [SubcategoryOf(Province.Independencia), Display(Name = "La Descubierta")]
        La_Descubierta,
        [SubcategoryOf(Province.Independencia), Display(Name = "Mella")]
        Mella,
        [SubcategoryOf(Province.Independencia), Display(Name = "Postrer Rio")]
        Postrer_Rio,
        [SubcategoryOf(Province.La_Altagracia), Display(Name = "Higuey")]
        Higuey,
        [SubcategoryOf(Province.La_Altagracia), Display(Name = "San Rafael de la Yuma")]
        San_Rafael_Del_Yuma,
        [SubcategoryOf(Province.La_Romana), Display(Name = "Guaymate")]
        Guaymate,
        [SubcategoryOf(Province.La_Romana), Display(Name = "La Romana")]
        La_Romana,
        [SubcategoryOf(Province.La_Romana), Display(Name = "Villa Hermosa")]
        Villa_Hermosa,
        [SubcategoryOf(Province.La_Vega), Display(Name = "Constanza")]
        Constanza,
        [SubcategoryOf(Province.La_Vega), Display(Name = "Jarabacoa")]
        Jarabacoa,
        [SubcategoryOf(Province.La_Vega), Display(Name = "Jima Abajo")]
        Jima_Abajo,
        [SubcategoryOf(Province.La_Vega), Display(Name = "La Vega")]
        La_Vega,
        [SubcategoryOf(Province.Maria_Trinidad_Sanchez), Display(Name = "Cabrera")]
        Cabrera,
        [SubcategoryOf(Province.Maria_Trinidad_Sanchez), Display(Name = "El Factor")]
        El_Factor,
        [SubcategoryOf(Province.Maria_Trinidad_Sanchez), Display(Name = "Nagua")]
        Nagua,
        [SubcategoryOf(Province.Maria_Trinidad_Sanchez), Display(Name = "Rio San Juan")]
        Rio_San_Juan,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Castañuelas")]
        Castañuelas,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Guayubin")]
        Guayubin,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Las Matas de Santa Cruz")]
        Las_Matas_De_Santa_Cruz,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Montecristi")]
        Montecristi,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Pepillo Salcedo")]
        Pepillo_Salcedo,
        [SubcategoryOf(Province.Monte_Cristi), Display(Name = "Villa Vasquez")]
        Villa_Vasquez,
        [SubcategoryOf(Province.Monte_Plata), Display(Name = "Bayaguana")]
        Bayaguana,
        [SubcategoryOf(Province.Monte_Plata), Display(Name = "Monte Plata")]
        Monte_Plata,
        [SubcategoryOf(Province.Monte_Plata), Display(Name = "Peralvillo")]
        Peralvillo,
        [SubcategoryOf(Province.Monte_Plata), Display(Name = "Sabana Grande de Boya")]
        Sabana_Grande_De_Boya,
        [SubcategoryOf(Province.Monte_Plata), Display(Name = "Yamasa")]
        Yamasa,
        [SubcategoryOf(Province.Moseñor_Nouel), Display(Name = "Bonao")]
        Bonao,
        [SubcategoryOf(Province.Moseñor_Nouel), Display(Name = "Maimón")]
        Maimon,
        [SubcategoryOf(Province.Moseñor_Nouel), Display(Name = "Piedra Blanca")]
        Piedra_Blanca,
        [SubcategoryOf(Province.Pedernales), Display(Name = "Oviedo")]
        Oviedo,
        [SubcategoryOf(Province.Pedernales), Display(Name = "Pedernales")]
        Pedernales,
        [SubcategoryOf(Province.Peravia), Display(Name = "Baní")]
        Bani,
        [SubcategoryOf(Province.Peravia), Display(Name = "Matanzas")]
        Matanzas,
        [SubcategoryOf(Province.Peravia), Display(Name = "Nizao")]
        Nizao,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Altamira")]
        Altamira,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Guananico")]
        Guananico,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Imbert")]
        Imbert,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Los Hidalgos")]
        Los_Hidalgos,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Lúperon")]
        Luperon,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Puerto Plata")]
        Puerto_Plata,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Sosua")]
        Sosua,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Villa Isabela")]
        Villa_Isabela,
        [SubcategoryOf(Province.Puerto_Plata), Display(Name = "Villa Montellano")]
        Villa_Montellano,
        [SubcategoryOf(Province.Samana), Display(Name = "Las Terrenas")]
        Las_Terrenas,
        [SubcategoryOf(Province.Samana), Display(Name = "Samaná")]
        Samana,
        [SubcategoryOf(Province.Samana), Display(Name = "Sanchez")]
        Sanchez,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Bajos de Haina")]
        Bajos_De_Haina,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Cambita Garabitos")]
        Cambita_Garabitos,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Los Cacaos")]
        Los_Cacaos,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Sabana Grande de Palenque")]
        Sabana_Grande_De_Palenque,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "San Cristobal")]
        San_Cristobal,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "San Gregorio de Nigua")]
        San_Gregorio_De_Nigua,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Villa Altagracia")]
        Villa_Altagracia,
        [SubcategoryOf(Province.San_Cristobal), Display(Name = "Yaguate")]
        Yaguate,
        [SubcategoryOf(Province.San_Jose_De_Ocoa), Display(Name = "Rancho Arriba")]
        Rancho_Arriba,
        [SubcategoryOf(Province.San_Jose_De_Ocoa), Display(Name = "Sabana Larga")]
        Sabana_Larga,
        [SubcategoryOf(Province.San_Jose_De_Ocoa), Display(Name = "San Jose de Ocoa")]
        San_Jose_De_Ocoa,
        [SubcategoryOf(Province.San_Juan), Display(Name = "Bohechio")]
        Bohechio,
        [SubcategoryOf(Province.San_Juan), Display(Name = "El Cercado")]
        El_Cercado,
        [SubcategoryOf(Province.San_Juan), Display(Name = "Juan de Herrera")]
        Juan_De_Herrera,
        [SubcategoryOf(Province.San_Juan), Display(Name = "Las Matas de Farfán")]
        Las_Matas_De_Farfan,
        [SubcategoryOf(Province.San_Juan), Display(Name = "San Juan de la Maguana")]
        San_Juan_De_La_Maguana,
        [SubcategoryOf(Province.San_Juan), Display(Name = "Vallejuelo")]
        Vallejuelo,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "Consuelo")]
        Consuelo,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "Guayacanes")]
        Guayacanes,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "Los LLanos")]
        Los_Llanos,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "Quisqueya")]
        Quisqueya,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "Ramón Santana")]
        Ramon_Santana,
        [SubcategoryOf(Province.San_Pedro_De_Macoris), Display(Name = "San Pedro de Macorís")]
        San_Pedro_De_Macoris,
        [SubcategoryOf(Province.Sanchez_Ramirez), Display(Name = "Cevicos")]
        Cevicos,
        [SubcategoryOf(Province.Sanchez_Ramirez), Display(Name = "Cotuí")]
        Cotui,
        [SubcategoryOf(Province.Sanchez_Ramirez), Display(Name = "Fantino")]
        Fantino,
        [SubcategoryOf(Province.Sanchez_Ramirez), Display(Name = "Villa la Mata")]
        Villa_La_Mata,
        [SubcategoryOf(Province.Santiago_Rodriguez), Display(Name = "Moncion")]
        Moncion,
        [SubcategoryOf(Province.Santiago_Rodriguez), Display(Name = "San Ignacio de Sabaneta")]
        San_Ignacio_De_Sabaneta,
        [SubcategoryOf(Province.Santiago_Rodriguez), Display(Name = "Villa los Almacigos")]
        Villa_Los_Almacigos,
        [SubcategoryOf(Province.Santiago), Display(Name = "Baitoa")]
        Baitoa,
        [SubcategoryOf(Province.Santiago), Display(Name = "Jánico")]
        Janico,
        [SubcategoryOf(Province.Santiago), Display(Name = "Licey al Medio")]
        Licey_Al_Medio,
        [SubcategoryOf(Province.Santiago), Display(Name = "Puñal")]
        Puñal,
        [SubcategoryOf(Province.Santiago), Display(Name = "Sabana Iglesia")]
        Sabana_Iglesia,
        [SubcategoryOf(Province.Santiago), Display(Name = "San Jose de las Matas")]
        San_Jose_De_Las_Matas,
        [SubcategoryOf(Province.Santiago), Display(Name = "Santiago de los Caballeros")]
        Santiago_De_Los_Caballero,
        [SubcategoryOf(Province.Santiago), Display(Name = "Tamboríl")]
        Tamboril,
        [SubcategoryOf(Province.Santiago), Display(Name = "Villa Bisono Navarrete")]
        Villa_Bisono_Navarrete,
        [SubcategoryOf(Province.Santiago), Display(Name = "Villa Gonzales")]
        Villa_Gonzalez,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Boca Chica")]
        Boca_Chica,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Los Alcarrizos")]
        Los_Alcarrizos,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Pedro Brand")]
        Pedro_Brand,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "San Antonio de Guerra")]
        San_Antonio_De_Guerra,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Santo Domingo Este")]
        Santo_Domingo_Este,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Santo Domingo Norte")]
        Santo_Domingo_Norte,
        [SubcategoryOf(Province.Santo_Domingo), Display(Name = "Santo Domingo Oeste")]
        Santo_Domingo_Oeste,
        [SubcategoryOf(Province.Valverde), Display(Name = "Esperanza")]
        Esperanza,
        [SubcategoryOf(Province.Valverde), Display(Name = "Laguna Salada")]
        Laguna_Salada,
        [SubcategoryOf(Province.Valverde), Display(Name = "Mao")]
        Mao


    }
}