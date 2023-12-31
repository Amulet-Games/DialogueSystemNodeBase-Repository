using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class PortDataBase
    {
        /// <summary>
        /// The port's GUID value.
        /// </summary>
        [SerializeField] public Guid Guid;
    }
}