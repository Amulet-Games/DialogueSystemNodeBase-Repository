using UnityEngine.UIElements;

namespace AG.DS
{
    public static class FloatFieldExtensions
    {
        /// <summary>
        /// Returns the float field's input element.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        /// <returns>The input element of the float field.</returns>
        public static VisualElement GetFieldInput(this FloatField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Return the float field's text element.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        /// <returns>The text element of the float field.</returns>
        public static VisualElement GetTextElement(this FloatField field)
        {
            return field.GetFieldInput().ElementAt(0);
        }


        /// <summary>
        /// Set the float field's display image.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        /// <param name="image">The image to set for.</param>
        public static void SetDisplayImage
        (
            this FloatField field,
            Image image
        )
        {
            field.Add(image);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            image.SendToBack();
        }


        /// <summary>
        /// Add the float field to the empty style class if its value is zero,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void ToggleEmptyStyle(this FloatField field)
        {
            if (field.value != 0)
            {
                HideEmptyStyle(field);
            }
            else
            {
                ShowEmptyStyle(field);
            }
        }


        /// <summary>
        /// Remove the float field from the empty style class.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void HideEmptyStyle(this FloatField field)
        {
            field.RemoveFromClassList(StyleConfig.Float_Field_Empty);
        }


        /// <summary>
        /// Add the float field to the empty style class.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void ShowEmptyStyle(this FloatField field)
        {
            field.AddToClassList(StyleConfig.Float_Field_Empty);
        }
    }
}