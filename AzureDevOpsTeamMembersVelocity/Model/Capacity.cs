using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Capacity : Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef
    {
        public Capacity()
        {
            
        }

        public new IdentityRef TeamMember { get; set; }
    }
}
