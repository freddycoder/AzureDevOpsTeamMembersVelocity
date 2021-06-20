using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Lockout page model
    /// </summary>
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        /// <summary>
        /// Append when Lokout page is GET
        /// </summary>
        public void OnGet()
        {

        }
    }
}
