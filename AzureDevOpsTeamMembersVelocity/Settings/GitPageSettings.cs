using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Settings of the Git page
    /// </summary>
    public class GitPageSettings : AbstractSettings
    {
        /// <summary>
        /// Name of the repository
        /// </summary>
        [Obsolete]
        public string? Repository 
        {
            get => _repository;
            set
            {
                _asChanged |= _repository != value;
                _repository = value;
            }
        }

        private string? _repository;

        /// <summary>
        /// List of selected repository
        /// </summary>
        public IReadOnlyCollection<string>? SelectedRepositories 
        {
            get => _selectedRepositories;
            set
            {
                _asChanged |= _selectedRepositories != value;
                _selectedRepositories = value;
            }
        }

        private IReadOnlyCollection<string>? _selectedRepositories;

        /// <summary>
        /// The ID of the pull request
        /// </summary>
        public int? PullRequest 
        {
            get => _pullRequest;
            set
            {
                _asChanged |= _pullRequest != value;
                _pullRequest = value;
            }
        }

        private int? _pullRequest;
    }
}
