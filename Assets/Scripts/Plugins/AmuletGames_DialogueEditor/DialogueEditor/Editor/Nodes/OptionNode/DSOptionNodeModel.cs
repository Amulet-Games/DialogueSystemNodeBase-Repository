using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSOptionNodeModel : DSNodeModelBase
    {
        //TODO Move this to another data class!
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Output" port's Guid id in this node.
        /// </summary>
        public string SavedOutputPortGuid;


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// A special type of input port that'll only connect with the output port which has the same channel type.
        /// </summary>
        public DSOptionTrack OptionTrack;


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
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public Port OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of option node's model.
        /// </summary>
        public DSOptionNodeModel()
        {
            TextlineSegment = new TextlineSegment();
            ConditionSegment = new ConditionSegment();
            OptionTrack = new DSOptionTrack();
        }
    }
}
