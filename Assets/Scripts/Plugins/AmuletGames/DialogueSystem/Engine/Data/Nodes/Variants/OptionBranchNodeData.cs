using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionBranchNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input option port data.
        /// </summary>
        [SerializeField] public OptionPortData InputOptionPortData;


        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        /// <summary>
        /// The data's headline text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> HeadlineText;


        /// <summary>
        /// The data's option branch node stitcher data.
        /// </summary>
        [SerializeField] public OptionBranchNodeStitcherData OptionBranchNodeStitcherData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node data class.
        /// </summary>
        public OptionBranchNodeData()
        {
            InputOptionPortData = new();
            OutputPortData = new();
            HeadlineText = new();
            OptionBranchNodeStitcherData = new();
        }
    }
}