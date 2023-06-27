using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class TextFieldExtensions
    {
        /// <summary>
        /// Returns the text field's input base element reference.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <returns>The input base element reference of the text field.</returns>
        public static VisualElement GetElementInput(this TextField field)
        {
            return field.ElementAt(0);
        }


        /// <summary>
        /// Return the text field's text element reference.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <returns></returns>
        public static VisualElement GetElementText(this TextField field)
        {
            if (field.multiline)
            {
                var multilineContainer = field.GetElementInput().ElementAt(0);
                return multilineContainer.ElementAt(0);
            }
            else
            {
                return field.GetElementInput().ElementAt(0);
            }
        }


        /// <summary>
        /// Refresh the text field with its current value without invoking the ChangeEvent.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        public static void RefreshValueNonAlert(this TextField field)
        {
            field.SetValueWithoutNotify(field.value);
        }


        /// <summary>
        /// Add the text field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public static void ToggleEmptyStyle
        (
            this TextField field,
            string placeholderText
        )
        {
            if (!string.IsNullOrEmpty(field.text))
            {
                field.RemoveFromClassList(StyleConfig.TextField_Empty);
            }
            else
            {
                field.SetValueWithoutNotify(placeholderText);
                field.AddToClassList(StyleConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Remove the text field from the empty style class.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        public static void HideEmptyStyle(this TextField field)
        {
            if (field.ClassListContains(StyleConfig.TextField_Empty))
            {
                field.SetValueWithoutNotify(string.Empty);
                field.RemoveFromClassList(StyleConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Add the text field to the empty style class.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public static void ShowEmptyStyle
        (
            this TextField field,
            string placeholderText
        )
        {
            if (!field.ClassListContains(StyleConfig.TextField_Empty))
            {
                field.SetValueWithoutNotify(placeholderText);
                field.AddToClassList(StyleConfig.TextField_Empty);
            }
        }


        /// <summary>
        /// Add a icon image UIElement to the given text field.
        /// </summary>
        /// <param name="field">Extension text field.</param>
        /// <param name="iconSprite">The sprite to set for the icon.</param>
        public static void AddFieldIcon
        (
            this TextField field,
            Sprite iconSprite
        )
        {
            var iconImage = CommonImagePresenter.CreateElement
            (
                imageSprite: iconSprite,
                imageUSS01: StyleConfig.TextField_Icon
            );

            field.Add(iconImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            iconImage.SendToBack();
        }
    }
}