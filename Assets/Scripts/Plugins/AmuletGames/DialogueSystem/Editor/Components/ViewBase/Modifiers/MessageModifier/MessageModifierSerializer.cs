namespace AG.DS
{
    public class MessageModifierSerializer
    {
        /// <summary>
        /// Save the message modifier values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="data">The message modifier data to set for.</param>
        public void Save
        (
            MessageModifierView view,
            MessageModifierData data
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
        /// Load the message modifier values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="data">The message modifier data to set for.</param>
        public void Load
        (
            MessageModifierView view,
            MessageModifierData data
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