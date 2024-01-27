using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Areas.Identity;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string v1, string v2);
}

public class EmailSender : IEmailSender
{
    public EmailSender()
    {
    }

    public Task SendEmailAsync(string email, string v1, string v2)
    {
        return Task.CompletedTask;
    }
}
