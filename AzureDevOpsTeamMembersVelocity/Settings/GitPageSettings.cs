namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Settings of the Git page
    /// </summary>
    public class GitPageSettings : AbstractSettings
    {
        /// <summary>
        /// Name of the repository
        /// </summary>
        public string? Repository 
        {
            get => _repository;
            set
            {
                _asChanged |= _repository != value;
                _repository = value;
            }
        }

        private string? _repository;

        /// <summary>
        /// The ID of the pull request
        /// </summary>
        public int? PullRequest 
        {
            get => _pullRequest;
            set
            {
                _asChanged |= _pullRequest != value;
                _pullRequest = value;
            }
        }

        private int? _pullRequest;
    }
}
