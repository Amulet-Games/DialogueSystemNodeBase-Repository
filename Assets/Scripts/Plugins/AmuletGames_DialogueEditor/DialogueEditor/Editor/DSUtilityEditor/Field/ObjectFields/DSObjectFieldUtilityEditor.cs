using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    public class DSObjectFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the object field is assigned to a new value(Object),
        /// the value(Object) inside the object container will change at the sametime.
        /// </summary>
        /// <typeparam name="T">Type of Container_Object class</typeparam>
        /// <param name="objectContainer">Object container of which the object field is connecting to.</param>
        public static void RegisterValueChangedEvent<T>(ObjectContainer<T> objectContainer) where T : Object
        {
            objectContainer.ObjectField.RegisterValueChangedCallback(value =>
            {
                objectContainer.Value = value.newValue as T;

                DSObjectFieldUtility.ToggleEmptyStyle(objectContainer.ObjectField);

                InvokeDSWindowChangedEvent();
            });
        }
    }
}