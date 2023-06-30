using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EndNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input port model.
        /// </summary>
        [SerializeField] public PortModelBase InputPortModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node model class.
        /// </summary>
        public EndNodeModel()
        {
            InputPortModel = new();
        }
    }
}