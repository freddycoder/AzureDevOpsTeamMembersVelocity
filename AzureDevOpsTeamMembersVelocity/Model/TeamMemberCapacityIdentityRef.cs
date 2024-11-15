using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model;

/// <summary>
/// TeamMemberCapacityIdentityRef
/// </summary>
public class TeamMemberCapacityIdentityRef
{
    /// <summary>
    /// TeamMember
    /// </summary>
    public TeamMember? TeamMember { get; set; }

    /// <summary>
    /// Activity
    /// </summary>
    public List<Activity>? Activities { get; set; }

    /// <summary>
    /// DaysOff
    /// </summary>
    public DayOff[]? DaysOff { get; set; }
}

/// <summary>
/// TeamMember
/// </summary>
public class TeamMember
{
    /// <summary>
    /// DisplayName
    /// </summary>
    public string? DisplayName { get; set; }
}

/// <summary>
/// Activity
/// </summary>
public class Activity
{
    /// <summary>
    /// CapacityPerDay
    /// </summary>
    public double? CapacityPerDay { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }
}