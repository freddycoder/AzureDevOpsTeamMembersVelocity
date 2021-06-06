using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class MemberVelocity : IComparable<MemberVelocity>
    {
        public string? DisplayName { get; set; }

        public double HoursOfWorkDone { get; set; }

        public double CapacitySaved { get; set; }

        public double RealCapacity { get; set; }

        public List<WorkItemUpdate> Updates { get; } = new List<WorkItemUpdate>();

        public int CompareTo(MemberVelocity? other)
        {
            return HoursOfWorkDone.CompareTo(other?.HoursOfWorkDone ?? 0.0) * -1;
        }
    }
}
