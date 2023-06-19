using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodePresenter : NodePresenterFrameBase
    <
        StoryNode,
        StoryNodeModel
    >
    {
        /// <inheritdoc />
        public override StoryNode CreateElements(StoryNodeModel model, GraphViewer graphViewer)
        {
            var node = new StoryNode(model, graphViewer);

            CreateTitleElements(node, model);
            CreatePortElements(node, model);
            ApplyDesign(node, model);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreatePortElements(StoryNode node, StoryNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(model.InputDefaultPort);
            node.Add(model.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Apply design method.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void ApplyDesign(StoryNode node, StoryNodeModel model)
        {
            var margin = 10;

            SetupPreferenceImage();

            SetupGraphViewerZoom();

            DisableReferenceNode();

            CreateSampleNode();

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

            void CreateSampleNode()
            {
                node.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    var details = new NodeCreateDetails(
                        horizontalAlignType: HorizontalAlignmentType.FREE);

                    var createPosition = node.localBound.position;
                    createPosition.x += margin;
                    createPosition.y += node.titleContainer.layout.height + node.inputContainer.parent.layout.height + margin;
                    //details.SetPositionCreate(value: createPosition);

                    //var target = new EventNode(graphViewer: node.GraphViewer);

                    //target.capabilities = Capabilities.Movable;
                    //target.SetEnabled(false);
                    //target.style.opacity = 1;
                    //target.titleContainer.ElementAt(index: 1).style.backgroundColor = new Color(0.357f, 0.537f, 0.75f, 1);

                    //target.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    //target.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    //target.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    //target.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

                    node.BringToFront();

                    // Unregister the action once the setup is done.
                    node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }
    }
}