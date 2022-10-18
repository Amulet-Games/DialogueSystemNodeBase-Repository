using System;

namespace AG
{
    [Serializable]
    public class DSPathNodeModel : DSNodeModelFrameBase<DSPathNode>
    {
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Input" port's Guid id in this node.
        /// </summary>
        public string SavedInputPortGuid;


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// A special type of output port that'll only connect with the input port which has the same channel type.
        /// </summary>
        public DSOptionEntry OptionEntry;


        /// <summary>
        /// Holds a collection of speical output ports, in which can only connect to the same channel type of input ports.
        /// </summary>
        public DSOptionWindow OptionWindow;


        /// <summary>
        /// Holds two input object fields for the images that'll be used for previewing in the editor.
        /// </summary>
        public DualPortraitsSegment DualPortraitsSegment;


        /// <summary>
        /// Holds the text field for the dialogue text, text field for speaker's name and
        /// <br>a object field for the dialogue's audio. (Language dependent)</br>
        /// </summary>
        public DialogueSegment DialogueSegment;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows other nodes to connect to this node.
        /// </summary>
        public DSDefaultPort InputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of path node's model.
        /// </summary>
        /// <param name="node">Node of which this model is connecting upon.</param>
        public DSPathNodeModel(DSPathNode node)
        {
            Node = node;
            OptionEntry = new DSOptionEntry();
            OptionWindow = new DSOptionWindow(node);
            DualPortraitsSegment = new DualPortraitsSegment();
            DialogueSegment = new DialogueSegment();
        }
    }
}
