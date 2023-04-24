using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class DialogueNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        /// <summary>
        /// The data's dialogue character value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueCharacter;


        /// <summary>
        /// The data's dialogue node stitcher data.
        /// </summary>
        [SerializeField] public DialogueNodeStitcherData DialogueNodeStitcherData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node data class.
        /// </summary>
        public DialogueNodeData()
        {
            InputPortData = new();
            OutputPortData = new();
            DialogueNodeStitcherData = new();
        }
    }
}