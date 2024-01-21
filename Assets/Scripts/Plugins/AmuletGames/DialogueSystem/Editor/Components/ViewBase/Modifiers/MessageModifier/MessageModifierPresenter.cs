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
            VisualElement continueByStartDelayContainer;
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
                    folderTitle: StringConfig.MessageModifier_FolderTitleField_DefaultText.Append(index.ToString())
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

                continueByStartDelayContainer = new();
                continueByStartDelayContainer.AddToClassList(StyleConfig.MessageModifier_ContinueBy_StartDelay_Container);

                continueByContainer = new();
                continueByContainer.AddToClassList(StyleConfig.MessageModifier_ContinueBy_Container);

                startDelayContainer = new();
                startDelayContainer.AddToClassList(StyleConfig.MessageModifier_StartDelay_Container);

                delaySecondsContainer = new();
                delaySecondsContainer.AddToClassList(StyleConfig.MessageModifier_DelaySeconds_Container);
            }

            void CreateMoveUpButton()
            {
                view.MoveUpButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    USS: StyleConfig.MessageModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    USS: StyleConfig.MessageModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    USS: StyleConfig.MessageModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.MessageModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateMessageTextLabel()
            {
                messageTextLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.MessageModifier_MessageTextLabel_LabelText,
                    USS: StyleConfig.MessageModifier_MessageText_Label
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
                    sprite: ConfigResourcesManager.SpriteConfig.MessageTextFieldSprite,
                    USS01: StyleConfig.MessageModifier_MessageText_Image
                );

                view.MessageTextFieldView.Field.SetDisplayImage(messageTextImage);
            }

            void CreateMessageAudioLabel()
            {
                messageAudioLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.MessageModifier_MessageAudioLabel_LabelText,
                    USS: StyleConfig.MessageModifier_MessageAudio_Label
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
                    sprite: ConfigResourcesManager.SpriteConfig.MessageAudioFieldSprite,
                    USS01: StyleConfig.MessageModifier_MessageAudio_Image
                );

                view.MessageAudioFieldView.Field.SetDisplayImage(messageAudioImage);
            }
        
            void CreateContinueByLabel()
            {
                continueByLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.MessageModifier_ContinueBy_LabelText,
                    USS: StyleConfig.MessageModifier_ContinueBy_Label
                );
            }

            void CreateContinueByRadioGroup()
            {
                var continueByInputRadio = RadioPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_ContinueByInput_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.ContinueByInputSprite
                );

                var continueByAutoRadio = RadioPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifier_ContinueByAuto_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.ContinueByAutoSprite
                );

                var radios = new[]
                {
                    continueByAutoRadio,
                    continueByInputRadio
                };

                view.ContinueByRadioGroup = RadioGroupPresenter.CreateElement(radios);
            }

            void CreateStartDelayLabel()
            {
                startDelayLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.MessageModifier_StartDelay_LabelText,
                    USS: StyleConfig.MessageModifier_StartDelay_Label
                );
            }

            void CreateDelaySecondsField()
            {
                CommonFloatFieldPresenter.CreateElement
                (
                    view: view.DelaySecondsFieldView,
                    fieldUSS: StyleConfig.MessageModifier_DelaySeconds_Field
                );
            }

            void CreateDelaySecondsLabel()
            {
                delaySecondsLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.MessageModifier_DelaySeconds_LabelText,
                    USS: StyleConfig.MessageModifier_DelaySeconds_Label
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

                // Continue by & Start delay
                view.Folder.AddElementToContent(continueByStartDelayContainer);

                // Continue by
                continueByStartDelayContainer.Add(continueByContainer);
                continueByContainer.Add(continueByLabel);
                continueByContainer.Add(view.ContinueByRadioGroup);

                // Start delay
                continueByStartDelayContainer.Add(startDelayContainer);
                startDelayContainer.Add(startDelayLabel);
                startDelayContainer.Add(delaySecondsContainer);

                // Delay seconds
                delaySecondsContainer.Add(view.DelaySecondsFieldView.Field);
                delaySecondsContainer.Add(delaySecondsLabel);
            }
        }
    }
}