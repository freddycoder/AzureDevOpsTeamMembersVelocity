using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class NugetVersion
    {
        public Guid Id { get; set; }

        public string? NormalizedVersion { get; set; }

        public string? Version { get; set; }

        public bool IsListed { get; set; }

        public string? StorageId { get; set; }

        public List<NugetVersionView>? Views { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}