using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EventNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's output port GUID value.
        /// </summary>
        [SerializeField] public string OutputPortGUID;


        /// <summary>
        /// The data's event molder data.
        /// </summary>
        [SerializeField] public EventMolderData EventMolderData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node data class.
        /// </summary>
        public EventNodeData()
        {
            EventMolderData = new();
        }
    }
}