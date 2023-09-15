using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierView
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
        /// View for the dialogue event field.
        /// </summary>
        public CommonObjectFieldView<DialogueEvent> DialogueEventFieldView;


        /// <summary>
        /// Image for the dialogue event field.
        /// </summary>
        public Image DialogueEventImage;


        /// <summary>
        /// View for the delay seconds field.
        /// </summary>
        public CommonDoubleFieldView DelaySecondsFieldView;


        /// <summary>
        /// Constructor of the event modifier class.
        /// </summary>
        public EventModifierView()
        {
            DialogueEventFieldView = new(
                placeholderText: StringConfig.EventModifier_DialogueEventField_PlaceholderText
            );

            DelaySecondsFieldView = new(
                maxValue: NumberConfig.MAX_DELAY_SECOND,
                minValue: NumberConfig.MIN_DELAY_SECOND
            );
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