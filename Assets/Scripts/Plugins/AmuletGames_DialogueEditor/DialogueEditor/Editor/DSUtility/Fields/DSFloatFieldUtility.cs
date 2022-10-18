using UnityEditor.UIElements;

namespace AG
{
    public class DSFloatFieldUtility
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
                floatField.RemoveFromClassList(DSStylesConfig.Node_FloatField_Empty);
            }
            else
            {
                floatField.AddToClassList(DSStylesConfig.Node_FloatField_Empty);
            }
        }


        /// <summary>
        /// Remove the float field from the empty style class.
        /// </summary>
        /// <param name="floatField">The float field to remove the style from.</param>
        public static void HideEmptyStyle(FloatField floatField)
        {
            // If the field is added to the empty style class previously.
            if (floatField.ClassListContains(DSStylesConfig.Node_FloatField_Empty))
            {
                floatField.RemoveFromClassList(DSStylesConfig.Node_FloatField_Empty);
            }
        }


        /// <summary>
        /// Add the float field to the empty style class.
        /// </summary>
        /// <param name="floatField">The float field to add the style to.</param>
        public static void ShowEmptyStyle(FloatField floatField)
        {
            // If the field isn't added to the empty style class yet.
            if (!floatField.ClassListContains(DSStylesConfig.Node_FloatField_Empty))
            {
                floatField.AddToClassList(DSStylesConfig.Node_FloatField_Empty);
            }
        }
    }
}