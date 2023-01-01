using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public static class TextFieldHelper
    {
        /// <summary>
        /// Add the text field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="textContainer">The container of which the text field is connecting to.</param>
        public static void ToggleEmptyStyle(TextContainerBase textContainer)
        {
            TextField textField = textContainer.TextField;

            // If there's texts in the input field.
            if (!string.IsNullOrEmpty(textField.text))
            {
                textField.RemoveFromClassList(StylesConfig.TextField_Empty);
            }
            else
            {
                textField.SetValueWithoutNotify(textContainer.PlaceholderText);
                textField.AddToClassList(StylesConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Remove the text field from the empty style class.
        /// </summary>
        /// <param name="textField">The text field to remove the style from.</param>
        public static void HideEmptyStyle(TextField textField)
        {
            // If the field is added to the empty style class previously.
            if (textField.ClassListContains(StylesConfig.TextField_Empty))
            {
                textField.SetValueWithoutNotify(string.Empty);
                textField.RemoveFromClassList(StylesConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Add the text field to the empty style class.
        /// </summary>
        /// <param name="textContainer">The container of which the text field is connecting to.</param>
        public static void ShowEmptyStyle(TextContainerBase textContainer)
        {
            TextField textField = textContainer.TextField;

            // If the field isn't added to the empty style class yet.
            if (!textField.ClassListContains(StylesConfig.TextField_Empty))
            {
                textField.SetValueWithoutNotify(textContainer.PlaceholderText);
                textField.AddToClassList(StylesConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Add a custom image icon to the given text field.
        /// </summary>
        /// <param name="textField">The text field to add the icon to.</param>
        /// <param name="iconTexture">The icon texture.</param>
        public static void AddFieldIcon
        (
            TextField textField,
            Texture iconTexture
        )
        {
            // Create a new image element and assign the USS style to it.
            Image textFieldImage = ImageFactory.GetNewImage(imageUSS01: StylesConfig.TextField_Icon);

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