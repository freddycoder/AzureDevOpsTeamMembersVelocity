using AzureDevOpsTeamMembersVelocity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Environment;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class AddAuthentificationExtension
    {
        public static IServiceCollection AddTeamMemberVelocityAutorisation(this IServiceCollection services)
        {
            if (IsCookieAuth() && IsIdentityAuth())
            {
                throw new InvalidProgramException("You cannot use cookie user and identity at the same time. See the github wiki for more information.");
            }

            if (IsCookieAuth())
            {
                services.AddSingleton(new AuthUrlPagesProvider(CookieAuthenticationDefaults.AuthenticationScheme));

                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                        .AddCookie();
            }
            else if (IsIdentityAuth())
            {
                services.AddSingleton(new AuthUrlPagesProvider("Identity.Application"));

                services.AddAuthentication("Identity.Application")
                        .AddCookie();
            }
            else
            {
                services.AddSingleton(new AuthUrlPagesProvider(""));

                throw new NotImplementedException("Need to register an authentication handler");
            }

            services.AddScoped<TokenProvider>();

            return services;
        }

        private static bool IsIdentityAuth()
        {
            return string.Equals(GetEnvironmentVariable("USE_IDENTITY"), bool.TrueString, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsCookieAuth()
        {
            return string.IsNullOrWhiteSpace(GetEnvironmentVariable("COOKIEAUTH_USER")) == false;
        }
    }
}
