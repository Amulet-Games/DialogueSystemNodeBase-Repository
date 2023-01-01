using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FloatFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Register focus in actions to the given field element.
        /// </summary>
        /// <param name="floatField">The field to assign the focus in actions to.</param>
        public static void RegisterFocusInEvent(FloatField floatField)
        {
            floatField.RegisterCallback<FocusInEvent>(callback =>
            {
                // When input field was clicked and it's empty,
                // remove the previous added empty style class.
                FloatFieldHelper.HideEmptyStyle(floatField);
            });
        }


        /// <summary>
        /// Register focus out actions to the given field element.
        /// </summary>
        /// <param name="floatContainer">The container that connects with the field that the focus out actions are assigning to.</param>
        public static void RegisterFocusOutEvent(FloatContainer floatContainer)
        {
            var floatField = floatContainer.FloatField;

            floatField.RegisterCallback<FocusOutEvent>(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(floatContainer);

                // Set container's new value.
                floatContainer.Value = floatField.value;

                // Toggle empty style.
                FloatFieldHelper.ToggleEmptyStyle(floatField);

                // Set has unsaved changes.
                WindowChangedEvent.Invoke();
            });
        }
    }
}