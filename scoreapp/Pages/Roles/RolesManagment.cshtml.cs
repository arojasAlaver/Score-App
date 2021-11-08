using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;

namespace scoreapp.Pages.Roles
{
    [Authorize(Policy = "Roles")]
    public class RolesManagmentModel : PageModel
    {
        public List<Role> Roles { get; set; }
        private readonly IUsers _service;
        public RolesManagmentModel(IUsers service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Roles = _service.Get();
        }
    }
}
