namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Work item links object
    /// </summary>
    public class WorkItemLinks
    {
        /// <summary>
        /// The work item URL
        /// </summary>
        public HrefObject? Self { get; set; }

        /// <summary>
        /// The work item updates URL
        /// </summary>
        public HrefObject? WorkItemUpdates { get; set; }

        /// <summary>
        /// The work item revisions URL
        /// </summary>
        public HrefObject? WorkItemRevisions { get; set; }

        /// <summary>
        /// The work comments URL
        /// </summary>
        public HrefObject? WorkItemComments { get; set; }

        /// <summary>
        /// The work item Html URL
        /// </summary>
        public HrefObject? Html { get; set; }

        /// <summary>
        /// The work item Type URL
        /// </summary>
        public HrefObject? WorkItemType { get; set; }

        /// <summary>
        /// The work item Fields URL
        /// </summary>
        public HrefObject? Fields { get; set; }
    }
}