using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;

namespace scoreapp.Pages.Users
{
    [Authorize(Policy = "Users")]
    public class UsersModel : PageModel
    {
        
        public List<User> Users { get; set; }
        private readonly IUsers _data;
        [TempData]
        public string[] Message { get; set; }
        public UsersModel(IUsers data)
        {
            _data = data;
        }
        public void OnGet()
        {
            
            
        }
    }
}
