using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class StartNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node data class.
        /// </summary>
        public StartNodeData()
        {
            OutputPortData = new();
        }
    }
}