using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using scoreapp.data.Data_Objects;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;

namespace scoreapp.Pages.Configs
{
    [Authorize(Policy = "Config")]
    public class ConfigsModel : PageModel
    {
        private readonly ISettings _settings;
        private readonly ILogger<ConfigsModel> _log;
        public List<ConfigDataObject> _configsDataObject { get; set; }
        [BindProperty]
        public List<Config> _configs { get; set; }
        [TempData]
        public IDictionary<string,string> Message { get; set; }
        public ConfigsModel(ISettings setting,ILogger<ConfigsModel> log)
        {
            _settings = setting;
            _log = log;
            
        }
        public void OnGet()
        {
            _configs = _settings.Index();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _configs = _settings.Store(_configs);
                    Boolean result = Convert.ToBoolean(await _settings.SaveChangesAsync());
                    if (result)
                    {
                        TempData["Message"] = new Dictionary<string, string>
                        {
                            {"message","Todas las configuraciones han sido guardadas"},
                            {"type", "success"}
                        };
                        return Redirect("/081663df-1745-485f-a8d4-6f9bb39f0042");
                        
                    }
                        
                }
                return Page();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                Message = new Dictionary<string, string>
                {
                    {"message",ex.Message},
                    {"type", "error"}
                    
                };
                return Page();
            }
            
        }
    }
}
