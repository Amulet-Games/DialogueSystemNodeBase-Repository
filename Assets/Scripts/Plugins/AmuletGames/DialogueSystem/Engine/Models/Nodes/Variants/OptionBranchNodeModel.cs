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
        /// The node's branch title text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> BranchTitleText;


        /// <summary>
        /// The node's option branch node stitcher model.
        /// </summary>
        [SerializeField] public OptionBranchNodeStitcherModel OptionBranchNodeStitcherModel;


        /// <summary>
        /// Constructor of the option branch node model class.
        /// </summary>
        public OptionBranchNodeModel()
        {
            BranchTitleText = new();
            OptionBranchNodeStitcherModel = new();
        }
    }
}