using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Autorization
{
    /// <summary>
    /// When no authentification method is configured. This authorization handler is used.
    /// </summary>
    public class AllowAnonymous : IAuthorizationHandler
    {
        /// <inheritdoc />
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var requirement in context.PendingRequirements)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
