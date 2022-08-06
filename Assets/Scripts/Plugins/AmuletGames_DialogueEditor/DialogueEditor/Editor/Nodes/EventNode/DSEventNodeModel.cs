using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSEventNodeModel : DSNodeModelBase
    {
        //TODO Move this to another data class!
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
        public Port InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public Port OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node's model.
        /// </summary>
        public DSEventNodeModel()
        {
            EventMolder = new EventMolder();
        }
    }
}
