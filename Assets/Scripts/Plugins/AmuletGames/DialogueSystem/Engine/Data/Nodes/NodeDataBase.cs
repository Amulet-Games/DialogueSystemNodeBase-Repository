using System;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Holds all the serializable values of the node element.
    /// </summary>
    [Serializable]
    public class NodeDataBase
    {
        /// <summary>
        /// The node's GUID value.
        /// </summary>
        [SerializeField] public Guid Guid;


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