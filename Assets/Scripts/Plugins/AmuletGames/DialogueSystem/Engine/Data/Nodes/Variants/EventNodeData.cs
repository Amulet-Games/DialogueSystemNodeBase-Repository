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
        [SerializeField] public PortData InputPortData;


        /// <summary>
        /// The node's output port data.
        /// </summary>
        [SerializeField] public PortData OutputPortData;


        /// <summary>
        /// The node's event modifier group data.
        /// </summary>
        [SerializeField] public EventModifierViewGroupViewData EventModifierGroupData;


        /// <summary>
        /// Constructor of the event node data class.
        /// </summary>
        public EventNodeData()
        {
            InputPortData = new();
            OutputPortData = new();
            EventModifierGroupData = new();
        }
    }
}