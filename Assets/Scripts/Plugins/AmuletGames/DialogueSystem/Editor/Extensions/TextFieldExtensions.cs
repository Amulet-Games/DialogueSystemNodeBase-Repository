using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class TextFieldExtensions
    {
        /// <summary>
        /// Returns the text field's input element.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <returns>The input element of the text field.</returns>
        public static VisualElement GetFieldInput(this TextField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Returns the text field's multiline container.
        /// </summary>
        /// 
        /// <param name="field">Extension text field</param>
        /// 
        /// <returns>The multiline container of the text field.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given text field's multiline property has set to false and thus the multiline container
        /// visual element can't be found.
        /// </exception>
        public static VisualElement GetMultilineContainer(this TextField field)
        {
            if (field.multiline)
            {
                return field.GetFieldInput().ElementAt(0);
            }
            else
            {
                throw new ArgumentException("Can't get the multiline container visual element from the non multiline text field.");
            }
        }


        /// <summary>
        /// Return the text field's text element.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <returns>The text element of the text field.</returns>
        public static VisualElement GetTextElement(this TextField field)
        {
            if (field.multiline)
            {
                return field.GetMultilineContainer().ElementAt(0);
            }
            else
            {
                return field.GetFieldInput().ElementAt(0);
            }
        }


        /// <summary>
        /// Set the text field's display image.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <param name="image">The image to set for.</param>
        public static void SetDisplayImage
        (
            this TextField field,
            Image image
        )
        {
            field.Add(image);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            image.SendToBack();
        }


        /// <summary>
        /// Set the placeholder text active status.
        /// </summary>
        /// <param name="view">Extension text field view.</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        /// <param name="active">The active value to set for.</param>
        public static void SetActivePlaceholderText
        (
            this TextField field,
            string placeholderText,
            bool active
        )
        {
            field.SetValueWithoutNotify(active ? placeholderText : string.Empty);
        }


        /// <summary>
        /// Remove the text field from the empty style class.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        public static void HideEmptyStyle(this TextField field)
        {
            field.RemoveFromClassList(StyleConfig.Text_Field_Empty);
        }


        /// <summary>
        /// Add the text field to the empty style class.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        public static void ShowEmptyStyle(this TextField field)
        {
            field.AddToClassList(StyleConfig.Text_Field_Empty);
        }
    }
}