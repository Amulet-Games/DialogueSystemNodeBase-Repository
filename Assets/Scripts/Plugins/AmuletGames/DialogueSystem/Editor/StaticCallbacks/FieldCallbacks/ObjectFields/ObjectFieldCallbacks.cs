using System;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class ObjectFieldCallbacks
    {
        /// <summary>
        /// Register new value changed actions to the given container's field element.
        /// </summary>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="objectContainer">The container that connects with the field that the value changed actions are assigning to.</param>
        /// <param name="additionalValueChangedAction">The additional action to assign with, it's optional.</param>
        public static void RegisterValueChangedEvent<TObject>
        (
            ObjectContainer<TObject> objectContainer,
            Action additionalValueChangedAction = null
        )
            where TObject : Object
        {
            // Create a local refs for the object field that we're targeting.
            var objectField = objectContainer.ObjectField;

            objectField.RegisterValueChangedCallback(callback =>
            {
                // Unbind the previous bound object from the field.
                objectField.Unbind();

                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(
                //    reversible: objectContainer,
                //    dataReversedAction: containerValueChangedAction
                //);

                // If the field received a new value.
                if (callback.newValue != null)
                {
                    // Set the new value to the container.
                    objectContainer.Value = callback.newValue as TObject;

                    // Create a new serialized object from the field's new value,
                    // and bind it to the field.
                    objectField.Bind(obj: new SerializedObject(objectContainer.Value));

                    // Remove the field from empty style class if needed.
                    ObjectFieldHelper.HideEmptyStyle(objectField);
                }
                else
                {
                    // Set the container's value to null.
                    objectContainer.Value = null;

                    // Add the field to empty style class if needed.
                    ObjectFieldHelper.ShowEmptyStyle(objectField);
                }

                // Invoke containerValueChangedAction.
                additionalValueChangedAction?.Invoke();

                // Set unsaved changes to true.
                WindowChangedEvent.Invoke();
            });
        }
    }
}