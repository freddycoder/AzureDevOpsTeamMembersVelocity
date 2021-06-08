using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Representation of the sprint resource of the Azure DevOps API
    /// </summary>
    public class Sprint
    {
        /// <summary>
        /// Id of the sprint
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the sprint
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The Path of the sprint
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// The attributes of the sprint. Such as Start Date, Finish Date, and TimeFrame
        /// </summary>
        public SprintAttributes? Attributes { get; set; }

        /// <summary>
        /// The Url of the sprint
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Links related to the sprint
        /// </summary>
        [JsonPropertyName("_links")]
        public SprintLinks? Links { get; set; }

        /// <summary>
        /// Calculate the number of total days between the Start Date and the FinishDate
        /// </summary>
        /// <returns></returns>
        public double GetTotalDays()
        {
            if (Attributes?.StartDate == null ||
                Attributes?.FinishDate == null)
                return 0;

            return (Attributes.FinishDate.Value - Attributes.StartDate.Value).TotalDays;
        }

        /// <summary>
        /// Get total working days of a sprint. 
        /// </summary>
        /// <remarks>
        /// Ensure to pass non-null reference for each parameter. It will allow the function 
        /// to do the right calculation. Since each parameter ar consider if they are not null.
        /// </remarks>
        /// <param name="workingDays">List of working days</param>
        /// <param name="teamDaysOff">TeamDaysOff information</param>
        /// <returns>GetTotalDays() - days off</returns>
        public double GetTotalWorkingDays(DayOfWeek[]? workingDays, Microsoft.TeamFoundation.Work.WebApi.TeamSettingsDaysOff? teamDaysOff)
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
