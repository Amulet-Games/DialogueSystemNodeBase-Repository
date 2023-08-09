using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodePresenter : NodePresenterFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeObserver
    >
    {
        /// <inheritdoc />
        public override StoryNode CreateElements
        (
            StoryNodeView view,
            StoryNodeObserver observer,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new StoryNode(view, graphViewer, headBar);

            CreateTitleElements(node, view);
            CreatePortElements(node, view);
            ApplyDesign(node, view);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreatePortElements(StoryNode node, StoryNodeView view)
        {
            view.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            view.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(view.InputDefaultPort);
            node.Add(view.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Apply design method.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void ApplyDesign(StoryNode node, StoryNodeView view)
        {
            var margin = 10;

            SetupPreferenceImage();

            SetupGraphViewerZoom();

            DisableReferenceNode();

            void SetupPreferenceImage()
            {
                Image preferenceImage;
                preferenceImage = CommonImagePresenter.CreateElement(imageUSS01: StyleConfig.StoryNode_PreferenceImage_Image);
                node.ContentContainer.Add(preferenceImage);

                preferenceImage.sprite = ConfigResourcesManager.SpriteConfig.ApplyDesignSampleImage;
                preferenceImage.style.opacity = 0.6f;

                preferenceImage.style.marginBottom = margin;
                preferenceImage.style.marginTop = margin;
                preferenceImage.style.marginLeft = margin;
                preferenceImage.style.marginRight = margin;
                node.ContentContainer.style.backgroundColor = new Color(r: 1, g: 1, b: 1, a: 0.35f);


                node.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
                node.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
                node.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
                node.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

                node.capabilities = Capabilities.Movable;
            }
            
            void SetupGraphViewerZoom()
            {
                node.GraphViewer.SetupZoom(ContentZoomer.DefaultMinScale, 6f);
            }

            void DisableReferenceNode()
            {
                node.SetEnabled(false);
            }
        }
    }
}