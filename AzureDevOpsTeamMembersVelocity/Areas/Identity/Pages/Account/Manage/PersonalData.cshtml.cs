using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Personal data page model
    /// </summary>
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="userManager"></param>
        public PersonalDataModel(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Append personal data page is GET
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }
    }
}