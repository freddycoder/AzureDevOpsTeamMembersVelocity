using Newtonsoft.Json.Linq;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    /// <summary>
    /// Extension to help to work with JSON data
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// Transform a string a formatted JSON string
        /// </summary>
        /// <exception cref="Newtonsoft.Json.JsonReaderException"></exception>
        public static string FormatJson(this string json)
        {
            return JObject.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
