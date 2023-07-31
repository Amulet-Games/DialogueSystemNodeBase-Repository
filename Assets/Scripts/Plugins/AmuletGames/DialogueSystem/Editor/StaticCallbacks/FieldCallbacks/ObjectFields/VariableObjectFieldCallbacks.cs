using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class VariableObjectFieldCallbacks
    {
        /// <summary>
        /// Register new value changed actions to the given container's field element.
        /// </summary>
        /// <param name="variableContainer">The container that connects with the field that the value changed actions are assigning to.</param>
        public static void RegisterValueChangedEvent(VariableFieldView variableContainer)
        {
            // Create a local refs for the object field that we're targeting.
            var objectField = variableContainer.ObjectField;

            objectField.RegisterValueChangedCallback(callback =>
            {
                // Unbind the previous bound object from the field.
                objectField.Unbind();

                if (callback.newValue != null)
                {
                    variableContainer.SetNewValue(callback.newValue);

                    // Create a new serialized object from the event's new value,
                    // and bind it to the field.
                    objectField.Bind(obj: new SerializedObject(callback.newValue));
                    objectField.HideEmptyStyle();
                }
                else
                {
                    variableContainer.SetNewValue(null);
                    objectField.ShowEmptyStyle("");
                }

                WindowChangedEvent.Invoke();
            });
        }
    }
}