using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace AzureDevOpsTeamMembersVelocity.Controllers
{
    /// <summary>
    /// Controller used to manage redirection with Microsoft to login and logout users
    /// </summary>
    [Route("[controller]/[action]")]
    public class AzureADController : ControllerBase
    {
        /// <summary>
        /// Login method to handle Microsoft authentication
        /// </summary>
        /// <param name="returnUrl">The returnUrl use after the microsoft authentication is completed</param>
        [HttpGet]
        public async Task<ActionResult> Login(string returnUrl)
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = returnUrl
            };

            var result = await Task.Run(() => Challenge(props));

            return result;
        }
    }
}
