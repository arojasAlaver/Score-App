using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using scoreapp.model.enums;
using scoreapp.model.Helpers;
using scoreapp_model_enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace scoreapp.Pages
{
   [AllowAnonymous]
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        public IDictionary<string, Dictionary<string, string>> _prov { get; set; }
        public IDictionary<string, Dictionary<string, string>> _type_car { get; set; }
        public List<SelectListItem> _province { get; set; }
        public List<SelectListItem> _municipality { get; set; }
        public List<SelectListItem> _type_identification { get; set; }
        public List<SelectListItem> _type_activities { get; set; }
        public List<SelectListItem> _type_job { get; set; }
        public List<SelectListItem> _year { get; set; }
        public List<SelectListItem> _type_vehicle { get; set; }
        public List<SelectListItem> _model_vehicle { get; set; }
        public List<SelectListItem> _vehicle_state { get; set; }
        public List<SelectListItem> _marital_status { get; set; }
        public List<SelectListItem> _nationality { get; set; }
        public List<SelectListItem> _offices { get; set; }
        [TempData]
        public string[] Message { get; set; }
        
        public string Certified { get; set; }
            

        [BindProperty]
        public Person _person { get; set; }
        
        private readonly IHtmlHelper _helper;
        private readonly ISendData _service;
        
        public IndexModel(ILogger<IndexModel> logger, IHtmlHelper helper,ISendData service)
        {
            _logger = logger;
            _helper = helper;
            _service = service;
            
        }

        public void OnGet()
        {
            
            load();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                
                


                if (ModelState.IsValid)
                {
                    _person = await _service.Store(_person);
                    Boolean result = Convert.ToBoolean(await _service.SaveAsync());

                    if (result)
                    {
                        TempData["Message"] = new string[] {_person.Names,_person.LastNames,_person.Applications.First().Amount.ToString(),_person.Id.ToString()};
                        return RedirectToPage("./index");
                    }


                }
                load();

                return Page();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void load()
        {


            
            _prov = new Dictionary<string, Dictionary<string, string>>();
            _type_car = new Dictionary<string, Dictionary<string, string>>();
            _type_activities = _helper.GetEnumSelectList<Type_Activity>().OrderBy(x => x.Text).ToList();
            _vehicle_state = _helper.GetEnumSelectList<Vehicle_State>().OrderBy(x => x.Text).ToList();
            _type_job = _helper.GetEnumSelectList<Type_Job>().OrderBy(x => x.Text).ToList();
            _type_identification = _helper.GetEnumSelectList<Type_Identification>().ToList();
            _marital_status = _helper.GetEnumSelectList<Marital_Status>().ToList();
            _nationality = _helper.GetEnumSelectList<Nationality>().ToList();
            _offices = _helper.GetEnumSelectList<Offices>().ToList();

            _year = Enumerable.Range(1970, (DateTime.Now.Year + 1 - 1970)).Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            }).OrderByDescending(x => x.Value).ToList();

            _helper.GetEnumSelectList<Province>().ToList().ForEach(x =>
            {

                _prov.Add($"{x.Value}:{x.Text}", new Dictionary<string, string>());
            });

            _helper.GetEnumSelectList<Brand_Vehicle>().ToList().ForEach(x =>
            {

                _type_car.Add($"{x.Value}:{x.Text}", new Dictionary<string, string>());
            });

            

            _type_identification.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Tipo de Documento"
            });
            _type_activities.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Tipo de actividad"
            });
            _type_job.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Ocupación"
            });

            _year.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Año"
            });

            _vehicle_state.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Estado"
            });

            _marital_status.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Estado Civil"
            });

            _nationality.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Nacionalidad"
            });

            _offices.Insert(0, new SelectListItem
            {
                Selected = true,
                Disabled = true,
                Text = "Oficina de Preferencia"
            });



            Enum.GetValues(typeof(Municipality)).Cast<Municipality>().ToList().ForEach(x =>
            {
                string p = x.GetType().GetField(Enum.GetName(x.GetType(), x))
                    .GetCustomAttributes(false).OfType<SubcategoryOf>()
                    .SingleOrDefault()._province.ToString().Replace("_"," ");
                    string like = (from data in _prov.Keys where data.EndsWith(p) select data).SingleOrDefault();
                    if(!string.IsNullOrEmpty(like))
                        _prov[like].Add(((int)x).ToString(), x.ToString().Replace("_"," "));
            });

            Enum.GetValues(typeof(Model_Vehicle)).Cast<Model_Vehicle>().ToList().ForEach(x =>
            {
                string p = x.GetType().GetField(Enum.GetName(x.GetType(), x))
                    .GetCustomAttributes(false).OfType<SubcategoryOf>()
                    .SingleOrDefault()._brand_vehicle.ToString().Replace("_", " ");
                string like = (from data in _type_car.Keys where data.ToLower().EndsWith(p.ToLower()) select data).SingleOrDefault();
                if (!string.IsNullOrEmpty(like))
                    _type_car[like].Add(((int)x).ToString(), x.GetType().GetField(Enum.GetName(x.GetType(), x))
                    .GetCustomAttributes(false).OfType<DisplayAttribute>()
                    .SingleOrDefault().Name.Replace("_", " "));
                

                
            });

            Certified = "Certífico que todas las informaciones indicadas más arriba son correctas, y autorizo a alaver como entidad financiera para validarlos"
            + " y a consultar mi historial crediticio en las bases de datos de los buros de información crediticia."
            + " En caso de que este crédito fuese aprobado, el solicitante autoriza expresa e irrevocablemente a la"
            + " citada Entidad Financiera, a suministrar a los centros de información crediticia, toda la información"
            + " derivada de la experiencia del manejo de su crédito por parte de esta institución.";
        }
    }
}
