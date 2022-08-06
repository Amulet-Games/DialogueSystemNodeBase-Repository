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
        /// The serialized port entries that are used to connect with choice node.
        /// </summary>
        public List<ChoiceEntry> ChoiceEntries;


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
        public DSDialogueNodeModel()
        {
            ChoiceEntries = new List<ChoiceEntry>();
            DualPortraitsSegment = new DualPortraitsSegment();
            SpeakerNameSegment = new SpeakerNameSegment();
            TextlineSegment = new TextlineSegment();
        }
    }
}
