using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionRootNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public OptionPortData OutputOptionPortData;

        
        /// <summary>
        /// The data's output option port group data.
        /// </summary>
        [SerializeField] public OptionPortGroupData OutputOptionPortGroupData;


        /// <summary>
        /// The data's headline text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> HeadlineText;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node data class.
        /// </summary>
        public OptionRootNodeData()
        {
            InputPortData = new();
            OutputOptionPortData = new();
            OutputOptionPortGroupData = new();
            HeadlineText = new();
        }
    }
}