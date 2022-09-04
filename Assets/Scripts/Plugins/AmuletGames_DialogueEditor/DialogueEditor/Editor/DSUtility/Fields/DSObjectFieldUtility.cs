using UnityEditor.UIElements;

namespace AG
{
    public class DSObjectFieldUtility
    {
        /// <summary>
        /// If object field is currently empty then use a special USS style for the field label.
        /// </summary>
        /// <param name="objectField">The object field of which the empty style is applying to.</param>
        public static void ToggleEmptyStyle(ObjectField objectField)
        {
            if (objectField.value != null)
            {
                objectField.RemoveFromClassList(DSStylesConfig.Node_ObjectField_Empty);
            }
            else
            {
                objectField.AddToClassList(DSStylesConfig.Node_ObjectField_Empty);
            }
        }
    }
}