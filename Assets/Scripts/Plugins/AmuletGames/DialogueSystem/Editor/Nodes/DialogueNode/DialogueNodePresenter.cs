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

            AddSpeakerObjectField();

            AddCharacterObjectFieldIcon();

            AddDialogueNodeStitcher();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddMessage_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddMessageButtonIconSprite
                );
            }

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void AddSpeakerObjectField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: View.DialogueSpeakerFieldView,
                    fieldUSS01: StyleConfig.DialogueNode_Speaker_ObjectField
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
                View.MessageModifierGroupView.CreateElement(Node);
            }

            void AddElementsToContainer()
            {
                contentContainer.Add(View.DialogueSpeakerFieldView.Field);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}