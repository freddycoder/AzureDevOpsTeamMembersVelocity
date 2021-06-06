namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Links related to a sprint
    /// </summary>
    public class SprintLinks
    {
        /// <summary>
        /// Link of the sprint itself
        /// </summary>
        public HrefObject? Self { get; set; }

        /// <summary>
        /// Link of the project of the sprint
        /// </summary>
        public HrefObject? Project { get; set; }

        /// <summary>
        /// Link of the team
        /// </summary>
        public HrefObject? Team { get; set; }

        /// <summary>
        /// The team settings link
        /// </summary>
        public HrefObject? TeamSettings { get; set; }

        /// <summary>
        /// The link of the iterations
        /// </summary>
        public HrefObject? TeamIterations { get; set; }

        /// <summary>
        /// Link to get capacity information of the sprint
        /// </summary>
        public HrefObject? Capacity { get; set; }

        /// <summary>
        /// Link to get related work item
        /// </summary>
        public HrefObject? Workitems { get; set; }

        /// <summary>
        /// The classification node of the sprint
        /// </summary>
        public HrefObject? ClassificationNode { get; set; }

        /// <summary>
        /// Link to get days off of the sprint
        /// </summary>
        public HrefObject? TeamDaysOff { get; set; }
    }
}
