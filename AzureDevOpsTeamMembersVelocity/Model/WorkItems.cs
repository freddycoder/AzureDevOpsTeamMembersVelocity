using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class WorkItems
    {
        public string Url { get; set; }

        public List<WorkItemLink> WorkItemRelations { get; set; }
    }
}
