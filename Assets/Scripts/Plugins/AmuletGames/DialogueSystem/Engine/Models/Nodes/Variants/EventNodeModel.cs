using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EventNodeModel : NodeModelBase
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
        /// The node's event modifier group model.
        /// </summary>
        [SerializeField] public EventModifierGroupModel EventModifierGroupModel;


        /// <summary>
        /// Constructor of the event node model class.
        /// </summary>
        public EventNodeModel()
        {
            InputPortModel = new();
            OutputPortModel = new();
            EventModifierGroupModel = new();
        }
    }
}