using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// A work item graph
    /// </summary>
    public class WorkItems
    {
        /// <summary>
        /// Work item URL
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// List of related work item
        /// </summary>
        public List<WorkItemLink>? WorkItemRelations { get; set; }
    }

    /// <summary>
    /// WorkItemLink
    /// </summary>
    public class WorkItemLink
    {
        /// <summary>
        /// Source
        /// </summary>
        public UrlObj Source { get; set; } = new UrlObj();

        /// <summary>
        /// Target
        /// </summary>
        public UrlObj Target { get; set; } = new UrlObj();
    }

    /// <summary>
    /// UrlObj
    /// </summary>
    public class UrlObj
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;
    }
}
