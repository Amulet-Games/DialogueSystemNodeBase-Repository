using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class VariableObjectFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the object field is assigned to a new value(Object),
        /// <br>the value(Object) inside the object container will be changed at the sametime.</br>
        /// </summary>
        /// <param name="variableContainer">The container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent(VariableContainer variableContainer)
        {
            // Create a local refs for the object field that we're targeting.
            ObjectField objectField = variableContainer.ObjectField;

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
                InvokeWindowChangedEvent();
            });
        }
    }
}