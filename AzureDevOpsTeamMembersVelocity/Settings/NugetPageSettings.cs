using System.ComponentModel.DataAnnotations;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    public class NugetPageSettings : AbstractSettings
    {
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
