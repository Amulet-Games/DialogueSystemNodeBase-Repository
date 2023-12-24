using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierPresenter
    {
        /// <summary>
        /// Create the elements for the event modifier.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="index">The index of the modifier to set for.</param>
        public static void CreateElement
        (
            EventModifierView view,
            int index
        )
        {
            VisualElement helperButtonsContainer;
            VisualElement dialogueEventContainer;
            VisualElement startDelayContainer;
            VisualElement delaySecondsContainer;

            Label dialogueEventLabel;
            Label startDelayLabel;
            Label delaySecondsLabel;

            Image dialogueEventImage;

            CreateFolder();

            CreateContainers();

            CreateMoveUpButton();

            CreateMoveDownButton();

            CreateRenameButton();

            CreateRemoveButton();

            CreateDialogueEventLabel();

            CreateDialogueEventField();

            CreateDialogueEventImage();

            CreateStartDelayLabel();

            CreateDelaySecondsField();

            CreateDelaySecondsLabel();

            AddElementsToContainer();

            void CreateFolder()
            {
                view.Folder = FolderPresenter.CreateElement
                (
                    StringConfig.EventModifier_FolderTitleField_DefaultText.Append(index.ToString())
                );
            }

            void CreateContainers()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.EventModifier_HelperButton_Container);

                dialogueEventContainer = new();
                dialogueEventContainer.AddToClassList(StyleConfig.EventModifier_DialogueEvent_Container);

                startDelayContainer = new();
                startDelayContainer.AddToClassList(StyleConfig.EventModifier_StartDelay_Container);

                delaySecondsContainer = new();
                delaySecondsContainer.AddToClassList(StyleConfig.EventModifier_DelaySeconds_Container);
            }

            void CreateMoveUpButton()
            {
                view.MoveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateDialogueEventLabel()
            {
                dialogueEventLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_DialogueEventLabel_LabelText,
                    labelUSS: StyleConfig.EventModifier_DialogueEvent_Label
                );
            }

            void CreateDialogueEventField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: view.DialogueEventFieldView,
                    fieldUSS01: StyleConfig.EventModifier_DialogueEvent_Field
                );
            }

            void CreateDialogueEventImage()
            {
                dialogueEventImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.DialogueEventFieldSprite,
                    imageUSS01: StyleConfig.EventModifier_DialogueEvent_Image
                );

                view.DialogueEventFieldView.Field.SetDisplayImage(dialogueEventImage);
            }

            void CreateStartDelayLabel()
            {
                startDelayLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_StartDelay_LabelText,
                    labelUSS: StyleConfig.EventModifier_StartDelay_Label
                );
            }

            void CreateDelaySecondsField()
            {
                CommonFloatFieldPresenter.CreateElement
                (
                    view: view.DelaySecondsFieldView,
                    fieldUSS: StyleConfig.EventModifier_DelaySeconds_Field
                );
            }

            void CreateDelaySecondsLabel()
            {
                delaySecondsLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_DelaySeconds_LabelText,
                    labelUSS: StyleConfig.EventModifier_DelaySeconds_Label
                );
            }

            void AddElementsToContainer()
            {
                // Helper buttons
                view.Folder.AddElementToTitle(helperButtonsContainer);
                helperButtonsContainer.Add(view.MoveUpButton);
                helperButtonsContainer.Add(view.MoveDownButton);
                helperButtonsContainer.Add(view.RenameButton);
                helperButtonsContainer.Add(view.RemoveButton);

                // Dialogue event
                view.Folder.AddElementToContent(dialogueEventContainer);
                dialogueEventContainer.Add(dialogueEventLabel);
                dialogueEventContainer.Add(view.DialogueEventFieldView.Field);

                // Start delay
                view.Folder.AddElementToContent(startDelayContainer);
                startDelayContainer.Add(startDelayLabel);
                startDelayContainer.Add(delaySecondsContainer);

                // Delay seconds
                delaySecondsContainer.Add(view.DelaySecondsFieldView.Field);
                delaySecondsContainer.Add(delaySecondsLabel);
            }
        }
    }
}