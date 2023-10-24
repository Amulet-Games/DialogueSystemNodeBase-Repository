using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class ObjectFieldExtensions
    {
        /// <summary>
        /// Returns the object field's input element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The input element of the object field.</returns>
        public static VisualElement GetFieldInput(this ObjectField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Returns the object field's display element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The display element of the object field.</returns>
        public static VisualElement GetFieldDisplay(this ObjectField field)
        {
            return field.GetFieldInput().ElementAt(0);
        }


        /// <summary>
        /// Returns the object field's selector element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The selector element of the object field.</returns>
        public static VisualElement GetFieldSelector(this ObjectField field)
        {
            return field.GetFieldInput().ElementAt(1);
        }


        /// <summary>
        /// Returns the object field's display image element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The image label element of the object field.</returns>
        public static Image GetDisplayImage(this ObjectField field)
        {
            return (Image)field.GetFieldDisplay().ElementAt(0);
        }


        /// <summary>
        /// Returns the object field's display label element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The display label element of the object field.</returns>
        public static Label GetDisplayLabel(this ObjectField field)
        {
            var fieldDisplay = field.GetFieldDisplay();

            if (fieldDisplay.childCount > 1)
            {
                // Display image is added.
                return (Label)fieldDisplay.ElementAt(1);
            }
            else
            {
                // Display image isn't added.
                return (Label)fieldDisplay.ElementAt(0);
            }
        }


        /// <summary>
        /// Set the object field's display image.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="image">The image to set for.</param>
        public static void SetDisplayImage
        (
            this ObjectField field,
            Image image
        )
        {
            field.GetFieldDisplay().Add(image);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            image.SendToBack();
        }


        /// <summary>
        /// Add the object field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public static void ToggleEmptyStyle
        (
            this ObjectField field,
            string placeholderText
        )
        {
            if (field.value != null)
            {
                HideEmptyStyle(field);
            }
            else
            {
                ShowEmptyStyle(field, placeholderText);
            }
        }


        /// <summary>
        /// Remove the object field from the empty style class.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        public static void HideEmptyStyle(this ObjectField field)
        {
            field.RemoveFromClassList(StyleConfig.Object_Field_Empty);
        }


        /// <summary>
        /// Add the object field to the empty style class.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public static void ShowEmptyStyle
        (
            this ObjectField field,
            string placeholderText
        )
        {
            field.GetDisplayLabel().text = placeholderText;
            field.AddToClassList(StyleConfig.Object_Field_Empty);
        }
    }
}