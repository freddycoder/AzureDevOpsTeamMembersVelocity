namespace AzureDevOpsTeamMembersVelocity.Settings
{
    public class GitPageSettings : AbstractSettings
    {
        public string? Repository 
        {
            get => _repository;
            set
            {
                _asChanged = _repository == value;
                _repository = value;
            }
        }

        private string? _repository;

        public int? PullRequest 
        {
            get => _pullRequest;
            set
            {
                _asChanged = _pullRequest == value;
                _pullRequest = value;
            }
        }

        private int? _pullRequest;
    }
}
