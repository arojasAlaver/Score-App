using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace scoreapp.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {

            HttpContext.SignOutAsync().GetAwaiter().GetResult();
            return Redirect("/75e56f57-3036-460f-b3c4-d3789e0fd5fc");
        }
    }
}
