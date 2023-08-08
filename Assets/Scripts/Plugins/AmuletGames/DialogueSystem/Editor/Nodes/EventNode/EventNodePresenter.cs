using UnityEditor.Experimental.GraphView;

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
        public override EventNode CreateElements
        (
            EventNodeView view,
            GraphViewer graphViewer,
            HeadBar headBar = null
        )
        {
            var node = new EventNode(view, graphViewer);

            CreateTitleElements(node, view);
            CreatePortElements(node, view);
            CreateContentElements(node, view);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreatePortElements(EventNode node, EventNodeView view)
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
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreateContentElements(EventNode node, EventNodeView view)
        {
            SetupContentButton();

            SetupEventModifierGroup();

            void SetupContentButton()
            {
                view.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEvent_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEventModifierButtonIconSprite
                );

                node.titleContainer.Add(view.ContentButton);
            }

            void SetupEventModifierGroup()
            {
                EventModifierGroupPresenter.CreateElement(view: view.EventModifierGroupView);

                node.ContentContainer.Add(view.EventModifierGroupView.GroupContainer);
            }
        }
    }
}