namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Settings for the kubernetes page
    /// </summary>
    public class KubernetesPageSettings : AbstractSettings
    {
        /// <summary>
        /// Collapse the namespaces section
        /// </summary>
        public string? NamespaceCollapseClass { get; set; }

        /// <summary>
        /// Collapse the deployments section
        /// </summary>
        public string? DeploymentCollapseClass { get; set; }

        /// <summary>
        /// Collapse the pods section
        /// </summary>
        public string? PodsCollapseClass { get; set; }
    }
}
