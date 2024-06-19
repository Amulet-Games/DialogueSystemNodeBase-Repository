namespace AG.DS
{
    public class EventModifierViewSerializer
    {
        /// <summary>
        /// Save the event modifier view values.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="data">The event modifier view data to set for.</param>
        public static void Save
        (
            EventModifierView view,
            EventModifierViewData data
        )
        {
            SaveFolder();

            SaveDialogueEvent();

            SaveDelaySecondsInteger();

            void SaveFolder()
            {
                view.Folder.Save(data.FolderData);
            }

            void SaveDialogueEvent()
            {
                data.DialogueEvent = view.DialogueEventFieldView.Value;
            }

            void SaveDelaySecondsInteger()
            {
                data.DelaySeconds = view.DelaySecondsFieldView.Value;
            }
        }


        /// <summary>
        /// Load the event modifier view values.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="data">The event modifier view data to set for.</param>
        public static void Load
        (
            EventModifierView view,
            EventModifierViewData data
        )
        {
            LoadFolder();

            LoadDialogueEvent();

            LoadDelaySecondsInteger();

            void LoadFolder()
            {
                view.Folder.Load(data: data.FolderData);
            }

            void LoadDialogueEvent()
            {
                view.DialogueEventFieldView.Load(value: data.DialogueEvent);
            }

            void LoadDelaySecondsInteger()
            {
                view.DelaySecondsFieldView.Load(value: data.DelaySeconds);
            }
        }
    }
}