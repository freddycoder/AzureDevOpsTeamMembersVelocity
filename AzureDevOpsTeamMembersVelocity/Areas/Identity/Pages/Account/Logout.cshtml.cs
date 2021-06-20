using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AzureDevOpsTeamMembersVelocity.Services;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Logout page model
    /// </summary>
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly AuthUrlPagesProvider _authUrlProvider;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="logger"></param>
        /// <param name="authUrlPages"></param>
        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, AuthUrlPagesProvider authUrlPages)
        {
            _signInManager = signInManager;
            _logger = logger;
            _authUrlProvider = authUrlPages;
        }

        /// <summary>
        /// Append when logout page is GET
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Append on POST of Logout page. Logout the user. This method is use in the Identity and AzureAD authentication method.
        /// </summary>
        /// <param name="returnUrl">Url to redirect to after user is logout</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect($"{_authUrlProvider.LoginPage}?returnUrl=/");
            }
        }
    }
}
