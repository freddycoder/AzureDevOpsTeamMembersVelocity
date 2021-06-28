namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Abstract settings class use to represent a settings class. Mainly used to represent user settings or preferences.
    /// </summary>
    public abstract class AbstractSettings
    {
        protected bool _asChanged;

        public bool AsChanged()
        {
            return _asChanged;
        }

        public void Saved()
        {
            _asChanged = false;
        }
    }
}
