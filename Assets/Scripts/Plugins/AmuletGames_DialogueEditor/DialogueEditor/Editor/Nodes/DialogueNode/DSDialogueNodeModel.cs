using System.Collections.Generic;
using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSDialogueNodeModel : DSNodeModelBase
    {
        //TODO Move this to another data class!
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Input" port's Guid id in this node.
        /// </summary>
        public string SavedInputPortGuid;


        /// <summary>
        /// The serialized "Continue Output" port's Guid id in this node.
        /// </summary>
        public string SavedContinueOutputPortGuid;


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// Holds a collection of speical output ports, in which can only collect to the same channel type of input ports.
        /// </summary>
        public DSOptionWindow OptionWindow;


        /// <summary>
        /// Holds a dual input sprite's object fields, in which can shows their texture in game respectively.
        /// </summary>
        public DualPortraitsSegment DualPortraitsSegment;


        /// <summary>
        /// Holds the input text field, in which to show the speaker's name in game
        /// <br>when it comes to this node.</br>
        /// </summary>
        public SpeakerNameSegment SpeakerNameSegment;


        /// <summary>
        /// Holds the input fields for a line of text and audio clip, in which
        /// <br>to show in the game when it comes to this node. (Language dependent)</br>
        /// </summary>
        public TextlineSegment TextlineSegment;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public Port ContinueOutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of dialogue node's model.
        /// </summary>
        /// <param name="node">Node of which this model is connecting upon.</param>
        public DSDialogueNodeModel(DSNodeBase node)
        {
            OptionWindow = new DSOptionWindow(node);
            DualPortraitsSegment = new DualPortraitsSegment();
            SpeakerNameSegment = new SpeakerNameSegment();
            TextlineSegment = new TextlineSegment();
        }
    }
}
