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
        /// The data's event modifier model group data.
        /// </summary>
        [SerializeField] public EventModifierModelGroupData EventModifierModelGroupData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node data class.
        /// </summary>
        public EventNodeData()
        {
            InputPortData = new();
            OutputPortData = new();
            EventModifierModelGroupData = new();
        }
    }
}