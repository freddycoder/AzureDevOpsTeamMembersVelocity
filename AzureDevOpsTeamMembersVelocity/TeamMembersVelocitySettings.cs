using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// This is the main configuration of the appé Those settings can be saved on disc.
    /// </summary>
    public class TeamMembersVelocitySettings
    {
        public string Organisation { get; set; }

        public string TeamProject { get; set; }

        public string Team { get; set; }

        private string _apiKey;
        private bool _authKeyChanged;
        private AuthenticationHeaderValue _authenticationHeader;

        public string ApiKey 
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

        [JsonIgnore]
        public AuthenticationHeaderValue AuthenticationHeader
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