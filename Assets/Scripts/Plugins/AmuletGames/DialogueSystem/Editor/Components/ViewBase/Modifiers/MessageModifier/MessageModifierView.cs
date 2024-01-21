using System;
using UnityEngine;

namespace AG.DS
{
    public class MessageModifierView
    {
        /// <summary>
        /// Folder that contains the modifier's elements.
        /// </summary>
        public Folder Folder;


        /// <summary>
        /// Button that moves the modifier up one position when clicked.
        /// </summary>
        public Button MoveUpButton;


        /// <summary>
        /// Button that moves the modifier down one position when clicked.
        /// </summary>
        public Button MoveDownButton;


        /// <summary>
        /// Button that renames the modifier when clicked.
        /// </summary>
        public Button RenameButton;


        /// <summary>
        /// Button that removes the modifier when clicked.
        /// </summary>
        public Button RemoveButton;


        /// <summary>
        /// View for the message text field.
        /// </summary>
        public LanguageTextFieldView MessageTextFieldView;


        /// <summary>
        /// View for the message audio field.
        /// </summary>
        public LanguageObjectFieldView<AudioClip> MessageAudioFieldView;


        /// <summary>
        /// Radio group for the continue by radio elements.
        /// </summary>
        public RadioGroup ContinueByRadioGroup;


        /// <summary>
        /// View for the delay seconds field.
        /// </summary>
        public CommonFloatFieldView DelaySecondsFieldView;


        /// <summary>
        /// Message CSV Guid.
        /// </summary>
        public Guid MessageCSVGuid;


        /// <summary>
        /// Constructor of the message modifier view class.
        /// </summary>
        public MessageModifierView(LanguageHandler languageHandler)
        {
            MessageTextFieldView = new(
                placeholderText: StringConfig.MessageModifier_MessageTextField_PlaceholderText,
                languageHandler
            );

            MessageAudioFieldView = new(
                placeholderText: StringConfig.MessageModifier_MessageAudioField_PlaceholderText,
                languageHandler
            );

            DelaySecondsFieldView = new(
                maxValue: NumberConfig.MAX_DELAY_SECOND,
                minValue: NumberConfig.MIN_DELAY_SECOND
            );

            MessageCSVGuid = Guid.NewGuid();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Changes the move up button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveUpButton(bool value) => MoveUpButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the move down button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveDownButton(bool value) => MoveDownButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the remove button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledRemoveButton(bool value) => RemoveButton.SetEnabled(value: value);
    }
}