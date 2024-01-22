using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodePresenter : NodePresenterFrameBase
    <
        StoryNode,
        StoryNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(StoryNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();

            ApplyDesign();
        }


        /// <summary>
        /// Create the node's port elements.
        /// </summary>
        void CreatePortElements()
        {
            // Input
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Input,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.InputPort = PortFactory.Create(portModel);
                View.InputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.InputPort);
            }

            // Output
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Output_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.OutputPort = PortFactory.Create(portModel);
                View.OutputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.OutputPort);
            }
        }


        /// <summary>
        /// Apply design method.
        /// </summary>
        void ApplyDesign()
        {
            VisualElement contentContainer;

            var margin = 10;

            SetupContainers();

            SetupPreferenceImage();

            SetupGraphViewerZoom();

            DisableReferenceNode();

            AddContainersToNode();

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void SetupPreferenceImage()
            {
                Image preferenceImage;
                preferenceImage = CommonImagePresenter.CreateElement(USS01: StyleConfig.StoryNode_PreferenceImage_Image);
                contentContainer.Add(preferenceImage);

                preferenceImage.sprite = ConfigResourcesManager.SpriteConfig.ApplyDesignSampleImage;
                preferenceImage.style.opacity = 0.6f;

                preferenceImage.style.marginBottom = margin;
                preferenceImage.style.marginTop = margin;
                preferenceImage.style.marginLeft = margin;
                preferenceImage.style.marginRight = margin;
                contentContainer.style.backgroundColor = new Color(r: 1, g: 1, b: 1, a: 0.35f);


                Node.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

                Node.capabilities = Capabilities.Movable;
            }
            
            void SetupGraphViewerZoom()
            {
                Node.GraphViewer.SetupZoom(ContentZoomer.DefaultMinScale, 6f);
            }

            void DisableReferenceNode()
            {
                Node.SetEnabled(false);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}