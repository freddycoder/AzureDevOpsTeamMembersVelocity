namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Abstract settings class use to represent a settings class. Mainly used to represent user settings or preferences.
    /// </summary>
    public abstract class AbstractSettings
    {
        /// <summary>
        /// Boolean used to indicate if the settings instance as changed. 
        /// Implementers should update this value in setters of properties.
        /// </summary>
        protected bool _asChanged;

        /// <summary>
        /// Tell if the settings instance as changed
        /// </summary>
        public bool AsChanged()
        {
            return _asChanged;
        }

        /// <summary>
        /// Tell if the settings instance as not changed
        /// </summary>
        public bool AsNotChanged()
        {
            return !_asChanged;
        }

        /// <summary>
        /// Class that store settings should call this function ater saving the settings
        /// to help reduce number of I/O operation
        /// </summary>
        public void Saved()
        {
            _asChanged = false;
        }
    }
}
