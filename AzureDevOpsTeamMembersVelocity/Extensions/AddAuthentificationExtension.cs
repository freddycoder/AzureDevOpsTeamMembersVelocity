using AzureDevOpsTeamMembersVelocity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Environment;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class AddAuthentificationExtension
    {
        public static IServiceCollection AddTeamMemberVelocityAutorisation(this IServiceCollection services)
        {
            if (string.IsNullOrWhiteSpace(GetEnvironmentVariable("COOKIEAUTH_USER")) == false)
            {
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                        .AddCookie();
            }
            else
            {
                throw new NotImplementedException();    
            }

            services.AddScoped<TokenProvider>();

            return services;
        }
    }
}
