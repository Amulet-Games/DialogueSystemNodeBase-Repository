using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(BooleanNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();

            CreateContentElements();
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
                    direction: Direction.Input,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );
                var edgeModel = new EdgeModel
                (
                    focusable: true,
                    styleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );
                var edgeConnectorListenerModel = new EdgeConnectorListenerModel
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeModel: edgeModel
                );

                View.InputPort = PortFactory.Generate(portModel);
                View.InputPort.AddEdgeConnector(edgeConnectorListenerModel);
                Node.Add(View.InputPort);
            }

            // True Output
            {
                var portModel = new PortModel
                (
                    direction: Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_True_LabelText,
                    color: PortConfig.DefaultPortColor
                );
                var edgeModel = new EdgeModel
                (
                    focusable: true,
                    styleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );
                var edgeConnectorListenerModel = new EdgeConnectorListenerModel
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeModel: edgeModel
                );

                View.TrueOutputPort = PortFactory.Generate(portModel);
                View.TrueOutputPort.AddEdgeConnector(edgeConnectorListenerModel);

                Node.Add(View.TrueOutputPort);
            }

            // False Output
            {
                var portModel = new PortModel
                (
                    direction: Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_False_LabelText,
                    color: PortConfig.DefaultPortColor
                );
                var edgeModel = new EdgeModel
                (
                    focusable: true,
                    styleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );
                var edgeConnectorListenerModel = new EdgeConnectorListenerModel
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeModel: edgeModel
                );

                View.FalseOutputPort = PortFactory.Generate(portModel);
                View.FalseOutputPort.AddToClassList(StyleConfig.BooleanNode_False_Output_Port);
                View.FalseOutputPort.AddEdgeConnector(edgeConnectorListenerModel);

                Node.Add(View.FalseOutputPort);
            }
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;

            CreateContentButton();

            CreateContainers();

            CreateConditionModifierGroup();

            AddElementsToContainer();

            AddContainersToNode();

            void CreateContentButton()
            {
                ContentButtonPresenter.CreateElement
                (
                    view: View.ContentButtonView,
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionButtonIconSprite
                );
            }

            void CreateContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void CreateConditionModifierGroup()
            {
                ConditionModifierGroupPresenter.CreateElement(view: View.ConditionModifierGroupView);
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButtonView.Button);

                contentContainer.Add(View.ConditionModifierGroupView.GroupContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}