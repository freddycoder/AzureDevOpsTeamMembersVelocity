using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public SprintAttribute? Attributes { get; set; }
        public string? Url { get; set; }

        [JsonPropertyName("_links")]
        public SprintLinks? Links { get; set; }

        public double GetTotalDays()
        {
            if (Attributes?.StartDate == null ||
                Attributes?.FinishDate == null)
                return 0;

            return (Attributes.FinishDate.Value - Attributes.StartDate.Value).TotalDays;
        }

        public double GetTotalWorkingDays(DayOfWeek[]? workingDays, TeamDaysOff? teamDaysOff)
        {
            var initial = GetTotalDays();
            
            if (workingDays != null)
            {
                for (int i = 0; i < initial; i++)
                {
                    if (Attributes != null && Attributes.StartDate.HasValue == true)
                    {
                        var date = Attributes.StartDate.Value + TimeSpan.FromDays(i);

                        if (workingDays.Any(w => date.DayOfWeek == w) == false)
                        {
                            initial--;
                        }
                    }
                }
            }

            if (teamDaysOff?.DaysOff?.Any() == true)
                initial -= teamDaysOff.DaysOff.Select(d => (d.End - d.Start).TotalDays).Sum();


            return initial;
        }
    }
}
