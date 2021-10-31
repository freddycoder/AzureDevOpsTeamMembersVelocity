using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Represent a package nuget from the Azure DevOps REST API
    /// </summary>
    public class Nuget
    {
        /// <summary>
        /// The id of the nuget
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The normalized name
        /// </summary>
        public string? NormalizedName { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Protocole type ex: nuget, npm, etc.
        /// </summary>
        public string? ProtocolType { get; set; }

        /// <summary>
        /// The url
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// List of version of the nuget
        /// </summary>
        public List<NugetVersion>? Versions { get; set; }

        /// <summary>
        /// Links related to the package
        /// </summary>
        [JsonPropertyName("_links")]
        public NugetLinks? Links { get; set; }
    }
}
