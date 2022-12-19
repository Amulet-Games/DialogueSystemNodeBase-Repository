using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class FloatFieldHelper
    {
        /// <summary>
        /// Add the float field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="floatField">The float field to add or remove the style from.</param>
        public static void ToggleEmptyStyle(FloatField floatField)
        {
            // If the value in the input field is not 0.
            if (floatField.value != 0)
            {
                floatField.RemoveFromClassList(StylesConfig.FloatField_Empty);
            }
            else
            {
                floatField.AddToClassList(StylesConfig.FloatField_Empty);
            }
        }


        /// <summary>
        /// Remove the float field from the empty style class.
        /// </summary>
        /// <param name="floatField">The float field to remove the style from.</param>
        public static void HideEmptyStyle(FloatField floatField)
        {
            // If the field is added to the empty style class previously.
            if (floatField.ClassListContains(StylesConfig.FloatField_Empty))
            {
                floatField.RemoveFromClassList(StylesConfig.FloatField_Empty);
            }
        }


        /// <summary>
        /// Add the float field to the empty style class.
        /// </summary>
        /// <param name="floatField">The float field to add the style to.</param>
        public static void ShowEmptyStyle(FloatField floatField)
        {
            // If the field isn't added to the empty style class yet.
            if (!floatField.ClassListContains(StylesConfig.FloatField_Empty))
            {
                floatField.AddToClassList(StylesConfig.FloatField_Empty);
            }
        }


        /// <summary>
        /// Add a custom image icon to the given float field.
        /// </summary>
        /// <param name="floatField">The float field to add the icon to.</param>
        /// <param name="iconTexture">The icon texture.</param>
        public static void AddFieldIcon
        (
            FloatField floatField,
            Texture iconTexture
        )
        {
            // Create a new image element and assign the USS style to it.
            Image floatFieldImage = ImageFactory.GetNewImage(imageUSS01: StylesConfig.FloatField_Icon);

            // Set the image's texture.
            floatFieldImage.image = iconTexture;

            // Set picking mode as ignore.
            floatFieldImage.pickingMode = PickingMode.Ignore;

            // Add the image element to the field.
            floatField.Add(floatFieldImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            floatFieldImage.SendToBack();
        }
    }
}