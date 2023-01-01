using UnityEngine.UIElements;

namespace AG.DS
{
    public class TextFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Register focus in actions to the given field element.
        /// </summary>
        /// <param name="textField">The field to assign the focus in actions to.</param>
        public static void RegisterFocusInEvent(TextField textField)
        {
            textField.RegisterCallback<FocusInEvent>(callback => 
            {
                // Hide empty style.
                TextFieldHelper.HideEmptyStyle(textField);
            });
        }


        /// <summary>
        /// Register focus out actions to the given field element.
        /// </summary>
        /// <param name="textField">The field to assign the focus out actions to.</param>
        public static void RegisterFocusOutEvent(TextContainer textContainer)
        {
            var textField = textContainer.TextField;

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
                    WindowChangedEvent.Invoke();
                }

                // Toggle empty style.
                TextFieldHelper.ToggleEmptyStyle(textContainer);
            });
        }
    }
}