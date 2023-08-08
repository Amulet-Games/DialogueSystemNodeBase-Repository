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
        public Image DialogueEventFieldIcon;


        /// <summary>
        /// View for the delay seconds field.
        /// </summary>
        public CommonDoubleFieldView DelaySecondsFieldView;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier component class.
        /// </summary>
        public EventModifierView()
        {
            DialogueEventFieldView = new(
                placeholderText: StringConfig.EventModifier_DialogueEventObjectField_PlaceholderText);

            DelaySecondsFieldView = new(
                maxValue: NumberConfig.MAX_DELAY_SECOND,
                minValue: NumberConfig.MIN_DELAY_SECOND
            );
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the event modifier model.
        /// </summary>
        /// <param name="model">The event modifier model to set for.</param>
        public void SaveModifierValue(EventModifierModel model)
        {
            SaveFolder();

            SaveDialogueEvent();

            SaveDelaySecondsInteger();

            void SaveFolder()
            {
                Folder.Save(model.FolderModel);
            }

            void SaveDialogueEvent()
            {
                model.DialogueEvent = DialogueEventFieldView.Value;
            }

            void SaveDelaySecondsInteger()
            {
                model.DelaySeconds = DelaySecondsFieldView.Value;
            }
        }


        /// <summary>
        /// Load the modifier values from the event modifier model.
        /// </summary>
        /// <param name="model">The event modifier model to set for.</param>
        public void LoadModifierValue(EventModifierModel model)
        {
            LoadFolder();

            LoadDialogueEvent();

            LoadDelaySecondsInteger();

            void LoadFolder()
            {
                Folder.Load(model: model.FolderModel);
            }

            void LoadDialogueEvent()
            {
                DialogueEventFieldView.Load(value: model.DialogueEvent);
            }

            void LoadDelaySecondsInteger()
            {
                DelaySecondsFieldView.Load(value: model.DelaySeconds);
            }
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