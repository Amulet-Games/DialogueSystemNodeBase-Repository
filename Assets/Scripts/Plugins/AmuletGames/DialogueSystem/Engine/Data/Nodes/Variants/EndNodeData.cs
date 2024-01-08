using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EndNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input port data.
        /// </summary>
        [SerializeField] public PortData InputPortData;


        /// <summary>
        /// Constructor of the end node data class.
        /// </summary>
        public EndNodeData()
        {
            InputPortData = new();
        }
    }
}