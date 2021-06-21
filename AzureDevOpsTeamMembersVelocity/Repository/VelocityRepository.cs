using AzureDevOpsTeamMembersVelocity.Model;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    public class VelocityRepository : IVelocityRepository
    {
        private readonly Dictionary<string, IEnumerable<MemberVelocity>> _memory;

        public VelocityRepository()
        {
            _memory = new Dictionary<string, IEnumerable<MemberVelocity>>();
        }

        public bool TryGet(string sprintUrl, out IEnumerable<MemberVelocity>? memberVelocities)
        {
            return _memory.TryGetValue(sprintUrl, out memberVelocities);
        }

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
