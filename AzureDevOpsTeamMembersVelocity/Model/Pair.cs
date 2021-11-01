namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Pair of value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class Pair<T, U>
    {
        /// <summary>
        /// Default constructor. It is preferable to not use this constructor. It is there for deserialization reason.
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Constructor by initialization
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Pair(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        /// <summary>
        /// The first item
        /// </summary>
        public T? Item1 { get; set; }

        /// <summary>
        /// Second item
        /// </summary>
        public U? Item2 { get; set; }
    }
}
