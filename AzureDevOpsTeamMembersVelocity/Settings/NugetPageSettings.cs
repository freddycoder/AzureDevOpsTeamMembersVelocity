using System.ComponentModel.DataAnnotations;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Class to represent settings that are kept for a user in the Nuget page.
    /// </summary>
    public class NugetPageSettings : AbstractSettings
    {
        /// <summary>
        /// Name of the organization
        /// </summary>
        /// <remarks>
        /// https://dev.azure.com/{Organization}
        /// </remarks>
        [StringLength(256, ErrorMessage = "Organisation is too long.")]
        public string? Organisation 
        {
            get => _organization;
            set
            {
                _asChanged |= _organization != value;
                _organization = value;
            }
        }

        private string? _organization;

        /// <summary>
        /// The team project to query for feed. If empty the organisation will be queried
        /// </summary>
        [StringLength(64, ErrorMessage = "TeamProject is too long.")]
        public string? TeamProject 
        {
            get => _teamProject;
            set
            {
                _asChanged |= _teamProject != value;
                _teamProject = value;
            }
        }

        private string? _teamProject;

        /// <summary>
        /// The name of the feed
        /// </summary>
        [StringLength(256, ErrorMessage = "Feed is too long.")]
        public string? Feed 
        {
            get => _feed;
            set
            {
                _asChanged |= _feed != value;
                _feed = value;
            }
        }

        private string? _feed;

        /// <summary>
        /// The search term sent to the Azure DevOps REST API
        /// </summary>
        [StringLength(256, ErrorMessage = "SearchTerm is too long.")]
        public string? SearchTerm 
        {
            get => _searchTerm;
            set
            {
                _asChanged |= _searchTerm != value;
                _searchTerm = value;
            }
        }

        private string? _searchTerm;

        /// <summary>
        /// Indicator to display only the alpha version
        /// </summary>
        public bool OnlyAlpha 
        {
            get => _onlyAlpha;
            set
            {
                _asChanged |= _onlyAlpha != value;
                _onlyAlpha = value;
            }
        }

        private bool _onlyAlpha;
    }
}
