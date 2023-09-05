using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

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
            View.InputDefaultPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                name: StringConfig.DefaultPort_Input_LabelText
            );

            View.OutputDefaultPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                name: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.OutputDefaultPort);
            Node.RefreshPorts();
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
                preferenceImage = CommonImagePresenter.CreateElement(imageUSS01: StyleConfig.StoryNode_PreferenceImage_Image);
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