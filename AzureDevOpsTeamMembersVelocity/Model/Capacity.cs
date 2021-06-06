namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Capacity : Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef
    {
        public new IdentityRef TeamMember { get; set; }
    }
}
