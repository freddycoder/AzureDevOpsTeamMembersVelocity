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

        public string Board { get; set; }

        public string ApiKey { get; set; }
    }
}