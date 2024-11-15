using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model;

/// <summary>
/// GitPullRequestCommentThread
/// </summary>
public class GitPullRequestCommentThread
{
    public List<PRComment> Comments { get; set; }
}

public class PRComment
{
    public UserObj Author { get; set; } = new UserObj();

    public string? Content { get; set; }
}