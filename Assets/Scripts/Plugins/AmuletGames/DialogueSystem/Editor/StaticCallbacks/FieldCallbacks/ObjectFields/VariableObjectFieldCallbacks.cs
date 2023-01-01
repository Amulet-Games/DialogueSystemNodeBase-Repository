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
        public static void RegisterValueChangedEvent(VariableContainer variableContainer)
        {
            // Create a local refs for the object field that we're targeting.
            var objectField = variableContainer.ObjectField;

            objectField.RegisterValueChangedCallback(callback =>
            {
                // Unbind the previous bound object from the field.
                objectField.Unbind();

                // If the field received a new value.
                if (callback.newValue != null)
                {
                    // Set the new value to the container.
                    variableContainer.SetNewValue(callback);

                    // Create a new serialized object from the event's new value,
                    // and bind it to the field.
                    objectField.Bind(obj: new SerializedObject(callback.newValue));

                    // Remove the field from empty style class if needed.
                    ObjectFieldHelper.HideEmptyStyle(objectField);
                }
                else
                {
                    // Set the container's value to null.
                    variableContainer.SetNewValue(null);

                    // Add the field to empty style class if needed.
                    ObjectFieldHelper.ShowEmptyStyle(objectField);
                }

                // Set unsaved changes to true.
                WindowChangedEvent.Invoke();
            });
        }
    }
}