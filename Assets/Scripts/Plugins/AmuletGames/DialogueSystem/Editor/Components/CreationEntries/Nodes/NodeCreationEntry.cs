using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreationEntry : SearchTreeEntry
    {
        /// <summary>
        /// Id of the node creation entry.
        /// </summary>
        public int EntryId { get; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node creation entry class.
        /// </summary>
        /// <param name="content">The GUIContent(text and icon) to set for.</param>
        /// <param name="level">The level of the entry to set for.</param>
        /// <param name="userData">The id to set for the entry.</param>
        public NodeCreationEntry
        (
            GUIContent content,
            int level,
            int entryId
        )
            : base(content)
        {
            this.level = level;
            EntryId = entryId;
        }
    }
}