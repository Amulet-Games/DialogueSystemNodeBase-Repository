using UnityEngine.UIElements;

namespace AG
{
    public static class TextFieldExtensions
    {
        /// <summary>
        /// Extension method that returns the text field's input base visual element reference.
        /// </summary>
        /// <param name="textField">Extension textField.</param>
        /// <returns>The input base visual element reference of the text field.</returns>
        public static VisualElement GetFieldInputBase(this TextField textField)
            =>
            textField.ElementAt(0);


        /// <summary>
        /// Extension method for reloading the text field with its current value, without invoking the
        /// <br>OnValueChanged event.</br>
        /// </summary>
        /// <param name="textField"></param>
        public static void ReloadFieldValueNonAlert(this TextField textField)
            =>
            textField.SetValueWithoutNotify(textField.value);
    }
}