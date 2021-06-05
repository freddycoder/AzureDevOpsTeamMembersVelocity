using Newtonsoft.Json.Linq;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class JsonExtension
    {
        public static string FormatJson(this string json)
        {
            return JObject.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
