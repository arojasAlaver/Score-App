using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;

namespace scoreapp.Pages.Users
{

    public class UserRoleModel : PageModel
    {
        private readonly IUsers _service;
        [BindProperty]
        public Guid RoleId { get; set; }
        [BindProperty]
        public User data { get; set; }
        public List<Role> Roles { get; set; }
        public UserRoleModel(IUsers service)
        {
            _service = service;
        }
        public void OnGet(int Id)
        {
            data = _service.Get(Id);
            Roles = _service.Get();
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _service.Post(data,RoleId);
                TempData["Message"] = new string[] { "Good job","La asignación de role ha sido existosa","success"};
                return Redirect("/cfb24a38-05ba-4155-8727-a1e3301af9f2");
            }
            return Page();
        }
    }
}
