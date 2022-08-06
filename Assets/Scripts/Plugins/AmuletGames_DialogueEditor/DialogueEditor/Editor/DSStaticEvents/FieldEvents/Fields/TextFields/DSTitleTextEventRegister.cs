using UnityEngine.UIElements;

namespace AG
{
    public class DSTitleTextEventRegister
    {
        /// <summary>
        /// FIELD DELAYED IS SET TO TRUE,
        /// <br>Only get invoked when user pressed enter / return to submit the changes to the field.</br>
        /// <br>Also, invoke DSTitleChangedEvent afterward.</br>
        /// </summary>
        /// <param name="titleTextField">The title text field in which it's located on the editor window's headbar.</param>
        public static void RegisterTitleChangedEvent(TextField titleTextField)
        {
            titleTextField.RegisterValueChangedCallback(value =>
            {
                DSTitleChangedEvent.Invoke(value.newValue);
            });
        }


        /// <summary>
        /// Each time the text field was deselected,
        /// <br>if the title field has changed but not submitted yet,</br>
        /// <br>field's value will reset to current window's title.</br>
        /// </summary>
        /// <param name="titleTextField">The title text field in which it's located on the editor window's headbar.</param>
        public static void RegisterTitleFocusOutEvent(TextField titleTextField)
        {
            titleTextField.RegisterCallback<FocusOutEvent>(_ => 
            {
                DialogueEditorWindow.Instance.HeadBar.ReloadGraphTitleAction();
            });
        }
    }
}