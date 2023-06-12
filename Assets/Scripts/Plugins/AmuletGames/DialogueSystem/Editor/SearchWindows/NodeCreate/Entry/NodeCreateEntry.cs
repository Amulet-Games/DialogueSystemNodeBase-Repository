using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreateEntry : SearchTreeEntry
    {
        /// <summary>
        /// The type of the node that this create entry creates.
        /// </summary>
        public NodeType NodeType { get; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create entry class.
        /// </summary>
        /// <param name="content">The GUIContent(text and icon) to set for.</param>
        /// <param name="level">The level of the entry to set for.</param>
        /// <param name="nodeType">The node type to set for.</param>
        public NodeCreateEntry
        (
            GUIContent content,
            int level,
            NodeType nodeType
        )
            : base(content)
        {
            this.level = level;
            NodeType = nodeType;
        }
    }
}