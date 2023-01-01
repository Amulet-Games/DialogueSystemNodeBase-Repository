using UnityEngine.UIElements;

namespace AG.DS
{
    public class DelayableTextFieldCallbacks
    {
        /// <summary>
        /// Can the foucs out actions be ignored.
        /// </summary>
        static bool canIgnoreFocusOutEvent;


        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// <para></para>
        /// FIELD DELAYED IS SET TO TRUE,
        /// <br>Registered actions will be invoked when the user pressed enter / return key on the field.</br>
        /// </summary>
        /// <param name="textContainer">The container that connects with the field that the value changed actions is assigning to.</param>
        public static void RegisterValueChangedEvent(TextContainer textContainer)
        {
            var nodeTitleField = textContainer.TextField;

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
                WindowChangedEvent.Invoke();
            });
        }


        /// <summary>
        /// Register focus in actions to the given container's field element.
        /// </summary>
        /// <param name="textContainer">The container that connects with the field that the value changed actions is assigning to.</param>
        public static void RegisterFocusInEvent(TextContainer textContainer)
        {
            var nodeTitleField = textContainer.TextField;

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
        /// Register focus out actions to the given container's field element.
        /// </summary>
        /// <param name="textContainer">The container that connects with the field that the value changed actions is assigning to.</param>
        public static void RegisterFocusOutEvent(TextContainer textContainer)
        {
            var nodeTitleField = textContainer.TextField;

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