using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class PreviewNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The node's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        /// <summary>
        /// The node's left portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite LeftPortraitSprite;


        /// <summary>
        /// The node's right portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite RightPortraitSprite;


        /// <summary>
        /// Constructor of the preview node data class.
        /// </summary>
        public PreviewNodeData()
        {
        }
    }
}