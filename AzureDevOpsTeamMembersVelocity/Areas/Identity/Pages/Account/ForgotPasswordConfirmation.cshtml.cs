using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Forgat password confirmation page model
    /// </summary>
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        /// <summary>
        /// Append when the forgot password confirmation page is GET
        /// </summary>
        public void OnGet()
        {
        }
    }
}
