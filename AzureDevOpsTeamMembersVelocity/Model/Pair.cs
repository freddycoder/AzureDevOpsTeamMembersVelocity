using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Pair<T, U>
    {
        public Pair()
        {

        }

        public Pair(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public T Item1 { get; set; }

        public U Item2 { get; set; }
    }
}
