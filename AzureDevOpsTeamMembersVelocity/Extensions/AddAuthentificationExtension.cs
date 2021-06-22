using AzureDevOpsTeamMembersVelocity.Autorization;
using AzureDevOpsTeamMembersVelocity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using System;
using static System.Environment;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    /// <summary>
    /// Class that handle the authorization configuration of the app.
    /// 
    /// There or 4 possible mode of authentication.
    /// 1. No auth, if there is nothing configure about the authorization, then the app will work without any auth.
    /// 2. CookieAuth, if there is a COOKIEAUTH_USER defined. Then this user will have to login to use the app. You can set a passwork with the COOKIE_PASSWORD environment variable.
    /// 3. Identity, if the environment variable USE_IDENTITY is set to true, Microsoft.Identity will be use with SqLite database.
    /// 4. Microsoft account, if the environemtn variable MicrosoftId is initialised, then Microsoft account is going to be used. MicrosoftId represent the ClientId and MicrosoftSecret is the secret create in the AzureAD client credentials section.
    /// </summary>
    /// <remarks>
    /// You can use only one authentication method at the time, otherwise the application will throw and InvalidProgramException
    /// </remarks>
    public static class AddAuthentificationExtension
    {
        /// <exception cref="InvalidProgramException" />
        public static IServiceCollection AddTeamMemberVelocityAutorisation(this IServiceCollection services, IConfiguration configuration)
        {
            if (OnlyOneAuthMethodIsUsed() == false)
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
            else if (IsAzureADAuth())
            {
                services.AddSingleton(new AuthUrlPagesProvider("AzureAD"));

                // Support for kubernetes
                // Colon is not allow in environement variable name
                if (string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD:ClientId")) && string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD__ClientId")) == false)
                {
                    configuration["AzureAD:ClientId"] = GetEnvironmentVariable("AzureAD__ClientId");
                }

                if (string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD:TenantId")) && string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD__TenantId")) == false)
                {
                    configuration["AzureAD:TenantId"] = GetEnvironmentVariable("AzureAD__TenantId");
                }

                services.AddMicrosoftIdentityWebAppAuthentication(configuration);
            }
            else
            {
                services.AddSingleton(new AuthUrlPagesProvider(""));

                services.AddSingleton<IHostEnvironmentAuthenticationStateProvider, AllowAnonymousStateProvider>();
                services.AddSingleton<IAuthorizationHandler, AllowAnonymousAuthorizationHandler>();
            }

            services.AddScoped<TokenProvider>();

            return services;
        }

        /// <summary>
        /// Method use to validate the configuration of the app. Only one method should be identify.
        /// </summary>
        /// <returns></returns>
        public static bool OnlyOneAuthMethodIsUsed()
        {
            int count = 0;

            if (IsCookieAuth()) count++;

            if (IsIdentityAuth()) count++;

            if (IsAzureADAuth()) count++;

            return count <= 1;
        }

        /// <summary>
        /// Indicate if the AzureAD authentication mecanism is configure
        /// </summary>
        /// <returns></returns>
        public static bool IsAzureADAuth()
        {
            if (string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD:TenantId")) &&
                string.IsNullOrWhiteSpace(GetEnvironmentVariable("AzureAD__TenantId")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Indicate if the self-hosted Identity authentication mecanism is configure
        /// </summary>
        /// <returns></returns>
        public static bool IsIdentityAuth()
        {
            return string.Equals(GetEnvironmentVariable("USE_IDENTITY"), bool.TrueString, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicate if the environment user cookie authentication mecanism is configure
        /// </summary>
        /// <returns></returns>
        public static bool IsCookieAuth()
        {
            return string.IsNullOrWhiteSpace(GetEnvironmentVariable("COOKIEAUTH_USER")) == false;
        }
    }
}
