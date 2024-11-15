using System;

namespace AzureDevOpsTeamMembersVelocity.Model;

/// <summary>
/// GitPullRequest
/// </summary>
public class GitPullRequest
{
    /// <summary>
    /// PullRequestId
    /// </summary>
    public int? PullRequestId { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// CreatedBy
    /// </summary>
    public UserObj CreatedBy { get; set; } = new UserObj();

    /// <summary>
    /// CreationDate
    /// </summary>
    public DateTimeOffset CreationDate { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Git Repository
    /// </summary>
    public GitRepository Repository { get; set; } = new GitRepository();
}
