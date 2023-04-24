using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EndNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node data class.
        /// </summary>
        public EndNodeData()
        {
            InputPortData = new();
        }
    }
}