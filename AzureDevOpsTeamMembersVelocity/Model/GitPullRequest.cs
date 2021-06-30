namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest" />
    public class GitPullRequest : Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest
    {
        /// <inheritdoc />
        public new IdentityRef? CreatedBy { get; set; }
    }
}
