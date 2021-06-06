using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// The object used to deserialize list response from the Azure DevOps REST API.
    /// </summary>
    /// <typeparam name="T">Type of the resource</typeparam>
    public class ListResponse<T>
    {
        /// <summary>
        /// The quantity of element
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The list of resource
        /// </summary>
        public List<T>? Value { get; set; }
    }
}
