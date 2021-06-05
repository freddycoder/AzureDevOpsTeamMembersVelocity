using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class MemberVelocity
    {
        public string DisplayName { get; set; }

        public double HoursOfWorkDone { get; set; }

        public double CapacitySaved { get; set; }

        public double RealCapacity { get; set; }

        public List<WorkItemUpdate> Updates { get; } = new List<WorkItemUpdate>();
    }
}
