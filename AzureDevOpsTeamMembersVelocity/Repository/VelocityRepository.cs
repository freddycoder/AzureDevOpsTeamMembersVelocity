using AzureDevOpsTeamMembersVelocity.Model;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    /// <summary>
    /// An in memory implementation of the IVelocityRepository interface.
    /// Allow to keep Velocity model processed in memory.
    /// </summary>
    public class VelocityRepository : IVelocityRepository
    {
        private readonly Dictionary<string, IEnumerable<MemberVelocity>> _memory;

        /// <summary>
        /// Default constructor that initialise his memory
        /// </summary>
        public VelocityRepository()
        {
            _memory = new Dictionary<string, IEnumerable<MemberVelocity>>();
        }

        /// <summary>
        /// Try get the data associate with the sprint URL. Retour true
        /// if the data is found otherwise false.
        /// </summary>
        /// <param name="sprintUrl">The sprint url as return by the Azure DevOps REST API</param>
        /// <param name="memberVelocities">The list of MemberVelocity of the sprint</param>
        /// <returns></returns>
        public bool TryGet(string sprintUrl, out IEnumerable<MemberVelocity>? memberVelocities)
        {
            return _memory.TryGetValue(sprintUrl, out memberVelocities);
        }

        /// <summary>
        /// Save the sprint. The value in memory will be overwriten if it
        /// was already there.
        /// </summary>
        /// <param name="sprintUrl"></param>
        /// <param name="memberVelocities"></param>
        public void Save(string sprintUrl, IEnumerable<MemberVelocity> memberVelocities)
        {
            if (TryGet(sprintUrl, out var _))
            {
                _memory[sprintUrl] = memberVelocities;
            }
            else
            {
                _memory.Add(sprintUrl, memberVelocities);
            }
        }
    }
}
