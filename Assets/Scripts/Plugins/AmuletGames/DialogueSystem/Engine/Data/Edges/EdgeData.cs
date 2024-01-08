using System;
using System.Collections.Generic;
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
        /// The edge's port type value.
        /// </summary>
        [SerializeField] public List<StyleSheet> styleSheets;


        /// <summary>
        /// Constructor of the edge data class.
        /// </summary>
        public EdgeData()
        {
            styleSheets = new();
        }
    }
}