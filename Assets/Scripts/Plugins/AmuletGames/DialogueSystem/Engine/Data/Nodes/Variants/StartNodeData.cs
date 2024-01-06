using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class StartNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's output port data.
        /// </summary>
        [SerializeField] public PortData OutputPortData;


        /// <summary>
        /// Constructor of the start node data class.
        /// </summary>
        public StartNodeData()
        {
        }
    }
}