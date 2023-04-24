using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EdgeDataBase
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
        /// The data's port type value.
        /// </summary>
        [SerializeField] public PortType PortType;
    }
}