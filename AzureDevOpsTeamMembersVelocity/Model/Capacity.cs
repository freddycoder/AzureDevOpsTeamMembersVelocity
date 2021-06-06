namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef"></inheritdoc>
    public class Capacity : Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef
    {
        /// <inheritdoc cref="Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef.TeamMember"></inheritdoc>
        public new IdentityRef? TeamMember { get; set; }
    }
}
