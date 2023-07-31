using CookieAuthDemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieAuthDemo.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserSignIn UserSignIn { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // let username and password matches
                // check it here 
                // then we create claims principal
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, UserSignIn.Name));
                claims.Add(new Claim("Password", UserSignIn.Password));
                claims.Add(new Claim(ClaimTypes.Role, UserSignIn.Role));

                var ci = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principle = new ClaimsPrincipal(ci);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return LocalRedirect(returnUrl);
            }
            else
            {
                //ModelState.Clear();
            }
            return Page();
        }

        public void OnGet()
        {
            TempData["role"] = "admin";
        }
    }
}
