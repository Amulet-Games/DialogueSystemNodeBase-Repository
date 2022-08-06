using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSChoiceNodeModel : DSNodeModelBase
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
        /// Holds the input fields for a line of text and audio clip, in which
        /// <br>to show in the game when it comes to this node. (Language dependent)</br>
        /// </summary>
        public TextlineSegment TextlineSegment;


        /// <summary>
        /// Holds a group of conditions that needs to be true in order to pass this node.
        /// </summary>
        public ConditionSegment ConditionSegment;


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
        /// Construtor of choice node's model.
        /// </summary>
        public DSChoiceNodeModel()
        {
            TextlineSegment = new TextlineSegment();
            ConditionSegment = new ConditionSegment();
        }
    }
}
