using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class IdentityRef : Microsoft.VisualStudio.Services.WebApi.IdentityRef
    {
        [JsonPropertyName("descriptor")]
        public new string Descriptor { get; set; }
    }
}
