using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionBranchNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input option port data.
        /// </summary>
        [SerializeField] public OptionPortData InputOptionPortData;


        /// <summary>
        /// The node's output port data.
        /// </summary>
        [SerializeField] public PortData OutputPortData;


        /// <summary>
        /// The node's branch title text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> BranchTitleText;


        /// <summary>
        /// Constructor of the option branch node data class.
        /// </summary>
        public OptionBranchNodeData()
        {
            BranchTitleText = new();
        }
    }
}