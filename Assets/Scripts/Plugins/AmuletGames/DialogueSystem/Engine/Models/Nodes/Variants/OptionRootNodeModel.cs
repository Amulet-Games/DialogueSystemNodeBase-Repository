using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionRootNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input port model.
        /// </summary>
        [SerializeField] public PortModelBase InputPortModel;


        /// <summary>
        /// The node's output port model.
        /// </summary>
        [SerializeField] public OptionPortModel OutputOptionPortModel;


        /// <summary>
        /// The node's output option port group model.
        /// </summary>
        [SerializeField] public OptionPortGroupModel OutputOptionPortGroupModel;


        /// <summary>
        /// The node's root title text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> RootTitleText;


        /// <summary>
        /// Constructor of the option root node model class.
        /// </summary>
        public OptionRootNodeModel()
        {
            OutputOptionPortGroupModel = new();
            RootTitleText = new();
        }
    }
}