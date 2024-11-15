using System.Text.Json;

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
        public static string FormatJson(this string json)
        {
            return JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(json), new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
