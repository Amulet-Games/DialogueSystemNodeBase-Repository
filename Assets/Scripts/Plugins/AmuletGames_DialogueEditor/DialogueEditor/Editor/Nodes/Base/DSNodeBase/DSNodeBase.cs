using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Main class of dialogue system node base class.
    /// <para>
    /// Service methods are separated into different scripts as partial class,
    /// and are located inside the same extension folders.
    /// </para>
    /// </summary>
    public abstract partial class DSNodeBase: Node
    {
        /// <summary>
        /// The special GUID id of this node.
        /// </summary>
        public string NodeGuid;


        /// <summary>
        /// Defualt size of this node.
        /// </summary>
        protected static Vector2 DefaultNodeSize;


        /// <summary>
        /// Reference of the graph view module in the dialogue system.
        /// </summary>
        public DSGraphView GraphView;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The callback action to invoke when any of the nodes is deleted by users from the graph manually.
        /// </summary>
        public abstract void NodeRemovedByManualAction();
    }
}