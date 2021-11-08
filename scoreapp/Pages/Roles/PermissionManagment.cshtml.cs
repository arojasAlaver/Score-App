using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;

namespace scoreapp.Pages.Roles
{
    [Authorize(Policy = "Permissions")]
    public class PermissionManagmentModel : PageModel
    {
        private readonly IUsers _service;
        private readonly ILogger<PermissionManagmentModel> _log;
        [BindProperty]
        public List<Permission> _permissions { get; set; }
        [BindProperty]
        public Role _role { get; set; }
        
        public PermissionManagmentModel(IUsers service,ILogger<PermissionManagmentModel> log)
        {
            _service = service;
            _log = log;
        }
        public void OnGet(Guid Id)
        {
            _permissions = _service.GetAllPermissions();
            _role = _service.Get(Id);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Post(_role, _permissions);
                    Boolean _results = Convert.ToBoolean(await _service.SaveChangesAsync());
                    if (_results)
                        return Redirect("/7e793c11-acc7-4cf5-8592-bc2025f529c7");
                }
                return Page();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return Page();
            }
            
        }
    }
}
