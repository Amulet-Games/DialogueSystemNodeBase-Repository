using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortData : PortDataBase
    {
        /// <summary>
        /// The port's port name value.
        /// </summary>
        [SerializeField] public string PortName;
    }
}