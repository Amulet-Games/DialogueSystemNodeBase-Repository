using UnityEngine.UIElements;

namespace AG
{
    public class DSTitleTextFieldUtilityEditor
    {
        /// <summary>
        /// FIELD DELAYED IS SET TO TRUE,
        /// Only when user pressed enter / return to submit the changes to the field,
        /// invoke DSTitleChangedEvent.
        /// </summary>
        /// <param name="titleTextField">The title text field this event is registered upon on.</param>
        public static void RegisterTitleChangedEvent(TextField titleTextField)
        {
            titleTextField.RegisterValueChangedCallback(value =>
            {
                DSTitleChangedEvent.Invoke(value.newValue);
            });
        }

        /// <summary>
        /// Each time the text field was deselected,
        /// if the title field has changed but not submitted yet,
        /// field's value will reset to current window's title.
        /// </summary>
        /// <param name="titleTextField">The title text field this event is registered upon on.</param>
        public static void RegisterTitleFocusOutEvent(TextField titleTextField)
        {
            titleTextField.RegisterCallback<FocusOutEvent>(_ => 
            {
                DialogueEditorWindow.dsWindow.headBar.ReloadTitleText();
            });
        }
    }
}