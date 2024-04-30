using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class ObjectFieldExtensions
    {
        /// <summary>
        /// Returns the object field's initial child's elements.
        /// <para></para>
        /// Note that this method only works when the object field's child elements' order hasn't been changed.<br>
        /// And new elements haven't been added to the object field.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The object field's initial child's elements.</returns>
        public static
        (
            VisualElement inputElement,
            VisualElement displayElement,
            VisualElement selectorElement,
            VisualElement displayImageElement,
            VisualElement displayLabelElement
        )
            GetInitialChildElements(this ObjectField field)
        {
            var fieldInput = field.Q(className: ObjectField.inputUssClassName);
            var fieldDisplay = fieldInput.Q(className: ObjectField.objectUssClassName);
            var fieldSelector = fieldInput.Q(className: ObjectField.selectorUssClassName);
            var fieldDisplayImage = fieldDisplay.Q(className: "unity-object-field-display__icon");
            var fieldDisplayLabel = fieldDisplay.Q(className: "unity-object-field-display__label");
            
            return (fieldInput, fieldDisplay, fieldSelector, fieldDisplayImage, fieldDisplayLabel);
        }


        /// <summary>
        /// Returns the object field's input element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The input element of the object field.</returns>
        public static VisualElement GetFieldInput(this ObjectField field)
        {
            return field.Q(className: StyleConfig.Object_Field_Input);
        }


        /// <summary>
        /// Returns the object field's display element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The display element of the object field.</returns>
        public static VisualElement GetFieldDisplay(this ObjectField field)
        {
            return field.Q(className: StyleConfig.Object_Field_Display);
        }


        /// <summary>
        /// Returns the object field's selector element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The selector element of the object field.</returns>
        public static VisualElement GetFieldSelector(this ObjectField field)
        {
            return field.Q(className: ObjectField.selectorUssClassName);
        }


        /// <summary>
        /// Returns the object field's display label element.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <returns>The display label element of the object field.</returns>
        public static VisualElement GetDisplayLabel(this ObjectField field)
        {
            return field.Q(className: StyleConfig.Object_Field_Display_Label);
        }


        /// <summary>
        /// Set the object field's icon image.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="image">The image to set for.</param>
        public static void SetIconImage
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
        /// Set the object field's select image.
        /// </summary>
        /// <param name="field">Extension object field.</param>
        /// <param name="image">The image to set for.</param>
        public static void SetSelectImage
        (
            this ObjectField field,
            Image image
        )
        {
            field.GetFieldDisplay().Add(image);
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
            ((Label)field.GetDisplayLabel()).text = placeholderText;
            field.AddToClassList(StyleConfig.Object_Field_Empty);
        }
    }
}