using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class SprintAttribute
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }
        public string TimeFrame { get; set; }
    }
}