using System.ComponentModel.DataAnnotations;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    public class NugetPageSettings
    {
        [StringLength(256, ErrorMessage = "Organisation is too long.")]
        public string? Organisation { get; set; }

        [StringLength(64, ErrorMessage = "TeamProject is too long.")]
        public string? TeamProject { get; set; }

        public string? Feed { get; set; }

        public string? SearchTerm { get; set; }

        public bool OnlyAlpha { get; set; }
    }
}
