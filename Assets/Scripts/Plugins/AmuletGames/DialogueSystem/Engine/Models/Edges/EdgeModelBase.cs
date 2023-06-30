using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EdgeModelBase
    {
        /// <summary>
        /// The edge's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The edge's output port GUID value.
        /// </summary>
        [SerializeField] public string OutputPortGUID;


        /// <summary>
        /// The edge's port type value.
        /// </summary>
        [SerializeField] public PortType PortType;
    }
}