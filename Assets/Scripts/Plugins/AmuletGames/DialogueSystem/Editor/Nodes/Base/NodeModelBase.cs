using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Holds all the UIElements reference of the connecting node module.
    /// </summary>
    [Serializable]
    public abstract class NodeModelBase
    {
        /// <summary>
        /// Model for the node's title text field.
        /// </summary>
        public NodeTitleTextFieldModel NodeTitleTextFieldModel;


        /// <summary>
        /// Button that edit the node title when clicked.
        /// </summary>
        public Button EditTitleButton;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node model module base class.
        /// </summary>
        public NodeModelBase()
        {
            NodeTitleTextFieldModel = new();
        }
    }
}