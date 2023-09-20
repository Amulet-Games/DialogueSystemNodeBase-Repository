using UnityEngine.UIElements;

namespace AG.DS
{
    public class MessageModifierPresenter
    {
        /// <summary>
        /// Create the elements for the message modifier.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="index">The index of the modifier to set for.</param>
        public static void CreateElement
        (
            MessageModifierView view,
            int index
        )
        {
            VisualElement helperButtonsContainer;
            VisualElement messageTextContainer;
            VisualElement messageAudioContainer;
            VisualElement continueByContainer;
            VisualElement startDelayContainer;
            VisualElement delaySecondsContainer;

            Label messageTextLabel;
            Label messageAudioLabel;
            Label continueByLabel;
            Label startDelayLabel;
            Label delaySecondsLabel;

            Image messageTextImage;
            Image messageAudioImage;

            CreateFolder();

            CreateContainers();

            CreateMoveUpButton();

            CreateMoveDownButton();

            CreateRenameButton();

            CreateRemoveButton();

            CreateMessageTextLabel();

            CreateMessageTextField();

            CreateMessageTextImage();

            CreateMessageAudioLabel();

            CreateMessageAudioField();

            CreateMessageAudioImage();

            CreateContinueByLabel();

            CreateContinueByRadioGroup();

            CreateStartDelayLabel();

            CreateDelaySecondsField();

            CreateDelaySecondsLabel();

            AddElementsToContainer();

            void CreateFolder()
            {
                view.Folder = FolderPresenter.CreateElement
                (
                    folderTitle: StringUtility.New
                    (
                        str01: StringConfig.MessageModifier_FolderTitleField_DefaultText,
                        str02: index.ToString()
                    )
                );
            }
            
            void CreateContainers()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.MessageModifier_HelperButton_Container);

                messageTextContainer = new();
                messageTextContainer.AddToClassList(StyleConfig.MessageModifier_MessageText_Container);

                messageAudioContainer = new();
                messageAudioContainer.AddToClassList(StyleConfig.MessageModifier_MessageAudio_Container);

                continueByContainer = new();
                continueByContainer.AddToClassList(StyleConfig.MessageModifier_ContinueBy_Container);

                startDelayContainer = new();
                startDelayContainer.AddToClassList(StyleConfig.MessageModifier_StartDelay_Container);

                delaySecondsContainer = new();
                delaySecondsContainer.AddToClassList(StyleConfig.MessageModifier_DelaySeconds_Container);
            }

            void CreateMoveUpButton()
            {
                view.MoveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS: StyleConfig.MessageModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS: StyleConfig.MessageModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.MessageModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.MessageModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateMessageTextLabel()
            {
                messageTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_MessageTextLabel_LabelText,
                    labelUSS: StyleConfig.MessageModifier_MessageText_Label
                );
            }

            void CreateMessageTextField()
            {
                LanguageTextFieldPresenter.CreateElement
                (
                    view: view.MessageTextFieldView,
                    multiline: true,
                    fieldUSS: StyleConfig.MessageModifier_MessageText_Field
                );
            }

            void CreateMessageTextImage()
            {
                messageTextImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.MessageTextFieldSprite,
                    imageUSS01: StyleConfig.MessageModifier_MessageText_Image
                );
            }

            void CreateMessageAudioLabel()
            {
                messageAudioLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_MessageAudioLabel_LabelText,
                    labelUSS: StyleConfig.MessageModifier_MessageAudio_Label
                );
            }

            void CreateMessageAudioField()
            {
                LanguageObjectFieldPresenter.CreateElement
                (
                    view: view.MessageAudioFieldView,
                    fieldUSS01: StyleConfig.MessageModifier_MessageAudio_Field
                );
            }

            void CreateMessageAudioImage()
            {
                messageAudioImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.MessageAudioFieldSprite,
                    imageUSS01: StyleConfig.MessageModifier_MessageAudio_Image
                );
            }
        
            void CreateContinueByLabel()
            {
                continueByLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_ContinueBy_LabelText,
                    labelUSS: StyleConfig.MessageModifier_ContinueBy_Label
                );
            }

            void CreateContinueByRadioGroup()
            {
                var continueByInputRadio = RadioPresenter.CreateElement
                (
                    radioText: StringConfig.MessageModifier_ContinueByInput_LabelText,
                    radioSprite: ConfigResourcesManager.SpriteConfig.ContinueByInputSprite
                );

                var continueByAutoRadio = RadioPresenter.CreateElement
                (
                    radioText: StringConfig.MessageModifier_ContinueByAuto_LabelText,
                    radioSprite: ConfigResourcesManager.SpriteConfig.ContinueByAutoSprite
                );

                var radios = new[]{
                    continueByInputRadio,
                    continueByAutoRadio
                };

                view.ContinueByRadioGroup = RadioGroupPresenter.CreateElement(radios);
            }

            void CreateStartDelayLabel()
            {
                startDelayLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_StartDelay_LabelText,
                    labelUSS: StyleConfig.MessageModifier_StartDelay_Label
                );
            }

            void CreateDelaySecondsField()
            {
                CommonDoubleFieldPresenter.CreateElement
                (
                    view: view.DelaySecondsFieldView,
                    fieldUSS: StyleConfig.MessageModifier_DelaySeconds_Field
                );
            }

            void CreateDelaySecondsLabel()
            {
                delaySecondsLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_DelaySeconds_LabelText,
                    labelUSS: StyleConfig.MessageModifier_DelaySeconds_Label
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

                // Message text
                view.Folder.AddElementToContent(messageTextContainer);
                messageTextContainer.Add(messageTextLabel);
                messageTextContainer.Add(view.MessageTextFieldView.Field);

                // Message audio
                view.Folder.AddElementToContent(messageAudioContainer);
                messageAudioContainer.Add(messageAudioLabel);
                messageAudioContainer.Add(view.MessageAudioFieldView.Field);

                // Continue by
                view.Folder.AddElementToContent(continueByContainer);
                continueByContainer.Add(continueByLabel);
                continueByContainer.Add(view.ContinueByRadioGroup);

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