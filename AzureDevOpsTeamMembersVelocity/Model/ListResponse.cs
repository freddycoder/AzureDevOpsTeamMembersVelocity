using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity
{
    public class ListResponse<T>
    {
        public int Count { get; set; }

        public List<T> Value { get; set; }
    }
}
