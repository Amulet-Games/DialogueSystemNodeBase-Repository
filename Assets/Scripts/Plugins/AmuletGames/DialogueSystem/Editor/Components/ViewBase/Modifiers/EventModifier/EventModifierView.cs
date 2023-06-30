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
                FolderView.Save(model.FolderModel);
            }

            void SaveDialogueEvent()
            {
                model.DialogueEvent = DialogueEventObjectFieldView.Value;
            }

            void SaveDelaySecondsInteger()
            {
                model.DelaySecondsInteger = DelaySecondsIntegerFieldView.IntegerField.value;
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
                FolderView.Load(model: model.FolderModel);
            }

            void LoadDialogueEvent()
            {
                DialogueEventObjectFieldView.Load(value: model.DialogueEvent);
            }

            void LoadDelaySecondsInteger()
            {
                DelaySecondsIntegerFieldView.Load(value: model.DelaySecondsInteger);
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