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
                    port: PortModel.Port.Default,
                    Direction.Input,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.InputPort = PortManager.Instance.Create(portModel);
                View.InputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.InputPort);
            }

            // True Output
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_True_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.TrueOutputPort = PortManager.Instance.Create(portModel);
                View.TrueOutputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.TrueOutputPort);
            }

            // False Output
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_False_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.FalseOutputPort = PortManager.Instance.Create(portModel);
                View.FalseOutputPort.AddToClassList(StyleConfig.BooleanNode_False_Output_Port);

                View.FalseOutputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

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
                View.ConditionModifierGroup = ConditionModifierGroupPresenter.CreateElement();
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButtonView.Button);

                contentContainer.Add(View.ConditionModifierGroup);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}