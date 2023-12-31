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
            VisualElement dialogueSpeakerMainContainer;
            VisualElement dialogueSpeakerOuterContainer;
            VisualElement dialogueSpeakerInnerContainer;

            Image dialogueSpeakerImage;
            Label dialogueSpeakerLabel;

            CreateContentButton();

            CreateContainers();

            CreateDialogueSpeakerImage();

            CreateDialogueSpeakerLabel();

            CreateDialogueSpeakerField();

            CreateMessageModifierGroup();

            AddElementsToContainer();

            AddContainersToNode();

            void CreateContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddMessage_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddMessageButtonIconSprite
                );
            }

            void CreateContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                dialogueSpeakerMainContainer = new();
                dialogueSpeakerMainContainer.AddToClassList(StyleConfig.DialogueNode_DialogueSpeaker_Main_Container);

                dialogueSpeakerOuterContainer = new();
                dialogueSpeakerOuterContainer.AddToClassList(StyleConfig.DialogueNode_DialogueSpeaker_Outer_Container);

                dialogueSpeakerInnerContainer = new();
                dialogueSpeakerInnerContainer.AddToClassList(StyleConfig.DialogueNode_DialogueSpeaker_Inner_Container);
            }

            void CreateDialogueSpeakerImage()
            {
                dialogueSpeakerImage = CommonImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.DialogueSpeakerFieldSprite,
                    USS01: StyleConfig.DialogueNode_DialogueSpeaker_Image
                );
            }

            void CreateDialogueSpeakerLabel()
            {
                dialogueSpeakerLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.DialogueNode_DialogueSpeakerLabel_LabelText,
                    USS: StyleConfig.DialogueNode_DialogueSpeaker_Label
                );
            }

            void CreateDialogueSpeakerField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: View.DialogueSpeakerFieldView,
                    fieldUSS01: StyleConfig.DialogueNode_DialogueSpeaker_Field
                );
            }
            
            void CreateMessageModifierGroup()
            {
                MessageModifierGroupPresenter.CreateElement(view: View.MessageModifierGroupView);
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

                contentContainer.Add(View.DialogueSpeakerFieldView.Field);

                dialogueSpeakerOuterContainer.Add(dialogueSpeakerImage);
                dialogueSpeakerOuterContainer.Add(dialogueSpeakerInnerContainer);

                dialogueSpeakerInnerContainer.Add(dialogueSpeakerLabel);
                dialogueSpeakerInnerContainer.Add(View.DialogueSpeakerFieldView.Field);

                dialogueSpeakerMainContainer.Add(dialogueSpeakerOuterContainer);

                contentContainer.Add(dialogueSpeakerMainContainer);
                contentContainer.Add(View.MessageModifierGroupView.GroupContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}