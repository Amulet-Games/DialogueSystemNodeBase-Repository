using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodePresenter : NodePresenterFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeCallback
    >
    {
        /// <inheritdoc />
        public override DialogueNode CreateElements
        (
            DialogueNodeView view,
            DialogueNodeCallback callback,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new DialogueNode(view, callback, graphViewer, headBar);

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
        void CreatePortElements(DialogueNode node, DialogueNodeView view)
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
        void CreateContentElements(DialogueNode node, DialogueNodeView view)
        {
            AddCharacterObjectField();

            AddCharacterObjectFieldIcon();

            AddDialogueNodeStitcher();

            void AddCharacterObjectField()
            {
                CommonObjectFieldPresenter.CreateElement<DialogueCharacter>
                (
                    view: view.CharacterObjectFieldView,
                    fieldUSS01: StyleConfig.DialogueNode_Character_ObjectField
                );

                new CommonObjectFieldObserver<DialogueCharacter>(
                    view: view.CharacterObjectFieldView).RegisterEvents();

                node.ContentContainer.Add(view.CharacterObjectFieldView.Field);
            }

            void AddCharacterObjectFieldIcon()
            {
                //view.CharacterObjectFieldView.ObjectField.RemoveFieldIcon();
                //view.CharacterObjectFieldView.ObjectField.SetDisplayImage
                //(
                //    iconSprite: ConfigResourcesManager.SpriteConfig.CharacterFieldIconSprite
                //);
            }
            
            void AddDialogueNodeStitcher()
            {
                // Create all the root elements required in the node stitcher.
                view.DialogueNodeStitcher.CreateElement(node);
            }
        }
    }
}