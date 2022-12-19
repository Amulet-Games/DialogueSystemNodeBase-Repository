using UnityEngine.UIElements;

namespace AG.DS
{
    public class TextFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the value(string) in the string container will be changed at the sametime.</br>
        /// </summary>
        public static void RegisterValueChangedEvent(TextContainer textContainer) { }


        /// <summary>
        /// Each time the text field is selected, if it's in empty style class then remove the field from it.
        /// </summary>
        /// <param name="textField">The field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(TextField textField)
        {
            textField.RegisterCallback<FocusInEvent>(callback => 
            {
                // Hide empty style.
                TextFieldHelper.HideEmptyStyle(textField);
            });
        }


        /// <summary>
        /// Each time the text field is deselected, if the field is empty, add the field to empty style class.
        /// </summary>
        /// <param name="textContainer">The container of which the text field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(TextContainer textContainer)
        {
            TextField textField = textContainer.TextField;

            textField.RegisterCallback<FocusOutEvent>(callback =>
            {
                if (textField.value != textContainer.PlaceholderText
                    && textField.value != textContainer.Value)
                {
                    // Push the current container's value to the undo stack.
                    ///TestingWindow.Instance.PushUndo(textContainer);

                    // Set container's new value.
                    textContainer.Value = textField.value;

                    // Set has unsaved changes.
                    InvokeWindowChangedEvent();
                }

                // Toggle empty style.
                TextFieldHelper.ToggleEmptyStyle(textContainer);
            });
        }
    }
}