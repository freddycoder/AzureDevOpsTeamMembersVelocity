using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public SprintAttribute Attribute { get; set; }
        public string Url { get; set; }
    }
}
