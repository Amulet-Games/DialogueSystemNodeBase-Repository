using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortCellData
    {
        /// <summary>
        /// The cell's port GUID value.
        /// </summary>
        [SerializeField] public Guid PortGuid;


        /// <summary>
        /// The cell's port name value.
        /// </summary>
        [SerializeField] public string PortName;
    }
}