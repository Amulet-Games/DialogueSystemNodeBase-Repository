using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodePresenter : NodePresenterFrameBase
    <
        DialogueNode,
        DialogueNodeModel
    >
    {
        /// <inheritdoc />
        public override DialogueNode CreateElements(DialogueNodeModel model, GraphViewer graphViewer)
        {
            var node = new DialogueNode(model, graphViewer);

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
        void CreatePortElements(DialogueNode node, DialogueNodeModel model)
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
        void CreateContentElements(DialogueNode node, DialogueNodeModel model)
        {
            AddCharacterObjectField();

            AddCharacterObjectFieldIcon();

            AddDialogueNodeStitcher();

            void AddCharacterObjectField()
            {
                model.CharacterObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<DialogueCharacter>
                    (
                        fieldUSS01: StyleConfig.DialogueNode_Character_ObjectField
                    );

                new CommonObjectFieldCallback<DialogueCharacter>(
                    model: model.CharacterObjectFieldModel).RegisterEvents();

                node.ContentContainer.Add(model.CharacterObjectFieldModel.ObjectField);
            }

            void AddCharacterObjectFieldIcon()
            {
                model.CharacterObjectFieldModel.ObjectField.RemoveFieldIcon();
                model.CharacterObjectFieldModel.ObjectField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.SpriteConfig.CharacterFieldIconSprite
                );
            }
            
            void AddDialogueNodeStitcher()
            {
                // Create all the root elements required in the node stitcher.
                model.DialogueNodeStitcher.CreateElement(node);
            }
        }
    }
}