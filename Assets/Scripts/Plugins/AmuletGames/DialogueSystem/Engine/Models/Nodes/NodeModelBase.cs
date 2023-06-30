using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class NodeModelBase
    {
        /// <summary>
        /// The node's GUID value.
        /// </summary>
        [SerializeField] public string GUID;


        /// <summary>
        /// The node's position value.
        /// </summary>
        [SerializeField] public SerializableVector2 Position;


        /// <summary>
        /// The node's title text value.
        /// </summary>
        [SerializeField] public string TitleText;
    }
}