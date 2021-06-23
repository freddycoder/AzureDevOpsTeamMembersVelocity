using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// This is the main configuration of the app. 
    /// Those settings can be saved on disk using the persist button on the index.html page.
    /// </summary>
    public class TeamMembersVelocitySettings
    {
        /// <summary>
        /// Organization selected
        /// </summary>
        /// <remarks>
        /// Organisation corespond to the first parameter in the route. https://dev.azure.com/{organization}
        /// </remarks>
        [StringLength(256, ErrorMessage = "Organisation is too long.")]
        public string? Organisation { get; set; }

        /// <summary>
        /// Team project selected
        /// </summary>
        /// <remarks>
        /// Organisation corespond to the first parameter in the route. https://dev.azure.com/{organization}/{teamProject}
        /// </remarks>
        [StringLength(64, ErrorMessage = "TeamProject is too long.")]
        public string? TeamProject { get; set; }

        /// <summary>
        /// Team selected
        /// </summary>
        [StringLength(64, ErrorMessage = "Team is too long.")]
        public string? Team { get; set; }

        private string? _apiKey;
        private bool _authKeyChanged;
        private AuthenticationHeaderValue? _authenticationHeader;

        /// <summary>
        /// The ApiKey of the user
        /// </summary>
        [StringLength(256, ErrorMessage = "ApiKey is too long.")]
        public string? ApiKey 
        { 
            get
            {
                return _apiKey;
            }
            set
            {
                _apiKey = value;
                _authKeyChanged = true;
            }
        }

        /// <summary>
        /// Return the Authentication header object that can be used 
        /// by assigned this property to the Authorization property of
        /// <see cref="HttpClient.DefaultRequestHeaders" />
        /// the Azure DevOps REST API
        /// </summary>
        [JsonIgnore]
        public AuthenticationHeaderValue? AuthenticationHeader
        {
            get
            {
                if (_authKeyChanged)
                {
                    _authenticationHeader = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", _apiKey))));

                    _authKeyChanged = false;
                }

                return _authenticationHeader;
            }
        }
    }
}