using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierView
    {
        /// <summary>
        /// The modifier's folder.
        /// </summary>
        public FolderView FolderView;


        /// <summary>
        /// Button that move the modifier up one position when clicked.
        /// </summary>
        public Button MoveUpButton;


        /// <summary>
        /// Button that move the modifier down one position when clicked.
        /// </summary>
        public Button MoveDownButton;


        /// <summary>
        /// Button that rename the modifier when clicked.
        /// </summary>
        public Button RenameButton;


        /// <summary>
        /// Button that remove the modifier when clicked.
        /// </summary>
        public Button RemoveButton;


        /// <summary>
        /// View for the dialogue event object field.
        /// </summary>
        public CommonObjectFieldView<DialogueEvent> DialogueEventObjectFieldView;


        /// <summary>
        /// View for the delay seconds integer field.
        /// </summary>
        public CommonIntegerFieldView DelaySecondsIntegerFieldView;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier component class.
        /// </summary>
        public EventModifierView()
        {
            FolderView = new();
            DialogueEventObjectFieldView = new();
            DelaySecondsIntegerFieldView = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public void SaveModifierValue(EventModifierData data)
        {
            SaveFolder();

            SaveDialogueEvent();

            SaveDelaySecondsInteger();

            void SaveFolder()
            {
                FolderView.Save(data.FolderData);
            }

            void SaveDialogueEvent()
            {
                data.DialogueEventData = DialogueEventObjectFieldView.Value;
            }

            void SaveDelaySecondsInteger()
            {
                data.DelaySecondsIntegerData = DelaySecondsIntegerFieldView.IntegerField.value;
            }
        }


        /// <summary>
        /// Load the modifier values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void LoadModifierValue(EventModifierData data)
        {
            LoadFolder();

            LoadDialogueEvent();

            LoadDelaySecondsInteger();

            void LoadFolder()
            {
                FolderView.Load(data: data.FolderData);
            }

            void LoadDialogueEvent()
            {
                DialogueEventObjectFieldView.Load(data: data.DialogueEventData);
            }

            void LoadDelaySecondsInteger()
            {
                DelaySecondsIntegerFieldView.Load(data: data.DelaySecondsIntegerData);
            }
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Setting the enable status of the move up button.
        /// </summary>
        /// <param name="value">The enable status to set to.</param>
        public void SetEnabledMoveUpButton(bool value) => MoveUpButton.SetEnabled(value: value);


        /// <summary>
        /// Setting the enable status of the move down button.
        /// </summary>
        /// <param name="value">The enable status to set to.</param>
        public void SetEnabledMoveDownButton(bool value) => MoveDownButton.SetEnabled(value: value);


        /// <summary>
        /// Setting the enable status of the remove button.
        /// </summary>
        /// <param name="value">The enable status to set to.</param>
        public void SetEnabledRemoveButton(bool value) => RemoveButton.SetEnabled(value: value);
    }
}