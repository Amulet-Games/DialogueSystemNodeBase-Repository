using UnityEngine.UIElements;

namespace AG.DS
{
    public static class DoubleFieldExtensions
    {
        /// <summary>
        /// Returns the double field's input element.
        /// </summary>
        /// <param name="field">Extension double field.</param>
        /// <returns>The input element of the double field.</returns>
        public static VisualElement GetFieldInput(this DoubleField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Return the double field's text element.
        /// </summary>
        /// <param name="field">Extension double field.</param>
        /// <returns>The text element of the double field.</returns>
        public static VisualElement GetTextElement(this DoubleField field)
        {
            return field.GetFieldInput().ElementAt(0);
        }


        /// <summary>
        /// Add the double field to the empty style class if its value is zero,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension double field.</param>
        public static void ToggleEmptyStyle(this DoubleField field)
        {
            if (field.value != 0)
            {
                field.RemoveFromClassList(StyleConfig.Double_Field_Empty);
            }
            else
            {
                field.AddToClassList(StyleConfig.Double_Field_Empty);
            }
        }


        /// <summary>
        /// Remove the double field from the empty style class.
        /// </summary>
        /// <param name="field">Extension double field.</param>
        public static void HideEmptyStyle(this DoubleField field)
        {
            field.RemoveFromClassList(StyleConfig.Double_Field_Empty);
        }


        /// <summary>
        /// Add the double field to the empty style class.
        /// </summary>
        /// <param name="field">Extension double field.</param>
        public static void ShowEmptyStyle(this DoubleField field)
        {
            field.AddToClassList(StyleConfig.Double_Field_Empty);
        }


        /// <summary>
        /// Add a icon image UIElement to the given double field.
        /// </summary>
        /// <param name="field">Extension double field.</param>
        /// <param name="iconSprite">The sprite to set for the icon.</param>
        //public static void AddFieldIcon
        //(
        //    this DoubleField field,
        //    Sprite iconSprite
        //)
        //{
        //    var iconImage = CommonImagePresenter.CreateElement
        //    (
        //        imageSprite: iconSprite,
        //        imageUSS01: StyleConfig.DoubleField_Icon
        //    );

        //    field.Add(iconImage);

        //    // Place it as the first element within the field's hierarchy list
        //    // so that it's align on the left side.
        //    iconImage.SendToBack();
        //}
    }
}