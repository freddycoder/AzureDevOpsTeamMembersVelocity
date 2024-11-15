using System;

namespace AzureDevOpsTeamMembersVelocity.Model;

/// <summary>
/// TeamSetting
/// </summary>
public class TeamSetting
{
    /// <summary>
    /// WorkingDays of a week
    /// </summary>
    public DayOfWeek[]? WorkingDays { get; set; }
}
