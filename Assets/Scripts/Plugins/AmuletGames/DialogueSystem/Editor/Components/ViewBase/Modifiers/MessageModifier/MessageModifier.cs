using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class MessageModifier
    {
        /// <summary>
        /// The modifier's folder.
        /// </summary>
        public Folder Folder;


        /// <summary>
        /// The element that contains all the modifier's helper buttons.
        /// </summary>
        VisualElement modifierButtonContainer;


        /// <summary>
        /// Button that move the modifier up one position when clicked.
        /// </summary>
        Button moveUpButton;


        /// <summary>
        /// Button that move the modifier down one position when clicked.
        /// </summary>
        Button moveDownButton;


        /// <summary>
        /// Button that rename the modifier when clicked.
        /// </summary>
        Button renameButton;


        /// <summary>
        /// Button that remove the modifier when clicked.
        /// </summary>
        Button removeButton;


        /// <summary>
        /// Text field view for the message's text.
        /// </summary>
        LanguageTextFieldView messageTextView;


        /// <summary>
        /// Object field view for the message's audio.
        /// </summary>
        LanguageObjectFieldView<AudioClip> messageAudioObjectView;


        /// <summary>
        /// Enum view for the users to choose how do they want to progress to the next message.
        /// </summary>
        MessageProgressTypeEnumFieldView progressTypeEnumView;


        /// <summary>
        /// Float view for the duration message progress type's actual duration value. 
        /// </summary>
        //CommonFloatFieldView durationFloatView;


        /// <summary>
        /// CSV GUID.
        /// </summary>
        string csvGUID;


        /// <summary>
        /// Constructor of the message modifier component class.
        /// </summary>
        public MessageModifier()
        {
            //Folder = new();
            
            messageTextView = new(placeholderText: StringConfig.DialogueSegmentTextlinePlaceholderText);
            
            messageAudioObjectView = new("");

            csvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public void CreateInstanceElements
        (
            int index,
            MessageModifierModel model,
            Action<MessageModifier> modifierCreatedAction,
            Action<MessageModifier> moveUpButtonClickAction,
            Action<MessageModifier> moveDownButtonClickAction,
            Action<MessageModifier> renameButtonClickAction,
            Action<MessageModifier> removeButtonClickAction
        )
        {
            Box progressTypeBox;
            Label progressTypeLabel;
            EnumField progressTypeEnumField;

            SetupFolder();

            SetupContainers();

            SetupMoveUpButton();

            SetupMoveDownButton();

            SetupRenameButton();

            SetupRemoveButton();

            SetupMessageTextField();

            SetupMessageTextFieldIcon();

            SetupMessageAudioObjectField();

            SetupMessageAudioObjectFieldIcon();

            CheckSourceValues();

            AddFieldsToBox();

            InvokeModifierCreatedAction();

            void SetupFolder()
            {
                Folder = FolderPresenter.CreateElement
                (
                    folderTitle: StringUtility.New(
                                   str01: StringConfig.MessageModifier_Folder_TitleText,
                                   str02: index.ToString())
                );

                new FolderObserver(folder: Folder).RegisterEvents();
            }

            void SetupContainers()
            {
                modifierButtonContainer = new();
                modifierButtonContainer.AddToClassList(StyleConfig.Modifier_Message_Button_Container);

                progressTypeBox = new();
                progressTypeBox.AddToClassList(StyleConfig.Modifier_Message_ProgressType_Box);
            }

            void SetupMoveUpButton()
            {
                moveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Message_MoveUp_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: moveUpButton,
                    clickEvent: evt => moveUpButtonClickAction(this)).RegisterEvents();
            }

            void SetupMoveDownButton()
            {
                moveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Message_MoveDown_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: moveDownButton,
                    clickEvent: evt => moveDownButtonClickAction(this)).RegisterEvents();
            }

            void SetupRenameButton()
            {
                renameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Message_Rename_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: renameButton,
                    clickEvent: evt => renameButtonClickAction(this)).RegisterEvents();
            }

            void SetupRemoveButton()
            {
                removeButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Message_Remove_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: removeButton,
                    clickEvent: evt => removeButtonClickAction(this)).RegisterEvents();
            }

            void SetupMessageTextField()
            {
                messageTextView.TextField = LanguageTextFieldPresenter.CreateElement
                (
                    isMultiLine: true,
                    placeholderText: messageTextView.PlaceholderText,
                    fieldUSS: StyleConfig.Modifier_Message_Text_TextField
                );

                new LanguageTextFieldObserver(view: messageTextView).RegisterEvents();
            }

            void SetupMessageTextFieldIcon()
            {
                messageTextView.TextField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.SpriteConfig.TextFieldIcon1Sprite
                );
            }

            void SetupMessageAudioObjectField()
            {
                LanguageObjectFieldPresenter.CreateElement<AudioClip>
                (
                    view: messageAudioObjectView,
                    fieldUSS01: StyleConfig.Modifier_Message_Audio_ObjectField
                );

                new LanguageObjectFieldObserver<AudioClip>(
                    view: messageAudioObjectView).RegisterEvents();
            }

            void SetupMessageAudioObjectFieldIcon()
            {
                //messageAudioObjectView.ObjectField.RemoveFieldIcon();
                //messageAudioObjectView.ObjectField.AddFieldIcon
                //(
                //    iconSprite: ConfigResourcesManager.SpriteConfig.AudioClipFieldIconSprite
                //);
            }

            void SetupProgressTypeLabel()
            {
                progressTypeLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.MessageModifierProgressTypeLabelText,
                    labelUSS: StyleConfig.Modifier_Message_ProgressType_Label
                );
            }

            void SetupProgressTypeEnumField()
            {
                progressTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: progressTypeEnumView,
                    containerValueChangedAction: ProgressTypeEnumContainerValueChangedAction,
                    fieldUSS: StyleConfig.Modifier_Message_ProgressType_EnumField
                );
            }

            void CheckSourceValues()
            {
                if (model != null)
                    Load(model);
            }

            void AddFieldsToBox()
            {
                // Title Side buttons.
                Folder.AddElementToTitle(modifierButtonContainer);
                modifierButtonContainer.Add(moveUpButton);
                modifierButtonContainer.Add(moveDownButton);
                modifierButtonContainer.Add(renameButton);
                modifierButtonContainer.Add(removeButton);

                // Contents.
                Folder.AddElementToContent(messageTextView.TextField);
                Folder.AddElementToContent(messageAudioObjectView.Field);
            }

            void InvokeModifierCreatedAction()
            {
                modifierCreatedAction.Invoke(this);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// 
        /// </summary>
        void ProgressTypeEnumContainerValueChangedAction()
        {
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the message modifier model.
        /// </summary>
        /// <param name="model">The message modifier model to set for.</param>
        public void Save(MessageModifierModel model)
        {
            SaveFolder();

            SaveMessageText();

            SaveMessageAudio();

            Save_CSV_GUID();

            void SaveFolder()
            {
                Folder.Save(model.FolderModel);
            }

            void SaveMessageText()
            {
                messageTextView.Save(model.MessageText);
            }

            void SaveMessageAudio()
            {
                messageAudioObjectView.Save(model.MessageAudio);
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                model.CsvGUID = csvGUID;
            }
        }


        /// <summary>
        /// Load the modifier values from the message modifier model.
        /// </summary>
        /// <param name="model">The message modifier model to set for.</param>
        public void Load(MessageModifierModel model)
        {
            LoadFolder();

            LoadMessageText();

            LoadMessageAudio();

            Load_CSV_Guid();

            void LoadFolder()
            {
                Folder.Load(model.FolderModel);
            }

            void LoadMessageText()
            {
                messageTextView.Load(model.MessageText);
            }

            void LoadMessageAudio()
            {
                messageAudioObjectView.Load(model.MessageAudio);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                csvGUID = model.CsvGUID;
            }
        }


        // ----------------------------- Set Enabled Button -----------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetEnabledMoveUpButton(bool value) => moveUpButton.SetEnabled(value: value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetEnabledMoveDownButton(bool value) => moveDownButton.SetEnabled(value: value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetEnabledRemoveButton(bool value) => removeButton.SetEnabled(value: value);
    }
}