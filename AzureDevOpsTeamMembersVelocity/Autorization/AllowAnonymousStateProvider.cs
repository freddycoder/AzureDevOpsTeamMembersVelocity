using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Autorization
{
    /// <summary>
    /// When no authentification method is configured. This authorization handler is used.
    /// </summary>
    public class AllowAnonymousStateProvider : AuthenticationStateProvider, IHostEnvironmentAuthenticationStateProvider
    {
        private static readonly AuthenticationState _user = InstanciateUser();

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(_user);
        }

        public void SetAuthenticationState(Task<AuthenticationState> authenticationStateTask)
        {

        }

        private static AuthenticationState InstanciateUser()
        {
            List<Claim> claims = new() { new Claim(ClaimTypes.Name, "User") };

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal user = new(claimsIdentity);

            return new AuthenticationState(user);
        }
    }
}
