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
        /// Box container for the elements that are located in node's title area. 
        /// </summary>
        public Box TitleMainBox;


        /// <summary>
        /// Text container for the node's title field.
        /// </summary>
        public TextContainer NodeTitleTextContainer;


        /// <summary>
        /// Button that'll reveal the node's title field when clicked.
        /// </summary>
        public Button EditTitleButton;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node model module base class.
        /// </summary>
        public NodeModelBase()
        {
            NodeTitleTextContainer = new();
        }
    }
}
