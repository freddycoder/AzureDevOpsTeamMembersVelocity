using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// An object containing a link
    /// </summary>
    public class HrefObject
    {
        /// <summary>
        /// Href or link
        /// </summary>
        /// <exception cref="UriFormatException"></exception>
        public string? Href 
        { 
            get
            {
                return _href;
            }
            set
            {
                if (Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out var result))
                {
                    _href = value;
                    UriInfo = result;
                }
                else
                {
                    throw new UriFormatException(value);
                }
            }
        }

        /// <summary>
        /// Uri instance of the Href property
        /// </summary>
        public Uri? UriInfo { get; private set; }

        private string? _href;
    }
}