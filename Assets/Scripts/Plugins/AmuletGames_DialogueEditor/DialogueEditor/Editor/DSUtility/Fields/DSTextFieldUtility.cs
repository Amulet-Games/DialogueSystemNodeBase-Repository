using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public static class DSTextFieldUtility
    {
        /// <summary>
        /// Add the text field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="stringContainer">The string container of which the text field, be adding or removed the style from, belongs to.</param>
        public static void ToggleEmptyStyle(TextContainerBase stringContainer)
        {
            TextField textField = stringContainer.TextField;
            
            // If there's texts in the input field.
            if (!string.IsNullOrEmpty(textField.text))
            {
                textField.RemoveFromClassList(DSStylesConfig.Node_TextField_Empty);
            }
            else
            {
                textField.SetValueWithoutNotify(stringContainer.PlaceholderText);
                textField.AddToClassList(DSStylesConfig.Node_TextField_Empty);
            }
        }


        /// <summary>
        /// Remove the text field from the empty style class.
        /// </summary>
        /// <param name="textField">The text field to remove the style from.</param>
        public static void HideEmptyStyle(TextField textField)
        {
            // If the field is added to the empty style class previously.
            if (textField.ClassListContains(DSStylesConfig.Node_TextField_Empty))
            {
                textField.SetValueWithoutNotify(string.Empty);
                textField.RemoveFromClassList(DSStylesConfig.Node_TextField_Empty);
            }
        }


        /// <summary>
        /// Add the text field to the empty style class.
        /// </summary>
        /// <param name="stringContainer">The string container of which the text field, be adding the style to, belongs to.</param>
        public static void ShowEmptyStyle(TextContainerBase stringContainer)
        {
            TextField textField = stringContainer.TextField;

            // If the field isn't added to the empty style class yet.
            if (!textField.ClassListContains(DSStylesConfig.Node_TextField_Empty))
            {
                textField.SetValueWithoutNotify(stringContainer.PlaceholderText);
                textField.AddToClassList(DSStylesConfig.Node_TextField_Empty);
            }
        }


        /// <summary>
        /// Add a custom image icon to the specified text field.
        /// </summary>
        /// <param name="textField">The text field of which the icon is going to added to.</param>
        /// <param name="iconTexture">The icon texture to add with.</param>
        public static void AddFieldIcon
        (
            TextField textField,
            Texture iconTexture
        )
        {
            // Create a new image element and assign the USS style to it.
            Image textFieldImage = DSImagesMaker.GetNewImage(DSStylesConfig.Node_TextField_Icon);

            // Set the image's texture.
            textFieldImage.image = iconTexture;

            // Set picking mode as ignore.
            textFieldImage.pickingMode = PickingMode.Ignore;

            // Add the image element to the field.
            textField.Add(textFieldImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            textFieldImage.SendToBack();
        }
    }
}