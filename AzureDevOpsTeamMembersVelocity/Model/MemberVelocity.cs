using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// MemberVelocity is the model used to display stat about the velocity of a member.
    /// </summary>
    public class MemberVelocity
    {
        /// <summary>
        /// The name of the member
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// The hours of work done. Normally calculated from the History according to the member.
        /// </summary>
        /// <remarks>
        /// This value is calculated from the sum of every update
        /// </remarks>
        public double HoursOfWorkDone { get; set; }

        /// <summary>
        /// Number of hours added that were not in the planning of the sprint.
        /// </summary>
        /// <remarks>
        /// This value is the sum of all negative hours changes
        /// </remarks>
        public double HoursAdded { get; set; }

        /// <summary>
        /// The number of hours removed by the team member. 
        /// </summary>
        /// <remarks>
        /// THis value is the sum of all positive hours changes
        /// </remarks>
        public double HoursRemoved { get; set; }

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
        /// Compare two object, if it is of type MemberVelocity, only the DisplayName is goind to be used. Otherwise it is the
        /// object.Equals(this, obj) that is going to be called
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is MemberVelocity velocity)
            {
                return DisplayName == velocity.DisplayName;
            }

            return object.Equals(this, obj);
        }

        /// <summary>
        /// Get the hashcode of the member velocity object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return DisplayName?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Return the name of the member velocity instance.
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return DisplayName;
        }
    }
}
