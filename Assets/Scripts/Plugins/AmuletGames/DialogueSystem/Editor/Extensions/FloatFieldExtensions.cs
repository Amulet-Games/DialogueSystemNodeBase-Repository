using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public static class FloatFieldExtensions
    {
        /// <summary>
        /// Add the float field to the empty style class if its value is zero,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void ToggleEmptyStyle(this FloatField field)
        {
            if (field.value != 0)
            {
                field.RemoveFromClassList(StyleConfig.Instance.FloatField_Empty);
            }
            else
            {
                field.AddToClassList(StyleConfig.Instance.FloatField_Empty);
            }
        }


        /// <summary>
        /// Remove the float field from the empty style class.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void HideEmptyStyle(this FloatField field)
        {
            if (field.ClassListContains(StyleConfig.Instance.FloatField_Empty))
            {
                field.RemoveFromClassList(StyleConfig.Instance.FloatField_Empty);
            }
        }


        /// <summary>
        /// Add the float field to the empty style class.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        public static void ShowEmptyStyle(this FloatField field)
        {
            if (!field.ClassListContains(StyleConfig.Instance.FloatField_Empty))
            {
                field.AddToClassList(StyleConfig.Instance.FloatField_Empty);
            }
        }


        /// <summary>
        /// Add a icon image UIElement to the given float field.
        /// </summary>
        /// <param name="field">Extension float field.</param>
        /// <param name="iconSprite">The sprite to set for the icon.</param>
        public static void AddFieldIcon
        (
            this FloatField field,
            Sprite iconSprite
        )
        {
            var iconImage = CommonImagePresenter.CreateElements
            (
                imageSprite: iconSprite,
                imageUSS01: StyleConfig.Instance.FloatField_Icon
            );

            field.Add(iconImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            iconImage.SendToBack();
        }
    }
}