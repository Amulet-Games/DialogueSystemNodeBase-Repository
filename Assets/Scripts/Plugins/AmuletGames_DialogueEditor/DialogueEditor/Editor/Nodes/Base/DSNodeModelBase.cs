using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node model base class.
    /// </summary>
    [Serializable]
    public abstract class DSNodeModelBase
    {
        // ----------------------------- Serialized Base -----------------------------
        /// <summary>
        /// The serialized node's Guid id.
        /// </summary>
        public string SavedNodeGuid;


        /// <summary>
        /// The serialized node's position. 
        /// </summary>
        public Vector2 SavedNodePosition;


        // ----------------------------- Elements Base -----------------------------
        /// <summary>
        /// Box container for the elements that are located in node's title area. 
        /// </summary>
        public Box TitleMainBox;


        /// <summary>
        /// Text container for the node's title field.
        /// </summary>
        public TextContainer NodeTitle_TextContainer;


        /// <summary>
        /// Button that'll reveal the node's title field when pressed.
        /// </summary>
        public Button EditTitleButton;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of node's model base class.
        /// </summary>
        public DSNodeModelBase()
        {
            NodeTitle_TextContainer = new TextContainer();
        }
    }
}
