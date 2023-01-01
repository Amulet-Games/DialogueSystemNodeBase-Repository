using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeModel : NodeModelBase
    {
        /// <summary>
        /// Object container for showing the left side character sprite in the preview image.
        /// </summary>
        public ObjectContainer<Sprite> LeftSpriteContainer;


        /// <summary>
        /// Object container for showing the right side character sprite in the preview image.
        /// </summary>
        public ObjectContainer<Sprite> RightSpriteContainer;


        /// <summary>
        /// Image element for showing off the preview image of the left side character speaking.
        /// </summary>
        public Image LeftPortraitImage;


        /// <summary>
        /// Image element for showing off the preview image of the right side character speaking.
        /// </summary>
        public Image RightPortraitImage;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node's model module class.
        /// </summary>
        public PreviewNodeModel()
        {
            LeftSpriteContainer = new();
            RightSpriteContainer = new();
        }
    }
}