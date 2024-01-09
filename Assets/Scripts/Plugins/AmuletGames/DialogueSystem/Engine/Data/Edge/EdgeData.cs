using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class EdgeData
    {
        /// <summary>
        /// The edge's input port GUID value.
        /// </summary>
        [SerializeField] public Guid InputPortGUID;


        /// <summary>
        /// The edge's output port GUID value.
        /// </summary>
        [SerializeField] public Guid OutputPortGUID;


        /// <summary>
        /// The edge's focusable value.
        /// </summary>
        [SerializeField] public bool Focusable;


        /// <summary>
        /// The edge's style sheet.
        /// </summary>
        [SerializeField] public StyleSheet StyleSheet;
    }
}