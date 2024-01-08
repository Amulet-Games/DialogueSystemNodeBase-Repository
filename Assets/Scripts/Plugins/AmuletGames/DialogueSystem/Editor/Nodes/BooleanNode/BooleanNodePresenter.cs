using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

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
            View.InputPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                name: StringConfig.Port_Input_LabelText
            );

            View.TrueOutputPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                name: StringConfig.Port_True_LabelText
            );

            // False output port
            {
                View.FalseOutputPort = PortManager.Instance.CreateDefault
                (
                    connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                    direction: Direction.Output,
                    capacity: Port.Capacity.Single,
                    name: StringConfig.Port_False_LabelText
                );

                View.FalseOutputPort.AddToClassList(StyleConfig.BooleanNode_False_Output_Port);
            }
            
            Node.Add(View.InputPort);
            Node.Add(View.TrueOutputPort);
            Node.Add(View.FalseOutputPort);
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
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
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
                Node.topContainer.Add(View.ContentButton);

                contentContainer.Add(View.ConditionModifierGroupView.GroupContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}