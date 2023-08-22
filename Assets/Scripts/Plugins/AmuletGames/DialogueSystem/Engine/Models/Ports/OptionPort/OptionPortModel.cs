using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortModel : PortModelBase
    {
        /// <summary>
        /// The port's port name value.
        /// </summary>
        [SerializeField] public string PortName;
    }
}