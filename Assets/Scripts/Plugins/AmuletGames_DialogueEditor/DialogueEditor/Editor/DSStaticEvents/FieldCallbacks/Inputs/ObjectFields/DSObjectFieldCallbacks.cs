using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    public class DSObjectFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the object field is assigned to a new value(Object),
        /// <br>the value(Object) inside the object container will change at the sametime.</br>
        /// </summary>
        /// <typeparam name="T">Type of Container_Object class</typeparam>
        /// <param name="objectContainer">The Object container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent<T>(DSObjectContainer<T> objectContainer) 
            where T : Object
        {
            // Create a local refs for the object field that we're targeting.
            ObjectField objectField = objectContainer.ObjectField;

            objectField.RegisterValueChangedCallback(value =>
            {
                // Unbind the previous bound object from the field.
                objectField.Unbind();

                // If the field received a new value.
                if (value.newValue != null)
                {
                    // Set the new value to the field.
                    objectContainer.Value = value.newValue as T;

                    // Create a new serialized object from the field's new value,
                    // and bind it to the field.
                    objectField.Bind(new SerializedObject(objectContainer.Value));

                    // Remove the field from empty style class if needed.
                    DSObjectFieldUtility.HideEmptyStyle(objectField);
                }
                else
                {
                    // Set the container's value to null.
                    objectContainer.Value = null;

                    // Add the field to empty style class if needed.
                    DSObjectFieldUtility.ShowEmptyStyle(objectContainer.ObjectField);
                }

                // Set unsaved changes to true.
                InvokeDSWindowChangedEvent();
            });
        }
    }
}