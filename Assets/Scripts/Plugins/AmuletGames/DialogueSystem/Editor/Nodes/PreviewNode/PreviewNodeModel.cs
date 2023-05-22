using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeModel : NodeModelFrameBase<PreviewNode>
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
        /// <param name="node">The node element to set for.</param>
        public PreviewNodeModel(PreviewNode node)
        {
            Node = node;
            LeftPortraitObjectFieldModel = new();
            RightPortraitObjectFieldModel = new();
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputDefaultPort);
            Node.GraphViewer.Remove(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}