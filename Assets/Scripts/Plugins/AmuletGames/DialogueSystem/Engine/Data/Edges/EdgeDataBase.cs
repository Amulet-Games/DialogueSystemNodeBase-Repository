using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EdgeDataBase
    {
        /// <summary>
        /// The edge's input port GUID value.
        /// </summary>
        [SerializeField] public Guid InputPortGUID;


        /// <summary>
        /// The edge's output port GUID value.
        /// </summary>
        [SerializeField] public Guid OutputPortGUID;


        /// <summary>
        /// The edge's port type value.
        /// </summary>
        [SerializeField] public PortType PortType;
    }
}