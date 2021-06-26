namespace AzureDevOpsTeamMembersVelocity.Repository
{
    public interface IUserPreferenceRepository
    {
        public T Get<T>();

        public void Set<T>(T settings);
    }
}
