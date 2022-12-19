using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class EndNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's dialogue over handle type enum value.
        /// </summary>
        [SerializeField] public int DialogueOverHandleTypeEnumIndex;
    }
}