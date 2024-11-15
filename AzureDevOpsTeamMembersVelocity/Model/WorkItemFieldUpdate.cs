namespace AzureDevOpsTeamMembersVelocity.Model;

/// <summary>
/// WorkItemFieldUpdate
/// </summary>
public class WorkItemFieldUpdate
{
    /// <summary>
    /// OldValue
    /// </summary>
    public object? OldValue { get; set; }

    /// <summary>
    /// NewValue
    /// </summary>
    public object NewValue { get; set; } = new object();
}
