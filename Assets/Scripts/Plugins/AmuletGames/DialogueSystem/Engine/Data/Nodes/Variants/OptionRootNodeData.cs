using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionRootNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input port data.
        /// </summary>
        [SerializeField] public PortData InputPortData;


        /// <summary>
        /// The node's output option port group data.
        /// </summary>
        [SerializeField] public OptionPortGroupData OutputOptionPortGroupData;


        /// <summary>
        /// The node's root title text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> RootTitleText;


        /// <summary>
        /// Constructor of the option root node data class.
        /// </summary>
        public OptionRootNodeData()
        {
            InputPortData = new();
            OutputOptionPortGroupData = new();
            RootTitleText = new();
        }
    }
}