namespace AG.DS
{
    public class MessageModifierSerializer
    {
        /// <summary>
        /// Save the message modifier values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="model">The message modifier model to set for.</param>
        public void Save
        (
            MessageModifierView view,
            MessageModifierModel model
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
                view.Folder.Save(model.FolderModel);
            }

            void SaveMessageText()
            {
                view.MessageTextFieldView.Save(model.MessageText);
            }

            void SaveMessageAudio()
            {
                view.MessageAudioFieldView.Save(model.MessageAudio);
            }

            void SaveContinueByRadioGroup()
            {
                view.ContinueByRadioGroup.Save(model.ContinueByRadioGroupModel);
            }

            void SaveDelaySecondsInteger()
            {
                model.DelaySeconds = view.DelaySecondsFieldView.Value;
            }

            void SaveMessageCSVGuid()
            {
                model.MessageCSVGuid = view.MessageCSVGuid;
            }
        }


        /// <summary>
        /// Load the message modifier values.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="model">The message modifier model to set for.</param>
        public void Load
        (
            MessageModifierView view,
            MessageModifierModel model
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
                view.Folder.Load(model.FolderModel);
            }

            void LoadMessageText()
            {
                view.MessageTextFieldView.Load(model.MessageText);
            }

            void LoadMessageAudio()
            {
                view.MessageAudioFieldView.Load(model.MessageAudio);
            }

            void LoadContinueByRadioGroup()
            {
                view.ContinueByRadioGroup.Save(model.ContinueByRadioGroupModel);
            }

            void LoadDelaySecondsInteger()
            {
                view.DelaySecondsFieldView.Value = model.DelaySeconds;
            }

            void LoadMessageCSVGuid()
            {
                view.MessageCSVGuid = model.MessageCSVGuid;
            }
        }
    }
}