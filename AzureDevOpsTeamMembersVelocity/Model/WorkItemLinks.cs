namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class WorkItemLinks
    {
        public HrefObject Self { get; set; }

        public HrefObject WorkItemUpdates { get; set; }
        
        public HrefObject WorkItemRevisions { get; set; }

        public HrefObject WorkItemComments { get; set; }

        public HrefObject Html { get; set; }

        public HrefObject WorkItemType { get; set; }

        public HrefObject Fields { get; set; }
    }
}