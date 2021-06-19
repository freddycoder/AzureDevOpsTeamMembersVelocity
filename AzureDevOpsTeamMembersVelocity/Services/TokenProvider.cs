using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; }
        public string Cookie { get; set; }

    }

    public class InitialApplicationState
    {
        public string XsrfToken { get; set; }
        public string Cookie { get; set; }

    }
}
