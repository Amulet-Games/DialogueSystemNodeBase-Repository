using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodePresenter : NodePresenterFrameBase
    <
        EventNode,
        EventNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(EventNode node)
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
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;

            SetupContentButton();

            SetupContainers();

            SetupEventModifierGroup();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEvent_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEventButtonIconSprite
                );
            }
            
            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void SetupEventModifierGroup()
            {
                EventModifierGroupPresenter.CreateElement(view: View.EventModifierGroupView);
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

                contentContainer.Add(View.EventModifierGroupView.GroupContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}