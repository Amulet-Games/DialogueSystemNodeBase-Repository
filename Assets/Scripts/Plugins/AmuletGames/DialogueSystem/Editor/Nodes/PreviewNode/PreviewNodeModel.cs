using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// Object field model for the left side portrait image.
        /// </summary>
        public CommonObjectFieldModel<Sprite> LeftPortraitObjectFieldModel;


        /// <summary>
        /// Object field model for the right side portrait image.
        /// </summary>
        public CommonObjectFieldModel<Sprite> RightPortraitObjectFieldModel;


        /// <summary>
        /// Image element for the left side portrait image.
        /// </summary>
        public Image LeftPortraitImage;


        /// <summary>
        /// Image element for the right side portrait image.
        /// </summary>
        public Image RightPortraitImage;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node model class.
        /// </summary>
        public PreviewNodeModel()
        {
            LeftPortraitObjectFieldModel = new();
            RightPortraitObjectFieldModel = new();
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}