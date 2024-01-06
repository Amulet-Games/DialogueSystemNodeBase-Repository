using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class PortData
    {
        /// <summary>
        /// The port's GUID value.
        /// </summary>
        [SerializeField] public Guid Guid;
    }
}