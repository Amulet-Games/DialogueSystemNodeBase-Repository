using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EventNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        /// <summary>
        /// The data's event modifier group data.
        /// </summary>
        [SerializeField] public EventModifierGroupData EventModifierGroupData;


        // ----------------------------- Constructor -----------------------------
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