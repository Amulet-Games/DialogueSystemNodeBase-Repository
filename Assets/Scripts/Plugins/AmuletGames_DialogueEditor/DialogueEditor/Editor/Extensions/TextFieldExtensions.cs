using UnityEngine.UIElements;

namespace AG
{
    public static class TextFieldExtensions
    {
        /// <summary>
        /// Extension method for getting the text field's input base visual element reference.
        /// </summary>
        /// <param name="textField">The target text field to retrieve the visual element from.</param>
        /// <returns>The input base visual element reference from the specified text field.</returns>
        public static VisualElement GetTextFieldInputBase(this TextField textField)
            => textField.ElementAt(0);
    }
}