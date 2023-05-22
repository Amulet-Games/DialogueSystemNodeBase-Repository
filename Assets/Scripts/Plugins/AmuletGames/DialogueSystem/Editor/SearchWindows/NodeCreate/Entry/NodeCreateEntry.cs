using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreateEntry : SearchTreeEntry
    {
        /// <summary>
        /// Id of the node create entry.
        /// </summary>
        public int EntryId { get; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create entry class.
        /// </summary>
        /// <param name="content">The GUIContent(text and icon) to set for.</param>
        /// <param name="level">The level of the entry to set for.</param>
        /// <param name="userData">The id to set for the entry.</param>
        public NodeCreateEntry
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