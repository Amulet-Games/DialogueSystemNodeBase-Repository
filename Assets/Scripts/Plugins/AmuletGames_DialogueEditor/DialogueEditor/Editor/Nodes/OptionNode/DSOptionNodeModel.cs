using System;

namespace AG
{
    [Serializable]
    public class DSOptionNodeModel : DSNodeModelFrameBase<DSOptionNode>
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
        /// Text container for the option header text.
        /// </summary>
        public LanguageTextContainer OptionHeaderTextContainer;


        /// <summary>
        /// Holds a group of conditions that needs to be true in order to pass this node.
        /// </summary>
        public ConditionSegment ConditionSegment;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DSDefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of option node's model.
        /// </summary>
        /// <param name="node">Node of which this model is connecting upon.</param>
        public DSOptionNodeModel(DSOptionNode node)
        {
            Node = node;
            OptionTrack = new DSOptionTrack();
            OptionHeaderTextContainer = new LanguageTextContainer();
            ConditionSegment = new ConditionSegment();
        }
    }
}
