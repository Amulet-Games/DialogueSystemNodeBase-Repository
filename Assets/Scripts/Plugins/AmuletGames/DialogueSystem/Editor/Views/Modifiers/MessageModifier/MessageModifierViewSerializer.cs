namespace AG.DS
{
    public class MessageModifierViewSerializer
    {
        /// <summary>
        /// Save the message modifier view values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="data">The message modifier view data to set for.</param>
        public static void Save
        (
            MessageModifierView view,
            MessageModifierViewData data
        )
        {
            SaveFolder();

            SaveMessageText();

            SaveMessageAudio();

            SaveContinueByRadioGroup();

            SaveDelaySecondsInteger();

            SaveMessageCSVGuid();

            void SaveFolder()
            {
                view.Folder.Save(data.FolderData);
            }

            void SaveMessageText()
            {
                view.MessageTextFieldView.Save(data.MessageText);
            }

            void SaveMessageAudio()
            {
                view.MessageAudioFieldView.Save(data.MessageAudio);
            }

            void SaveContinueByRadioGroup()
            {
                view.ContinueByRadioGroup.Save(data.ContinueByRadioGroupData);
            }

            void SaveDelaySecondsInteger()
            {
                data.DelaySeconds = view.DelaySecondsFieldView.Value;
            }

            void SaveMessageCSVGuid()
            {
                data.MessageCSVGuid = view.MessageCSVGuid;
            }
        }


        /// <summary>
        /// Load the message modifier view values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="data">The message modifier view data to set for.</param>
        public static void Load
        (
            MessageModifierView view,
            MessageModifierViewData data
        )
        {
            LoadFolder();

            LoadMessageText();

            LoadMessageAudio();

            LoadContinueByRadioGroup();

            LoadDelaySecondsInteger();

            LoadMessageCSVGuid();

            void LoadFolder()
            {
                view.Folder.Load(data.FolderData);
            }

            void LoadMessageText()
            {
                view.MessageTextFieldView.Load(data.MessageText);
            }

            void LoadMessageAudio()
            {
                view.MessageAudioFieldView.Load(data.MessageAudio);
            }

            void LoadContinueByRadioGroup()
            {
                view.ContinueByRadioGroup.Load(data.ContinueByRadioGroupData);
            }

            void LoadDelaySecondsInteger()
            {
                view.DelaySecondsFieldView.Value = data.DelaySeconds;
            }

            void LoadMessageCSVGuid()
            {
                view.MessageCSVGuid = data.MessageCSVGuid;
            }
        }
    }
}