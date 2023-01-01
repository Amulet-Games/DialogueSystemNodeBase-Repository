using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class DialogueNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's output port GUID value.
        /// </summary>
        [SerializeField] public string OutputPortGUID;


        /// <summary>
        /// The data's dialogue character value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueCharacter;
    }
}