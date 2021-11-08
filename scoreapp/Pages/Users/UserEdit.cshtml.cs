using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using scoreapp.model.enums;

namespace scoreapp.Pages.Users
{
    [Authorize(Policy = "UsersEdit")]
    public class UserEditModel : PageModel
    {
        private readonly IUsers _userService;
        private readonly ILogger<UserEditModel> _log;
        [BindProperty]
        public User data { get; set; }
        public List<SelectListItem> TypeUser { get; set; }
        public readonly IHtmlHelper _helper;
        public UserEditModel(IUsers userService, IHtmlHelper helper, ILogger<UserEditModel> log)
        {
            _userService = userService;
            _helper = helper;
            _log = log;
        }
        public void OnGet(int Id)
        {
            data = _userService.edit(Id);
            TypeUser = _helper.GetEnumSelectList<Type_User>().ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    data = _userService.Update(data);
                    bool result = Convert.ToBoolean(await _userService.SaveChangesAsync());
                    if (result)
                    {
                        TempData["Message"] = new string[] { "Good job",$"El usuario {data.DisplayName} ha sido modificado.","success"};
                        return Redirect("/cfb24a38-05ba-4155-8727-a1e3301af9f2");
                    }
                }
                TypeUser = _helper.GetEnumSelectList<Type_User>().ToList();
                return Page();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                TypeUser = _helper.GetEnumSelectList<Type_User>().ToList();
                return Page();
            }
        }
    }
}
