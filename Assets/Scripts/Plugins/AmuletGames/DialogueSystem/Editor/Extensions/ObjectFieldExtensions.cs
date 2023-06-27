using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class ObjectFieldExtensions
    {
        /// <summary>
        /// Returns the object field's display element reference.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The display element of the object field.</returns>
        public static VisualElement GetElementDisplay(this ObjectField field)
        {
            var inputBase = field.ElementAt(0);
            return inputBase.ElementAt(0);
        }


        /// <summary>
        /// Add the object field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension object field.</param>
        public static void ToggleEmptyStyle(this ObjectField field)
        {
            if (field.value != null)
            {
                field.RemoveFromClassList(StyleConfig.ObjectField_Empty);
            }
            else
            {
                field.AddToClassList(StyleConfig.ObjectField_Empty);
            }
        }


        /// <summary>
        /// Remove the object field from the empty style class.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        public static void HideEmptyStyle(this ObjectField field)
        {
            if (field.ClassListContains(StyleConfig.ObjectField_Empty))
            {
                field.RemoveFromClassList(StyleConfig.ObjectField_Empty);
            }
        }


        /// <summary>
        /// Add the object field to the empty style class.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        public static void ShowEmptyStyle(this ObjectField field)
        {
            // If the field isn't added to the empty style class yet.
            if (!field.ClassListContains(StyleConfig.ObjectField_Empty))
            {
                field.AddToClassList(StyleConfig.ObjectField_Empty);
            }
        }


        /// <summary>
        /// Remove the icon image UIElement from the given object field.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        public static void RemoveFieldIcon(this ObjectField field)
        {
            var displayElement = field.GetElementDisplay();
            displayElement.Remove(displayElement.ElementAt(0));
        }


        /// <summary>
        /// Add a icon image UIElement to the given object field.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="iconSprite">The sprite to set for the icon.</param>
        public static void AddFieldIcon
        (
            this ObjectField field,
            Sprite iconSprite
        )
        {
            var iconImage = CommonImagePresenter.CreateElement
            (
                imageSprite: iconSprite,
                imageUSS01: StyleConfig.ObjectField_Icon
            );

            field.GetElementDisplay().Add(iconImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            iconImage.SendToBack();
        }
    }
}