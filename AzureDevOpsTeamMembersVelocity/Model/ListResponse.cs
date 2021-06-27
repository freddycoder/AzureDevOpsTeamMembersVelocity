using AzureDevOpsTeamMembersVelocity.Model;
using System;
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

        /// <summary>
        /// Allow implicit convertion off tupple using ListResponse as first item.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator ListResponse<T>?((ListResponse<T>?, string?) v)
        {
            return v.Item1;
        }
    }
}
