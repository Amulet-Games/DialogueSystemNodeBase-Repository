using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSNodeCreationEntry : SearchTreeEntry
    {
        /// <summary>
        /// Id of the node creation entry.
        /// </summary>
        public int EntryId { get; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system's node creation entry.
        /// </summary>
        /// <param name="content">The GUIContent(text and icon) to set for.</param>
        /// <param name="level">The level of the entry to set for.</param>
        /// <param name="userData">The id to set for the entry.</param>
        public DSNodeCreationEntry(GUIContent content, int level, int entryId)
            : base(content)
        {
            this.level = level;
            EntryId = entryId;
        }
    }
}