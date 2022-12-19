using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeTitleFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Will the FocusOutEvent callback be skipped on the next time the field is focus out.
        /// </summary>
        static bool canIgnoreFocusOutEvent;


        /// <summary>
        /// FIELD DELAYED IS SET TO TRUE
        /// <para></para>
        /// <br>Event only get invoked when user pressed enter / return to submit the changes to the field.</br>
        /// Event will update the current node's title field with a new value that the user has input.
        /// </summary>
        /// <param name="textContainer">The container of which the field is connecting to.</param>
        public static void RegisterNodeTitleChangedEvent(TextContainer textContainer)
        {
            TextField nodeTitleField = textContainer.TextField;

            nodeTitleField.RegisterValueChangedCallback(callback =>
            {
                // Press "enter" to leave the field'll trigger FocusOutEvent as well,
                // Set canIgnoreFocusOut to true so that the value won't reset.
                canIgnoreFocusOutEvent = true;

                // Set focusable to false so that it won't trigger FocusInEvent.
                nodeTitleField.focusable = false;

                // If user has input a new value to the field.
                if (callback.newValue != "")
                {
                    // Update the field's value with the new title text.
                    textContainer.Value = callback.newValue;
                }
                else
                {
                    // If the field is empty, reset its value back to what it was before focused in.
                    nodeTitleField.SetValueWithoutNotify(textContainer.PlaceholderText);
                }
                
                // Notice the dialogue system that there're unsaved changes.
                InvokeWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time the node title field is focused in, update the placeholder text as backup,
        /// and switch the field ignore user's input state to position(allow interactions).
        /// </summary>
        /// <param name="textContainer">The container of which the field is connecting to.</param>
        public static void RegisterNodeTitleFocusInEvent(TextContainer textContainer)
        {
            TextField nodeTitleField = textContainer.TextField;

            nodeTitleField.RegisterCallback<FocusInEvent>(callback =>
            {
                // Reset can ignore focus out event status.
                canIgnoreFocusOutEvent = false;

                // Override the placeholder text with its current value,
                // so that it can be used later on when it's focus out.
                textContainer.PlaceholderText = nodeTitleField.value;

                // Allow user's mouse interactions.
                nodeTitleField.pickingMode = PickingMode.Position;
                nodeTitleField.GetFieldInputBase().pickingMode = PickingMode.Position;
            });
        }


        /// <summary>
        /// Each time the node title field was deselected, if it was changed but not submitted yet,
        /// <br>the field's value will reset to current window's title and switch to ignore user's input again.</br>
        /// </summary>
        /// <param name="textContainer">The container of which the field is connecting to.</param>
        public static void RegisterNodeTitleFocusOutEvent(TextContainer textContainer)
        {
            TextField nodeTitleField = textContainer.TextField;

            nodeTitleField.RegisterCallback<FocusOutEvent>(callback =>
            {
                // If the field is focused out by user entered a new title,
                // don't reset the field value to previous.
                if (!canIgnoreFocusOutEvent)
                {
                    // Reset the text field value with the previous value that was saved earlier when it's focused in.
                    nodeTitleField.SetValueWithoutNotify(textContainer.PlaceholderText);
                }

                // Block user's mouse interactions.
                nodeTitleField.pickingMode = PickingMode.Ignore;
                nodeTitleField.GetFieldInputBase().pickingMode = PickingMode.Ignore;
            });
        }
    }
}