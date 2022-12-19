using UnityEditor.UIElements;

namespace AG.DS
{
    public static class ObjectFieldExtensions
    {
        /// <summary>
        /// Extension method for updating the object field with its current value,
        /// <br>without invoking the OnValueChanged event.</br>
        /// </summary>
        /// <param name="objectField">Extension object field</param>
        public static void UpdateFieldValueNonAlert(this ObjectField objectField) =>
            objectField.SetValueWithoutNotify(objectField.value);
    }
}