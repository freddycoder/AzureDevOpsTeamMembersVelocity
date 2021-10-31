using AzureDevOpsTeamMembersVelocity.Model;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    /// <summary>
    /// interface to access information about velocity of team member
    /// </summary>
    public interface IVelocityRepository
    {
        /// <summary>
        /// TryGet the list of velocity information base on a sprint url
        /// </summary>
        /// <param name="sprintUrl"></param>
        /// <param name="memberVelocities"></param>
        /// <returns></returns>
        bool TryGet(string sprintUrl, out IEnumerable<MemberVelocity>? memberVelocities);

        /// <summary>
        /// Save the list of velocty information given a sprint url
        /// </summary>
        /// <param name="sprintUrl"></param>
        /// <param name="memberVelocities"></param>
        void Save(string sprintUrl, IEnumerable<MemberVelocity> memberVelocities);
    }
}
