using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Les configurations de la page Kubernetes
    /// </summary>
    public class KubernetesPageSettings : AbstractSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string? NamespaceCollapseClass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? DeploymentCollapseClass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? PodsCollapseClass { get; set; }
    }
}
