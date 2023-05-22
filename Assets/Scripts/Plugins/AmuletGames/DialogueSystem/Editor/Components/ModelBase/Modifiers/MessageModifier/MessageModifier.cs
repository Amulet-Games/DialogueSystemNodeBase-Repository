using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class MessageModifier
    {
        /// <summary>
        /// The modifier's folder.
        /// </summary>
        public FolderModel Folder;


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
        /// Text field model for the message's text.
        /// </summary>
        LanguageTextFieldModel messageTextModel;


        /// <summary>
        /// Object field model for the message's audio.
        /// </summary>
        LanguageObjectFieldModel<AudioClip> messageAudioObjectModel;


        /// <summary>
        /// Enum model for the users to choose how do they want to progress to the next message.
        /// </summary>
        MessageProgressTypeEnumFieldModel progressTypeEnumModel;


        /// <summary>
        /// Float model for the duration message progress type's actual duration value. 
        /// </summary>
        //CommonFloatFieldModel durationFloatModel;


        /// <summary>
        /// CSV GUID.
        /// </summary>
        string csvGUID;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the message modifier component class.
        /// </summary>
        public MessageModifier()
        {
            Folder = new();
            
            messageTextModel = new(
                placeholderText: StringConfig.Instance.DialogueSegmentTextlinePlaceholderText);
            
            messageAudioObjectModel = new();

            csvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public void CreateInstanceElements
        (
            int index,
            MessageModifierData data,
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
                FolderPresenter.CreateElement
                (
                    model: Folder,
                    titleText: StringUtility.New(
                                   text01: StringConfig.Instance.MessageModifier_Folder_TitleText,
                                   text02: index.ToString()).ToString()
                );

                new FolderCallback(folder: Folder).RegisterEvents();
            }

            void SetupContainers()
            {
                modifierButtonContainer = new();
                modifierButtonContainer.AddToClassList(StyleConfig.Instance.Modifier_Message_Button_Container);

                progressTypeBox = new();
                progressTypeBox.AddToClassList(StyleConfig.Instance.Modifier_Message_ProgressType_Box);
            }

            void SetupMoveUpButton()
            {
                moveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Message_MoveUp_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: moveUpButton,
                    clickEvent: evt => moveUpButtonClickAction(this)).RegisterEvents();
            }

            void SetupMoveDownButton()
            {
                moveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Message_MoveDown_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: moveDownButton,
                    clickEvent: evt => moveDownButtonClickAction(this)).RegisterEvents();
            }

            void SetupRenameButton()
            {
                renameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.EditButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Message_Rename_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: renameButton,
                    clickEvent: evt => renameButtonClickAction(this)).RegisterEvents();
            }

            void SetupRemoveButton()
            {
                removeButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Message_Remove_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: removeButton,
                    clickEvent: evt => removeButtonClickAction(this)).RegisterEvents();
            }

            void SetupMessageTextField()
            {
                messageTextModel.TextField = LanguageTextFieldPresenter.CreateElement
                (
                    isMultiLine: true,
                    placeholderText: messageTextModel.PlaceholderText,
                    fieldUSS01: StyleConfig.Instance.Modifier_Message_Text_TextField
                );

                new LanguageTextFieldCallback(model: messageTextModel).RegisterEvents();
            }

            void SetupMessageTextFieldIcon()
            {
                messageTextModel.TextField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.Instance.SpriteConfig.TextFieldIcon1Sprite
                );
            }

            void SetupMessageAudioObjectField()
            {
                messageAudioObjectModel.ObjectField =
                    LanguageObjectFieldPresenter.CreateElement<AudioClip>
                    (
                        fieldUSS01: StyleConfig.Instance.Modifier_Message_Audio_ObjectField
                    );

                new LanguageObjectFieldCallback<AudioClip>(
                    model: messageAudioObjectModel).RegisterEvents();
            }

            void SetupMessageAudioObjectFieldIcon()
            {
                messageAudioObjectModel.ObjectField.RemoveFieldIcon();
                messageAudioObjectModel.ObjectField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.Instance.SpriteConfig.AudioClipFieldIconSprite
                );
            }

            void SetupProgressTypeLabel()
            {
                progressTypeLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.Instance.MessageModifierProgressTypeLabelText,
                    labelUSS01: StyleConfig.Instance.Modifier_Message_ProgressType_Label
                );
            }

            void SetupProgressTypeEnumField()
            {
                progressTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: progressTypeEnumModel,
                    containerValueChangedAction: ProgressTypeEnumContainerValueChangedAction,
                    fieldUSS01: StyleConfig.Instance.Modifier_Message_ProgressType_EnumField
                );
            }

            void CheckSourceValues()
            {
                if (data != null)
                    Load(data);
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
                Folder.AddElementToContent(messageTextModel.TextField);
                Folder.AddElementToContent(messageAudioObjectModel.ObjectField);
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
        /// Save the modifier values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void Save(MessageModifierData data)
        {
            SaveFolder();

            SaveMessageText();

            SaveMessageAudio();

            Save_CSV_GUID();

            void SaveFolder()
            {
                Folder.Save(data.FolderData);
            }

            void SaveMessageText()
            {
                messageTextModel.Save(data.MessageText);
            }

            void SaveMessageAudio()
            {
                messageAudioObjectModel.Save(data.MessageAudio);
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                data.CsvGUID = csvGUID;
            }
        }


        /// <summary>
        /// Load the modifier values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void Load(MessageModifierData data)
        {
            LoadFolder();

            LoadMessageText();

            LoadMessageAudio();

            Load_CSV_Guid();

            void LoadFolder()
            {
                Folder.Load(data.FolderData);
            }

            void LoadMessageText()
            {
                messageTextModel.Load(data.MessageText);
            }

            void LoadMessageAudio()
            {
                messageAudioObjectModel.Load(data.MessageAudio);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                csvGUID = data.CsvGUID;
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