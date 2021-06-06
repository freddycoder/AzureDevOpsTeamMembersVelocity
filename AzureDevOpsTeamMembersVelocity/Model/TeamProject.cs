using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity
{
    public class TeamProject
    {
        public Guid Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Url { get; set; }
        
        public string? State { get; set; }
        
        public int Revision { get; set; }
        
        public string? Visibility { get; set; }

        public DateTimeOffset LastUpdateTime { get; set; }
    }
}
