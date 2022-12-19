using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class PreviewNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's output port GUID value.
        /// </summary>
        [SerializeField] public string OutputPortGUID;


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
        }
    }
}