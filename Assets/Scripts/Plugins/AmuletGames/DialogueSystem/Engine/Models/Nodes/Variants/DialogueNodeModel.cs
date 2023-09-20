using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class DialogueNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input port model.
        /// </summary>
        [SerializeField] public PortModelBase InputPortModel;


        /// <summary>
        /// The node's output port model.
        /// </summary>
        [SerializeField] public PortModelBase OutputPortModel;


        /// <summary>
        /// The node's dialogue speaker value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueSpeaker;


        /// <summary>
        /// The node's dialogue node stitcher model.
        /// </summary>
        [SerializeField] public MessageModifierGroupModel MessageModifierGroupModel;


        /// <summary>
        /// Constructor of the dialogue node model class.
        /// </summary>
        public DialogueNodeModel()
        {
            MessageModifierGroupModel = new();
        }
    }
}