using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class SingleOptionChannelData
    {
        /// <summary>
        /// The data's port GUID.
        /// </summary>
        [SerializeField] public string PortGUID;


        /// <summary>
        /// The data's port label.
        /// </summary>
        [SerializeField] public string PortLabel;
    }
}