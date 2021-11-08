using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using scoreapp.model.enums;

namespace scoreapp.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAuthentication _auth;
        [BindProperty]
        [Required(ErrorMessage = "Es obligatorio ingresar la usuario para ingresar")]
        public string Username { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="Es obligatorio ingresar la contraseña del usuario")]
        public string Password { get; set; }

        public LoginModel(IAuthentication auth)
        {
            _auth = auth;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(string ReturnUrl = "./cfb24a38-05ba-4155-8727-a1e3301af9f2")
        {
            try
            {
                ReturnUrl = ReturnUrl.Equals("/") ? "./cfb24a38-05ba-4155-8727-a1e3301af9f2" : ReturnUrl;
                if (ModelState.IsValid)
                {
                    
                    return Redirect(CreateCookie(_auth.Login(Username, Password),ReturnUrl));
                    
                }
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Login", ex.Message);
                return Page();
            }
            
        }

        private string CreateCookie(User User, string ReturnUrl)
        {
            try
            {
                var Claims = new List<Claim>
                {
                    new Claim("Id",User.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, User.Username),
                    new Claim(ClaimTypes.Name, User.DisplayName),
                    new Claim(ClaimTypes.Email,User.Mail),
                    new Claim("TypeUser",User.TypeUser.ToString())

                };
                if (User.Role == null)
                    return "./Error";
                foreach (var permission in User.Role.Permissions)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, User.Role.Description));
                    if (permission != null)
                    {
                        Claims.Add(new Claim("Permission", permission.Permission.Description));
                    }


                }

                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principle = new ClaimsPrincipal(Identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principle, new AuthenticationProperties
                {
                    IsPersistent = true
                }).GetAwaiter().GetResult();
                return ReturnUrl;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
