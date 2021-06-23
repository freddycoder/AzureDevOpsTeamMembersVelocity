using AzureDevOpsTeamMembersVelocity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    public interface IVelocityRepository
    {
        bool TryGet(string sprintUrl, out IEnumerable<MemberVelocity>? memberVelocities);

        void Save(string sprintUrl, IEnumerable<MemberVelocity> memberVelocities);
    }
}
