using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// The show recovery codes page model
    /// </summary>
    public class ShowRecoveryCodesModel : PageModel
    {
        [TempData]
        public string[]? RecoveryCodes { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        public IActionResult OnGet()
        {
            if (RecoveryCodes == null || RecoveryCodes.Length == 0)
            {
                return RedirectToPage("./TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
