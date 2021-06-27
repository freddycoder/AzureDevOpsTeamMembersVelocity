using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Settings
{
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
