using System;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// Team project resource of the Azure DevOps REST API
    /// </summary>
    public class TeamProject
    {
        /// <summary>
        /// Id of the TeamProject
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Name of the team project
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Url of the TeamProject
        /// </summary>
        public string? Url { get; set; }
        
        /// <summary>
        /// State of the TeamProject
        /// </summary>
        public string? State { get; set; }
        
        /// <summary>
        /// Revision of the TeamProject
        /// </summary>
        public int Revision { get; set; }
        
        /// <summary>
        /// Visibility of the team project
        /// </summary>
        public string? Visibility { get; set; }

        /// <summary>
        /// Last time updated
        /// </summary>
        public DateTimeOffset LastUpdateTime { get; set; }
    }
}
