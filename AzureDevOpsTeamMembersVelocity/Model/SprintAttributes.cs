using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// The attributes of a sprint
    /// </summary>
    public class SprintAttributes
    {
        /// <summary>
        /// Start date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Finish date
        /// </summary>
        public DateTimeOffset? FinishDate { get; set; }

        /// <summary>
        /// TimeFrame, current, past.
        /// </summary>
        public string? TimeFrame { get; set; }
    }
}