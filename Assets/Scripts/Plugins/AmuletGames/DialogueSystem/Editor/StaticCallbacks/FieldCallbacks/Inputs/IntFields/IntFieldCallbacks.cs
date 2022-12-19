using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class IntFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the integer Field is assigned to a new value,
        /// <br>the Value(int) in the int container will be changed at the sametime.</br>
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Invoked each time when the field is selected.
        /// </summary>
        public static void RegisterFieldFocusInEvent() { }


        /// <summary>
        /// Invoked each time when the field is deselected.
        /// </summary>
        /// <param name="intContainer">The container of which the field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(IntContainer intContainer)
        {
            IntegerField intField = intContainer.IntField;

            intField.RegisterCallback<FocusOutEvent>(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(floatContainer);

                // Set container's new value.
                intContainer.Value = intField.value;

                // Set has unsaved changes.
                InvokeWindowChangedEvent();
            });
        }
    }
}