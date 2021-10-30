namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Settings for the kubernetes page
    /// </summary>
    public class KubernetesPageSettings : AbstractSettings
    {
        private string? _namespaceCollapseClass;

        /// <summary>
        /// Collapse the namespaces section
        /// </summary>
        public string? NamespaceCollapseClass 
        {
            get => _namespaceCollapseClass;
            set
            {
                _asChanged |= _namespaceCollapseClass != value;
                _namespaceCollapseClass = value;
            }
        }

        private string? _deploymentCollapseClass;

        /// <summary>
        /// Collapse the deployments section
        /// </summary>
        public string? DeploymentCollapseClass 
        {
            get => _deploymentCollapseClass;
            set 
            {
                _asChanged |= _deploymentCollapseClass != value;
                _deploymentCollapseClass = value;
            }
        }

        private string? _podsCollapseClass;

        /// <summary>
        /// Collapse the pods section
        /// </summary>
        public string? PodsCollapseClass 
        {
            get => _podsCollapseClass;
            set 
            {
                _asChanged |= _podsCollapseClass != value;
                _podsCollapseClass = value;
            }
        }
    }
}
