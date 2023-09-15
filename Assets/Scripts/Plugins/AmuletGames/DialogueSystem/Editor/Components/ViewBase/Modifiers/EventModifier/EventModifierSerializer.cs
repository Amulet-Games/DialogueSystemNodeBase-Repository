namespace AG.DS
{
    public class EventModifierSerializer
    {
        /// <summary>
        /// Save the event modifier values.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="model">The event modifier model to set for.</param>
        public void Save
        (
            EventModifierView view,
            EventModifierModel model
        )
        {
            SaveFolder();

            SaveDialogueEvent();

            SaveDelaySecondsInteger();

            void SaveFolder()
            {
                view.Folder.Save(model.FolderModel);
            }

            void SaveDialogueEvent()
            {
                model.DialogueEvent = view.DialogueEventFieldView.Value;
            }

            void SaveDelaySecondsInteger()
            {
                model.DelaySeconds = view.DelaySecondsFieldView.Value;
            }
        }


        /// <summary>
        /// Load the event modifier values.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="model">The event modifier model to set for.</param>
        public void Load
        (
            EventModifierView view,
            EventModifierModel model
        )
        {
            LoadFolder();

            LoadDialogueEvent();

            LoadDelaySecondsInteger();

            void LoadFolder()
            {
                view.Folder.Load(model: model.FolderModel);
            }

            void LoadDialogueEvent()
            {
                view.DialogueEventFieldView.Load(value: model.DialogueEvent);
            }

            void LoadDelaySecondsInteger()
            {
                view.DelaySecondsFieldView.Load(value: model.DelaySeconds);
            }
        }
    }
}