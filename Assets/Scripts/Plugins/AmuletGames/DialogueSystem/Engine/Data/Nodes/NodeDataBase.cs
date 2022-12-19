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
        /// The data's node GUID value.
        /// </summary>
        [SerializeField] public string NodeGUID;


        /// <summary>
        /// The data's node position value.
        /// </summary>
        [SerializeField] public SerializableVector2 NodePosition;


        /// <summary>
        /// The data's node title text value.
        /// </summary>
        [SerializeField] public string NodeTitleText;
    }
}