using System;

namespace AG
{
    [Serializable]
    public class DSStoryNodeModel : DSNodeModelFrameBase<DSStoryNode>
    {
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Input" port's Guid id in this node.
        /// </summary>
        public string SavedInputPortGuid;


        /// <summary>
        /// The serialized "Output" port's Guid id in this node.
        /// </summary>
        public string SavedOutputPortGuid;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DSDefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DSDefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node's model.
        /// </summary>
        public DSStoryNodeModel(DSStoryNode node)
        {
            Node = node;
        }
    }
}