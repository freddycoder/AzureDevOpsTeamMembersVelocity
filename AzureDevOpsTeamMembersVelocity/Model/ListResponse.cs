using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity
{
    public class ListResponse<T>
    {
        public int Count { get; set; }

        public List<T>? Value { get; set; }
    }
}
