using UnityEngine.UIElements;

namespace AG.DS
{
    public static class IntegerFieldExtensions
    {
        /// <summary>
        /// Returns the integer field's input element.
        /// </summary>
        /// <param name="field">Extension integer field.</param>
        /// <returns>The input element of the integer field.</returns>
        public static VisualElement GetFieldInput(this IntegerField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Return the integer field's text element.
        /// </summary>
        /// <param name="field">Extension integer field.</param>
        /// <returns>The text element of the integer field.</returns>
        public static VisualElement GetTextElement(this IntegerField field)
        {
            return field.GetFieldInput().ElementAt(0);
        }


        /// <summary>
        /// Add the integer field to the empty style class if its value is zero,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension integer field.</param>
        public static void ToggleEmptyStyle(this IntegerField field)
        {
            if (field.value != 0)
            {
                field.RemoveFromClassList(StyleConfig.Integer_Field_Empty);
            }
            else
            {
                field.AddToClassList(StyleConfig.Integer_Field_Empty);
            }
        }


        /// <summary>
        /// Remove the integer field from the empty style class.
        /// </summary>
        /// <param name="field">Extension integer field.</param>
        public static void HideEmptyStyle(this IntegerField field)
        {
            field.RemoveFromClassList(StyleConfig.Integer_Field_Empty);
        }


        /// <summary>
        /// Add the integer field to the empty style class.
        /// </summary>
        /// <param name="field">Extension integer field.</param>
        public static void ShowEmptyStyle(this IntegerField field)
        {
            field.AddToClassList(StyleConfig.Integer_Field_Empty);
        }
    }
}