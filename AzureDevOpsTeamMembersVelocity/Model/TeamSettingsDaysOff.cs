using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model;

public class TeamSettingsDaysOff
{
    public List<DayOff>? DaysOff { get; set; }
}

public class DayOff
{
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
}