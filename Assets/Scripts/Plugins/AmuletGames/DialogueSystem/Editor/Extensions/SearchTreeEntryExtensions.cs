using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public static class SearchTreeEntryExtensions
    {
        /// <summary>
        /// Returns the next level index of the given search tree entry.
        /// </summary>
        /// <param name="entry">Extension search tree entry.</param>
        /// <returns>The next level index of the given search tree entry.</returns>
        public static int NextLevel(this SearchTreeEntry entry)
        {
            int level = entry.level;
            return level + 1;
        }
    }
}