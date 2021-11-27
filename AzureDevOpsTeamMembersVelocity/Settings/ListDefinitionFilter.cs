using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
    /// <summary>
    /// Additional query string parameter for the ListDefinition action of the release section
    /// </summary>
    public class ListDefinitionFilter : AbstractSettings
    {
        private PropertyInfo[] Properties = typeof(ListDefinitionFilter).GetProperties();

        /// <summary>
        /// Append all non null property of the current class in the query string of the url
        /// </summary>
        /// <param name="url">The url to append query string parameter</param>
        public string AppendParameterToQueryString(string url)
        {
            var sb = new StringBuilder(url);

            for (int i = 0; i < Properties.Length; i++)
            {
                var value = Properties[i].GetValue(this);

                if (!string.IsNullOrWhiteSpace(value?.ToString()))
                {
                    sb.Append('&');

                    var displayName = Properties[i].GetCustomAttribute<DisplayNameAttribute>();

                    if (displayName != null)
                    {
                        sb.Append(displayName.DisplayName);
                    }
                    else
                    {
                        sb.Append(LowerCaseFirstLetter(Properties[i].Name));
                    }

                    sb.Append('=');

                    sb.Append(value);
                }
            }

            return sb.ToString();
        }

        private string LowerCaseFirstLetter(string name)
        {
            var sb = new StringBuilder();

            sb.Append(char.ToLower(name[0]));

            for (int i = 1; i < name.Length; i++)
            {
                sb.Append(name[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get release definitions with names containing searchText.
        /// </summary>
        public string? SearchText { get; set; }

        /// <summary>
        /// The properties that should be expanded in the list of Release definitions.
        /// </summary>
        [DisplayName("$expand")]
        public string? Expand { get; set; }

        /// <summary>
        /// Release definitions with given artifactType will be returned. 
        /// Values can be Build, Jenkins, GitHub, Nuget, Team Build (external), ExternalTFSBuild, Git, TFVC, ExternalTfsXamlBuild.
        /// </summary>
        public string? ArtifactType { get; set; }

        /// <summary>
        /// Release definitions with given artifactSourceId will be returned. e.g. 
        /// For build it would be {projectGuid}:{BuildDefinitionId}, for Jenkins it would be {JenkinsConnectionId}:{JenkinsDefinitionId}, for TfsOnPrem it would be {TfsOnPremConnectionId}:{ProjectName}:{TfsOnPremDefinitionId}. 
        /// For third-party artifacts e.g. TeamCity, BitBucket you may refer 'uniqueSourceIdentifier' inside vss-extension.json at https://github.com/Microsoft/vsts-rm-extensions/blob/master/Extensions.
        /// </summary>
        public string? ArtifactSourceId { get; set; }

        /// <summary>
        /// Number of release definitions to get.
        /// </summary>
        [DisplayName("$top")]
        public int? Top { get; set; }

        /// <summary>
        /// Gets the release definitions after the continuation token provided.
        /// </summary>
        public string? ContinuationToken { get; set; }

        /// <summary>
        /// Gets the results in the defined order. Default is 'IdAscending'.
        /// </summary>
        public string? QueryOrder { get; set; }

        /// <summary>
        /// Gets the release definitions under the specified path.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// 'true'to gets the release definitions with exact match as specified in searchText. Default is 'false'.
        /// </summary>
        public bool? IsExactNameMatch { get; set; }

        /// <summary>
        /// A comma-delimited list of tags. Only release definitions with these tags will be returned.
        /// </summary>
        public string? TagFilter { get; set; }

        /// <summary>
        /// A comma-delimited list of extended properties to be retrieved. 
        /// If set, the returned Release Definitions will contain values for the specified property Ids (if they exist). 
        /// If not set, properties will not be included. 
        /// Note that this will not filter out any Release Definition from results irrespective of whether it has property set or not.
        /// </summary>
        public string? PropertyFilters { get; set; }

        /// <summary>
        /// A comma-delimited list of release definitions to retrieve.
        /// </summary>
        public string? DefinitionIdFilter { get; set; }

        /// <summary>
        /// 'true' to get release definitions that has been deleted. Default is 'false'
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 'true' to get the release definitions under the folder with name as specified in searchText. Default is 'false'.
        /// </summary>
        public bool? SearchTextContainsFolderName { get; set; }

        /// <inheritdoc />
        public override bool AsChanged()
        {
            return true;
        }

        /// <inheritdoc />
        public override bool AsNotChanged()
        {
            return false;
        }

        /// <inheritdoc />
        public override void Saved()
        {
            
        }
    }
}