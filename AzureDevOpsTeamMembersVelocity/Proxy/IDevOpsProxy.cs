using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    /// <summary>
    /// Interface of to represent a Azure DevOps Proxy
    /// </summary>
    public interface IDevOpsProxy
    {
        /// <summary>
        /// Get the body of a request as a string
        /// </summary>
        /// <param name="fullUrl">The full url of the devops resource</param>
        /// <returns>The body as a string</returns>
        Task<(string?, string?)> GetAsync(string fullUrl);

        /// <summary>
        /// Get and deserialize a resource
        /// </summary>
        /// <typeparam name="T">Type of the resource</typeparam>
        /// <param name="fullUrl">The full url of the devops resource</param>
        /// <returns>An instance of the response deserialize</returns>
        Task<(T?, string?)> GetAsync<T>(string fullUrl);
    }
}
