using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class DialogueNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input port data.
        /// </summary>
        [SerializeField] public PortData InputPortData;


        /// <summary>
        /// The node's output port data.
        /// </summary>
        [SerializeField] public PortData OutputPortData;


        /// <summary>
        /// The node's dialogue speaker value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueSpeaker;


        /// <summary>
        /// The node's dialogue node stitcher data.
        /// </summary>
        [SerializeField] public MessageModifierGroupData MessageModifierGroupData;


        /// <summary>
        /// Constructor of the dialogue node data class.
        /// </summary>
        public DialogueNodeData()
        {
            MessageModifierGroupData = new();
        }
    }
}