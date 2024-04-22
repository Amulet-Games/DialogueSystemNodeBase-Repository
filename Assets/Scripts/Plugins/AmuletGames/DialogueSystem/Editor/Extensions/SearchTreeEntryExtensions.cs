using System.Collections.Generic;
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


        /// <summary>
        /// Add the given search tree entry to the search tree entries list.
        /// </summary>
        /// <param name="entry">Extension search tree entry.</param>
        /// <param name="entries">The search tree entries to set for.</param>
        /// <returns>The given search tree entry.</returns>
        public static SearchTreeEntry AddTo
        (
            this SearchTreeEntry entry,
            List<SearchTreeEntry> entries
        )
        {
            entries.Add(entry);
            return entry;
        }


        /// <summary>
        /// Add the given search tree group entry to the search tree entries list.
        /// </summary>
        /// <param name="entry">Extension search tree group entry.</param>
        /// <param name="entries">The search tree entries to set for.</param>
        /// <returns>The given search tree group entry.</returns>
        public static SearchTreeGroupEntry AddTo
        (
            this SearchTreeGroupEntry entry,
            List<SearchTreeEntry> entries
        )
        {
            entries.Add(entry);
            return entry;
        }
    }
}