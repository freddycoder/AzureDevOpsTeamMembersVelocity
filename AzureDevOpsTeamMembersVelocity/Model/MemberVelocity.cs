using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// MemberVelocity is the model used to display stat about the velocity of a member.
    /// </summary>
    public class MemberVelocity : IComparable<MemberVelocity>
    {
        /// <summary>
        /// The name of the member
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// The hours of work done. Normally calculated from the History according to the member.
        /// </summary>
        public double HoursOfWorkDone { get; set; }

        /// <summary>
        /// The capacity saved. Normally based on the response of the Capacity REST API.
        /// </summary>
        public double CapacitySaved { get; set; }

        /// <summary>
        /// Estimated calculation of the real capacity of a member. 
        /// </summary>
        public double RealCapacity { get; set; }

        /// <summary>
        /// List of WorkItemUpdate associate to this member
        /// </summary>
        public List<WorkItemUpdate> Updates { get; } = new List<WorkItemUpdate>();

        /// <summary>
        /// Comparer MemberVelocity by HoursOfWorkDone
        /// </summary>
        public int CompareTo(MemberVelocity? other)
        {
            return HoursOfWorkDone.CompareTo(other?.HoursOfWorkDone ?? 0.0) * -1;
        }
    }
}
