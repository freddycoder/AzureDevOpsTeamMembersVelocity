using AzureDevOpsTeamMembersVelocity.Autorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.Extensions.DependencyInjection;
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

                services.AddScoped<IHostEnvironmentAuthenticationStateProvider>(sp =>
                    (ServerAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());

            }
            else
            {
                services.AddScoped<AllowAnonymousStateProvider>();
                services.AddScoped<IHostEnvironmentAuthenticationStateProvider>(sp => sp.GetRequiredService<AllowAnonymousStateProvider>());
            }

            return services;
        }
    }
}
