using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class IntFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Register focus in actions to the given container's field element.
        /// </summary>
        public static void RegisterFocusInEvent() { }


        /// <summary>
        /// Register focus out actions to the given container's field element.
        /// </summary>
        /// <param name="intContainer">The container that connects with the field that the focus out actions are assigning to.</param>
        public static void RegisterFocusOutEvent(IntContainer intContainer)
        {
            var intField = intContainer.IntField;

            intField.RegisterCallback<FocusOutEvent>(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(floatContainer);

                // Set container's new value.
                intContainer.Value = intField.value;

                // Set has unsaved changes.
                WindowChangedEvent.Invoke();
            });
        }
    }
}