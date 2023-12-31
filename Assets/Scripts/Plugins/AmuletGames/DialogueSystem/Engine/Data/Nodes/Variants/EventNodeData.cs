using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EventNodeData : NodeDataBase
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
        /// The node's event modifier group data.
        /// </summary>
        [SerializeField] public EventModifierGroupData EventModifierGroupData;


        /// <summary>
        /// Constructor of the event node data class.
        /// </summary>
        public EventNodeData()
        {
            EventModifierGroupData = new();
        }
    }
}