using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierModel
    {
        /// <summary>
        /// The modifier's folder.
        /// </summary>
        public FolderModel FolderModel;


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
        /// Model for the dialogue event object field.
        /// </summary>
        public CommonObjectFieldModel<DialogueEvent> DialogueEventObjectFieldModel;


        /// <summary>
        /// Model for the delay seconds integer field.
        /// </summary>
        public CommonIntegerFieldModel DelaySecondsIntegerFieldModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier component class.
        /// </summary>
        public EventModifierModel()
        {
            FolderModel = new();
            DialogueEventObjectFieldModel = new();
            DelaySecondsIntegerFieldModel = new();
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
                FolderModel.Save(data.FolderData);
            }

            void SaveDialogueEvent()
            {
                data.DialogueEventData = DialogueEventObjectFieldModel.Value;
            }

            void SaveDelaySecondsInteger()
            {
                data.DelaySecondsIntegerData = DelaySecondsIntegerFieldModel.IntegerField.value;
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
                FolderModel.Load(data: data.FolderData);
            }

            void LoadDialogueEvent()
            {
                DialogueEventObjectFieldModel.Load(data: data.DialogueEventData);
            }

            void LoadDelaySecondsInteger()
            {
                DelaySecondsIntegerFieldModel.Load(data: data.DelaySecondsIntegerData);
            }
        }


        // ----------------------------- Set Enabled Button -----------------------------
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