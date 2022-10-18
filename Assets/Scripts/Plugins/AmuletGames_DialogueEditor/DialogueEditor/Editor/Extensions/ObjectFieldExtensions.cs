using UnityEditor.UIElements;

namespace AG
{
    public static class ObjectFieldExtensions
    {
        /// <summary>
        /// Extension method for reloading the object field with its current value, without invoking the
        /// <br>OnValueChanged event.</br>
        /// </summary>
        /// <param name="objectField">Extension object field</param>
        public static void ReloadFieldValueNonAlert(this ObjectField objectField)
            =>
            objectField.SetValueWithoutNotify(objectField.value);
    }
}