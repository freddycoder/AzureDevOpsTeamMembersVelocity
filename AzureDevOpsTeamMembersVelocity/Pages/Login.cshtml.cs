using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AzureDevOpsTeamMembersVelocity.Pages
{
    /// <summary>
    /// The Login model page used when the app is in environment variable user mode
    /// </summary>
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        
        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="configuration"></param>
        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The Email enter by the user in the form
        /// </summary>
        [BindProperty]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// The password enter by the user in the form
        /// </summary>
        [BindProperty]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Append on get
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Append on post
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (Email == null)
            {
                ModelState.AddModelError(nameof(Email), "Email is required");

                return Page();
            }

            var user = _configuration.GetValue<string>("COOKIEAUTH_USER");
            var password = _configuration.GetValue<string>("COOKIEAUTH_PASSWORD");

            if (!(Email == user &&
                  Password == password))
            {
                ModelState.AddModelError("", "Wrong username or password");

                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Email, Email)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(Url.Content("~/"));
        }
    }
}