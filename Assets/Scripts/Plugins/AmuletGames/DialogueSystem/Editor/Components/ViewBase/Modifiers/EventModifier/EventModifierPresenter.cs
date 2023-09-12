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

            VisualElement dialogueEventLabel;
            VisualElement startDelayLabel;
            VisualElement delaySecondsLabel;

            SetupFolder();

            SetupContainers();

            SetupMoveUpButton();

            SetupMoveDownButton();

            SetupRenameButton();

            SetupRemoveButton();

            SetupDialogueEventLabel();

            SetupDialogueEventField();

            SetupDialogueEventFieldIcon();

            SetupStartDelayLabel();

            SetupDelaySecondsField();

            SetupDelaySecondsLabel();

            AddElementsToContainer();

            void SetupFolder()
            {
                view.Folder = FolderPresenter.CreateElement
                (
                    folderTitle: StringUtility.New
                    (
                        str01: StringConfig.EventModifier_FolderTitleField_DefaultText,
                        str02: index.ToString()
                    )
                );
            }

            void SetupContainers()
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

            void SetupMoveUpButton()
            {
                view.MoveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void SetupMoveDownButton()
            {
                view.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void SetupRenameButton()
            {
                view.RenameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void SetupRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.EventModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void SetupDialogueEventLabel()
            {
                dialogueEventLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_DialogueEventLabel_LabelText,
                    labelUSS: StyleConfig.EventModifier_DialogueEvent_Label
                );
            }

            void SetupDialogueEventField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: view.DialogueEventFieldView,
                    fieldUSS01: StyleConfig.EventModifier_DialogueEvent_Field
                );
            }

            void SetupDialogueEventFieldIcon()
            {
                view.DialogueEventFieldIcon = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.EventFieldIconSprite,
                    imageUSS01: StyleConfig.Object_Field_Display_Image
                );

                view.DialogueEventFieldView.Field.SetDisplayImage(view.DialogueEventFieldIcon);
            }

            void SetupStartDelayLabel()
            {
                startDelayLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_StartDelay_LabelText,
                    labelUSS: StyleConfig.EventModifier_StartDelay_Label
                );
            }

            void SetupDelaySecondsField()
            {
                CommonDoubleFieldPresenter.CreateElement
                (
                    view: view.DelaySecondsFieldView,
                    fieldUSS: StyleConfig.EventModifier_DelaySeconds_Field
                );
            }

            void SetupDelaySecondsLabel()
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

                // Dialogue Event Container
                view.Folder.AddElementToContent(dialogueEventContainer);
                dialogueEventContainer.Add(dialogueEventLabel);
                dialogueEventContainer.Add(view.DialogueEventFieldView.Field);

                // Start Delay Container.
                view.Folder.AddElementToContent(startDelayContainer);
                startDelayContainer.Add(startDelayLabel);
                startDelayContainer.Add(delaySecondsContainer);

                // Delay Seconds Container.
                delaySecondsContainer.Add(view.DelaySecondsFieldView.Field);
                delaySecondsContainer.Add(delaySecondsLabel);
            }
        }
    }
}