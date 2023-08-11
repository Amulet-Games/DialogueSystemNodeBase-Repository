using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionBranchNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input option port model.
        /// </summary>
        [SerializeField] public OptionPortModel InputOptionPortModel;


        /// <summary>
        /// The node's output port model.
        /// </summary>
        [SerializeField] public PortModelBase OutputPortModel;


        /// <summary>
        /// The node's headline text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> HeadlineText;


        /// <summary>
        /// The node's option branch node stitcher model.
        /// </summary>
        [SerializeField] public OptionBranchNodeStitcherModel OptionBranchNodeStitcherModel;


        /// <summary>
        /// Constructor of the option branch node model class.
        /// </summary>
        public OptionBranchNodeModel()
        {
            InputOptionPortModel = new();
            OutputPortModel = new();
            HeadlineText = new();
            OptionBranchNodeStitcherModel = new();
        }
    }
}