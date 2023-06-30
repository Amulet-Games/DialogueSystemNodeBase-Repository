using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class PreviewNodeModel : NodeModelBase
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
        /// The node's left portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite LeftPortraitSprite;


        /// <summary>
        /// The node's right portrait sprite value.
        /// </summary>
        [SerializeField] public Sprite RightPortraitSprite;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node model class.
        /// </summary>
        public PreviewNodeModel()
        {
            InputPortModel = new();
            OutputPortModel = new();
        }
    }
}