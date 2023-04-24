using System;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Holds all the connecting node module's data.
    /// </summary>
    [Serializable]
    public class NodeDataBase
    {
        /// <summary>
        /// The data's GUID value.
        /// </summary>
        [SerializeField] public string GUID;


        /// <summary>
        /// The data's position value.
        /// </summary>
        [SerializeField] public SerializableVector2 Position;


        /// <summary>
        /// The data's title text value.
        /// </summary>
        [SerializeField] public string TitleText;
    }
}