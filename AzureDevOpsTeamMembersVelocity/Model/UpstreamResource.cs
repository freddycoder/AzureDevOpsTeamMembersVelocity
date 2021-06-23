using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class UpstreamResource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Protocol { get; set; }

        public string Location { get; set; }

        public string DisplayLocation { get; set; }

        public string UpstreamSourceType { get; set; }

        public string Status { get; set; }
    }
}