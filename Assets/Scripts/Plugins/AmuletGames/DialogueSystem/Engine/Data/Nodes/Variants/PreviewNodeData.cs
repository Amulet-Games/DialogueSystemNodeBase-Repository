using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class PreviewNodeData : NodeDataBase
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
        /// The data's left portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite LeftPortraitSprite;


        /// <summary>
        /// The data's right portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite RightPortraitSprite;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node data class.
        /// </summary>
        public PreviewNodeData()
        {
            InputPortData = new();
            OutputPortData = new();
        }
    }
}