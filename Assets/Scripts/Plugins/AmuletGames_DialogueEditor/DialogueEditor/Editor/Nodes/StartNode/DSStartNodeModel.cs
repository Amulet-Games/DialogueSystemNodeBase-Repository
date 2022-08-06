using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSStartNodeModel : DSNodeModelBase
    {
        //TODO Move this to another data class!
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Output" port's Guid id in this node.
        /// </summary>
        public string SavedOutputPortGuid;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public Port OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of choice node's model.
        /// </summary>
        public DSStartNodeModel() { }
    }
}
