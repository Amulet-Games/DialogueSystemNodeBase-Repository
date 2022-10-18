using System;

namespace AG
{
    [Serializable]
    public class DSEventNodeModel : DSNodeModelFrameBase<DSEventNode>
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


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public EventMolder EventMolder;


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
        public DSEventNodeModel(DSEventNode node)
        {
            Node = node;
            EventMolder = new EventMolder();
        }
    }
}
