using scoreapp.model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.model.enums
{
    public enum Model_Vehicle
    {
        [Display(Name = "Accord"),SubcategoryOf(Type_Vehicle.automovil,Brand_Vehicle.HONDA)]
        ACCORD,
        [Display(Name = "Acty"), SubcategoryOf(Type_Vehicle.minivan, Brand_Vehicle.HONDA)]
        ACTY,
        [Display(Name = "Acura"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        ACURA,
        [Display(Name = "City"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        CITY,
        [Display(Name = "Civic"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        CIVIC,
        [Display(Name = "CR-v"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.HONDA)]
        CR_V,
        [Display(Name = "Fit"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        FIT,
        [Display(Name = "HR-v"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.HONDA)]
        HR_V,
        [Display(Name = "Insight"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        INSIGHT,
        [Display(Name = "Odyssey"), SubcategoryOf(Type_Vehicle.minivan, Brand_Vehicle.HONDA)]
        ODYSSEY,
        [Display(Name = "Pilot"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.HONDA)]
        PILOT,
        [Display(Name = "Prelude"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        PRELUDE,
        [Display(Name = "Ridgeline"), SubcategoryOf(Type_Vehicle.camioneta, Brand_Vehicle.HONDA)]
        RIDGELINE,
        [Display(Name = "S-2000"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HONDA)]
        S_2000,
        [Display(Name = "Ilx"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ACURA)]
        ILX,
        [Display(Name = "Mdx"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.ACURA)]
        MDX,
        [Display(Name = "Rdx"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.ACURA)]
        RDX,
        [Display(Name = "Rsx"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ACURA)]
        RSX,
        [Display(Name = "Tl"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ACURA)]
        TL,
        [Display(Name = "Tlx"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ACURA)]
        TLX,
        [Display(Name = "159"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ALFA_ROMEO)]
        UNO_CINCO_NUEVE,
        [Display(Name = "Mito"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ALFA_ROMEO)]
        MITO,
        [Display(Name = "Stelvio"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.ALFA_ROMEO)]
        STELVIO,
        [Display(Name = "A3"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A3,
        [Display(Name = "A4"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A4,
        [Display(Name = "A5"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A5,
        [Display(Name = "A6"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A6,
        [Display(Name = "A7"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A7,
        [Display(Name = "A8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        A8,
        [Display(Name = "Q2"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q2,
        [Display(Name = "Q3"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q3,
        [Display(Name = "Q4"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q4,
        [Display(Name = "Q5"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q5,
        [Display(Name = "Q6"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q6,
        [Display(Name = "Q7"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q7,
        [Display(Name = "Q8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        Q8,
        [Display(Name = "R8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        R8,
        [Display(Name = "RS_Q8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        RS_Q8,
        [Display(Name = "S3"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        S3,
        [Display(Name = "S6"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        S6,
        [Display(Name = "S7"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        S7,
        [Display(Name = "S8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        S8,
        [Display(Name = "SQ5"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        SQ5,
        [Display(Name = "I3"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        I3,
        [Display(Name = "I8"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.AUDI)]
        I8,
        [Display(Name = "Serie 1"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_1,
        [Display(Name = "Serie 3"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_3,
        [Display(Name = "Serie 4"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_4,
        [Display(Name = "Serie 5"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_5,
        [Display(Name = "Serie 6"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_6,
        [Display(Name = "Serie 7"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_7,
        [Display(Name = "Serie M"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_M,
        [Display(Name = "Serie X"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_X,
        [Display(Name = "Serie Z"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.BMW)]
        Serie_Z,
        [Display(Name = "Avalanche"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Avalanche,
        [Display(Name = "Aveo"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Aveo,
        [Display(Name = "Blazer"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Blazer,
        [Display(Name = "Bolt EV"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Bolt_EV,
        [Display(Name = "Camaro"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Camaro,
        [Display(Name = "Captiva"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Captiva,
        [Display(Name = "City Express"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        City_Express,
        [Display(Name = "CMV"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        CMV,
        [Display(Name = "Colorado"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Colorado,
        [Display(Name = "Corvette"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Corvette,
        [Display(Name = "Cruze"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Cruze,
        [Display(Name = "DAMAS"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        DAMAS,
        [Display(Name = "Equinox"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Equinox,
        [Display(Name = "Express"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Express,
        [Display(Name = "Impala"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Impala,
        [Display(Name = "Lumina"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Lumina,
        [Display(Name = "Malibu"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Malibu,
        [Display(Name = "Monte Carlo"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Monte_Carlo,
        [Display(Name = "N 300"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        N_300,
        [Display(Name = "N 400"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        N_400,
        [Display(Name = "Orlando"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Orlando,
        [Display(Name = "Silverado"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Silverado,
        [Display(Name = "Sonic"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Sonic,
        [Display(Name = "Spark"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Spark,
        [Display(Name = "SSR"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        SSR,
        [Display(Name = "Suburban"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Suburban,
        [Display(Name = "Tahoe"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Tahoe,
        [Display(Name = "Tracker"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Tracker,
        [Display(Name = "Trail Blazer"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Trail_Blazer,
        [Display(Name = "Traverse"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Traverse,
        [Display(Name = "Trax"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Trax,
        [Display(Name = "Uplander"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.CHEVROLET)]
        Uplander,
        [Display(Name = "Accent"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Accent,
        [Display(Name = "Avante"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Avante,
        [Display(Name = "Azera"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Azera,
        [Display(Name = "Cantus"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Cantus,
        [Display(Name = "County"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        County,
        [Display(Name = "Elantra"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Elantra,
        [Display(Name = "Genesis"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Genesis,
        [Display(Name = "Grand I 10"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Grand_I_10,
        [Display(Name = "Grand Santa Fe"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Grand_Santa_Fe,
        [Display(Name = "Grand Starex"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Grand_Starex,
        [Display(Name = "Grandeur"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Grandeur,
        [Display(Name = "H 1"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        H_1,
        [Display(Name = "H 100"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        H_100,
        [Display(Name = "H350"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        H350,
        [Display(Name = "I 10"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        I_10,
        [Display(Name = "I 20"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        I_20,
        [Display(Name = "Ioniq"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Ioniq,
        [Display(Name = "Kona"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Kona,
        [Display(Name = "Palisade"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Palisade,
        [Display(Name = "Porter"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Porter,
        [Display(Name = "Santa Fe"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Santa_Fe,
        [Display(Name = "Sonata"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Sonata,
        [Display(Name = "Starex"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Starex,
        [Display(Name = "Staria"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Staria,
        [Display(Name = "TQ"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        TQ,
        [Display(Name = "Tucson"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Tucson,
        [Display(Name = "Veloster"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Veloster,
        [Display(Name = "Venue"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Venue,
        [Display(Name = "Verna"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.HYUNDAI)]
        Verna,
        [Display(Name = "ASX"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        ASX,
        [Display(Name = "Eclipse"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Eclipse,
        [Display(Name = "Endeavor"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Endeavor,
        [Display(Name = "Evolution"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Evolution,
        [Display(Name = "Galant"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Galant,
        [Display(Name = "L-200"), SubcategoryOf(Type_Vehicle.camioneta, Brand_Vehicle.MITSUBISHI)]
        L_200,
        [Display(Name = "Lancer"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Lancer,
        [Display(Name = "Mirage"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Mirage,
        [Display(Name = "Montero"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.MITSUBISHI)]
        Montero,
        [Display(Name = "Montero Sport"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.MITSUBISHI)]
        Montero_Sport,
        [Display(Name = "Nativa"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.MITSUBISHI)]
        Nativa,
        [Display(Name = "Outlander"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.MITSUBISHI)]
        Outlander,
        [Display(Name = "Xpande"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.MITSUBISHI)]
        Xpande,
        [Display(Name = "4 Runner"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        Runner,
        [Display(Name = "Agya"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Agya,
        [Display(Name = "Aqua"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Aqua,
        [Display(Name = "Avalon"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Avalon,
        [Display(Name = "C-HR"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        C_HR,
        [Display(Name = "Camry"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Camry,
        [Display(Name = "Celica"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Celica,
        [Display(Name = "Corolla"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Corolla,
        [Display(Name = "Corolla Cross"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Corolla_Cross,
        [Display(Name = "Cressida"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Cressida,
        [Display(Name = "FJ Cruiser"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        FJ_Cruiser,
        [Display(Name = "Fortuner"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        Fortuner,
        [Display(Name = "Hiace"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Hiace,
        [Display(Name = "Highlander"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        Highlander,
        [Display(Name = "Hilux"), SubcategoryOf(Type_Vehicle.camioneta, Brand_Vehicle.TOYOTA)]
        Hilux,
        [Display(Name = "Land Cruiser"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        Land_Cruiser,
        [Display(Name = "Land Cruiser Prado"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        Land_Cruiser_Prado,
        [Display(Name = "Lite-Ace"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Lite_Ace,
        [Display(Name = "Matrix"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Matrix,
        [Display(Name = "Passo"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Passo,
        [Display(Name = "Pixis"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Pixis,
        [Display(Name = "Prius"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Prius,
        [Display(Name = "Probox"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Probox,
        [Display(Name = "RAV4"), SubcategoryOf(Type_Vehicle.jeepeta, Brand_Vehicle.TOYOTA)]
        RAV4,
        [Display(Name = "Rush"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Rush,
        [Display(Name = "Scion"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Scion,
        [Display(Name = "Sequoia"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Sequoia,
        [Display(Name = "Sienna"), SubcategoryOf(Type_Vehicle.minivan, Brand_Vehicle.TOYOTA)]
        Sienna,
        [Display(Name = "Starlet"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Starlet,
        [Display(Name = "Supra"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Supra,
        [Display(Name = "Tacoma"), SubcategoryOf(Type_Vehicle.camioneta, Brand_Vehicle.TOYOTA)]
        Tacoma,
        [Display(Name = "Town-Ace"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Town_Ace,
        [Display(Name = "Trueno"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Trueno,
        [Display(Name = "Tundra"), SubcategoryOf(Type_Vehicle.camioneta, Brand_Vehicle.TOYOTA)]
        Tundra,
        [Display(Name = "Venza"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Venza,
        [Display(Name = "VITZ"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        VITZ,
        [Display(Name = "Yaris"), SubcategoryOf(Type_Vehicle.automovil, Brand_Vehicle.TOYOTA)]
        Yaris,
    }
}
