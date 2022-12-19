using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FloatFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Invoked each time when the field is assigned to a new value.
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Invoked each time when the field is selected.
        /// </summary>
        /// <param name="floatField">The field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(FloatField floatField)
        {
            floatField.RegisterCallback<FocusInEvent>(callback =>
            {
                // When input field was clicked and it's empty,
                // remove the previous added empty style class.
                FloatFieldHelper.HideEmptyStyle(floatField);
            });
        }


        /// <summary>
        /// Invoked each time when the field is deselected.
        /// </summary>
        /// <param name="floatContainer">The container of which the field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(FloatContainer floatContainer)
        {
            FloatField floatField = floatContainer.FloatField;

            floatField.RegisterCallback<FocusOutEvent>(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(floatContainer);

                // Set container's new value.
                floatContainer.Value = floatField.value;

                // Toggle empty style.
                FloatFieldHelper.ToggleEmptyStyle(floatField);

                // Set has unsaved changes.
                InvokeWindowChangedEvent();
            });
        }
    }
}