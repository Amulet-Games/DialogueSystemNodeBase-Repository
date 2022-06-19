using UnityEngine.UIElements;

namespace AG
{
    public static class DSTextFieldUtility
    {
        /// <summary>
        /// Update text field's placeholder visible status by checking if the field is currently empty or not.
        /// </summary>
        /// <param name="stringContainer">The string container of which the text field is belonged to.</param>
        public static void ToggleEmptyStyle(TextContainerBase stringContainer)
        {
            TextField textField = stringContainer.TextField;

            // if there's texts in the input field.
            if (!string.IsNullOrEmpty(textField.text))
            {
                textField.RemoveFromClassList(DSStylesConfig.nodeShare_TextField_Empty);
            }
            else
            {
                textField.SetValueWithoutNotify(stringContainer.PlaceholderText);
                textField.AddToClassList(DSStylesConfig.nodeShare_TextField_Empty);
            }
        }

        /// <summary>
        /// Hide the text field's placeholder text if it's showing.
        /// </summary>
        /// <param name="textField">The text field of which the empty style is applying to.</param>
        public static void HideEmptyStyle(TextField textField)
        {
            // when input field was clicked and the field is empty, hide the placeholder text as well.
            if (textField.ClassListContains(DSStylesConfig.nodeShare_TextField_Empty))
            {
                textField.SetValueWithoutNotify(string.Empty);
                textField.RemoveFromClassList(DSStylesConfig.nodeShare_TextField_Empty);
            }
        }

        /// <summary>
        /// Show the text field's placeholder text if the field is currently empty.
        /// </summary>
        /// <param name="stringContainer">The string container of which the text field is belonged to.</param>
        public static void ShowEmptyStyle(TextContainerBase stringContainer)
        {
            TextField textField = stringContainer.TextField;

            // if there's no texts in the input field, show the placeholder text.
            if (string.IsNullOrEmpty(textField.text))
            {
                textField.SetValueWithoutNotify(stringContainer.PlaceholderText);
                textField.AddToClassList(DSStylesConfig.nodeShare_TextField_Empty);
            }
        }
    }
}