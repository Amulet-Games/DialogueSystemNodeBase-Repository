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
            
            //messageTextView = new(placeholderText: StringConfig.DialogueSegmentTextlinePlaceholderText);
            
            //messageAudioObjectView = new("");

            csvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values.
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
                //model.CsvGUID = csvGUID;
            }
        }


        /// <summary>
        /// Load the modifier values.
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
                //csvGUID = model.CsvGUID;
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