using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodePresenter : NodePresenterFrameBase
    <
        DialogueNode,
        DialogueNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(DialogueNode node)
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
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                name: StringConfig.DefaultPort_Input_LabelText
            );

            View.OutputDefaultPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                name: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.OutputDefaultPort);
            Node.RefreshPorts();
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;

            SetupContainers();

            AddCharacterObjectField();

            AddCharacterObjectFieldIcon();

            AddDialogueNodeStitcher();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void AddCharacterObjectField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: View.CharacterObjectFieldView,
                    fieldUSS01: StyleConfig.DialogueNode_Character_ObjectField
                );
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
                View.DialogueNodeStitcher.CreateElement(Node);
            }

            void AddElementsToContainer()
            {
                contentContainer.Add(View.CharacterObjectFieldView.Field);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}