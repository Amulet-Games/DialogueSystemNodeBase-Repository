using System;
using UnityEngine;
using UnityEngine.UIElements;

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
        /// View for the continue by field.
        /// </summary>
        public MessageProgressTypeEnumFieldView ContinueByFieldView;


        /// <summary>
        /// View for the delay seconds field.
        /// </summary>
        public CommonDoubleFieldView DelaySecondsFieldView;


        /// <summary>
        /// Message CSV Guid.
        /// </summary>
        public Guid MessageCSVGuid;


        /// <summary>
        /// Constructor of the message modifier class.
        /// </summary>
        public MessageModifierView()
        {
            MessageCSVGuid = Guid.NewGuid();
        }
    }
}