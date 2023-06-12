using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodePresenter : NodePresenterFrameBase
    <
        EventNode,
        EventNodeModel
    >
    {
        /// <inheritdoc />
        public override EventNode CreateElements(EventNodeModel model, GraphViewer graphViewer)
        {
            var node = new EventNode(model, graphViewer);

            CreateTitleElements(node, model);
            CreatePortElements(node, model);
            CreateContentElements(node, model);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreatePortElements(EventNode node, EventNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(model.InputDefaultPort);
            node.Add(model.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(EventNode node, EventNodeModel model)
        {
            SetupContentButton();

            SetupEventModifierModelGroup();

            CreateEventModifier();

            void SetupContentButton()
            {
                model.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEvent_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEventModifierButtonIconSprite
                );

                node.titleContainer.Add(model.ContentButton);
            }

            void SetupEventModifierModelGroup()
            {
                EventModifierModelGroupPresenter.CreateElement(model: model.EventModifierModelGroupModel);
                node.ContentContainer.Add(model.EventModifierModelGroupModel.MainContainer);
            }

            void CreateEventModifier()
            {
                model.EventModifierModelGroupModel.CreateModifier();
            }
        }
    }
}