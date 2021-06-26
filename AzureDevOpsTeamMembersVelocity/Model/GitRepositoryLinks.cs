namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class GitRepositoryLinks
    {
        public HrefObject Self { get; set; }

        public HrefObject Project { get; set; }

        public HrefObject Web { get; set; }

        public HrefObject Ssh { get; set; }

        public HrefObject Commits { get; set; }

        public HrefObject Refs { get; set; }

        public HrefObject PullRequests { get; set; }

        public HrefObject Items { get; set; }

        public HrefObject Pushes { get; set; }
    }
}