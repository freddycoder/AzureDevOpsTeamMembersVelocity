using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Reset password confirm page model
    /// </summary>
    [AllowAnonymous]
    public class ResetPasswordConfirmationModel : PageModel
    {
        /// <summary>
        /// Append when reset password confirmation model page is GET
        /// </summary>
        public void OnGet()
        {

        }
    }
}
