using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Holds all the element references of the node element.
    /// </summary>
    [Serializable]
    public abstract class NodeViewBase
    {
        /// <summary>
        /// View for the node's title text field.
        /// </summary>
        public NodeTitleTextFieldView NodeTitleTextFieldView;


        /// <summary>
        /// Button for editing the node title.
        /// </summary>
        public Button EditTitleButton;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node view base class.
        /// </summary>
        public NodeViewBase()
        {
            NodeTitleTextFieldView = new();
        }
    }
}