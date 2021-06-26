using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    public class NugetPageSettings
    {
        public string? Organisation { get; set; }

        public string? TeamProject { get; set; }

        public string? Feed { get; set; }

        public string? SearchTerm { get; set; }

        public bool OnlyAlpha { get; set; }
    }
}
