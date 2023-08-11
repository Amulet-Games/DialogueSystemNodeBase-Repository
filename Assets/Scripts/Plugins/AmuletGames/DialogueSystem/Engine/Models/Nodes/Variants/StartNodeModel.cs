using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class StartNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's output port model.
        /// </summary>
        [SerializeField] public PortModelBase OutputPortModel;


        /// <summary>
        /// Constructor of the start node model class.
        /// </summary>
        public StartNodeModel()
        {
            OutputPortModel = new();
        }
    }
}