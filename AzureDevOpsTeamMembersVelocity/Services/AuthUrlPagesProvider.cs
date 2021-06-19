using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class AuthUrlPagesProvider
    {
        public AuthUrlPagesProvider(string schema)
        {
            Schema = schema;
        }

        public string Schema { get; }

        public string LoginPage => Schema switch
        {
            CookieAuthenticationDefaults.AuthenticationScheme => "/Login",
            "Identity.Application" => "/identity/account/login",
            _ => "",
        };

        public string LogoutPage => Schema switch
        {
            CookieAuthenticationDefaults.AuthenticationScheme => "/Logout",
            "Identity.Application" => "/identity/account/logout",
            _ => "",
        };

        public bool IsIdentity => Schema == "Identity.Application";
    }
}
