using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSObjectFieldUtility
    {
        /// <summary>
        /// Add the object field to the empty style class if its value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="objectField">The object field to add or remove the style from.</param>
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


        /// <summary>
        /// Remove the object field from the empty style class.
        /// </summary>
        /// <param name="objectField">The text field to remove the style from.</param>
        public static void HideEmptyStyle(ObjectField objectField)
        {
            // If the field is added to the empty style class previously.
            if (objectField.ClassListContains(DSStylesConfig.Node_ObjectField_Empty))
            {
                objectField.RemoveFromClassList(DSStylesConfig.Node_ObjectField_Empty);
            }
        }


        /// <summary>
        /// Add the object field to the empty style class.
        /// </summary>
        /// <param name="objectField">The object field to add the style to.</param>
        public static void ShowEmptyStyle(ObjectField objectField)
        {
            // If the field isn't added to the empty style class yet.
            if (!objectField.ClassListContains(DSStylesConfig.Node_ObjectField_Empty))
            {
                objectField.AddToClassList(DSStylesConfig.Node_ObjectField_Empty);
            }
        }


        /// <summary>
        /// Remove the original object field's image icon and replace it with the custom ones.
        /// </summary>
        /// <param name="objectField">The object field of which its icon is going to be replaced.</param>
        /// <param name="newIconTexture">The new icon texture to replace with.</param>
        public static void ReplaceFieldsIcon
        (
            ObjectField objectField,
            Texture newIconTexture
        )
        {
            // Get the object field dsplay element from the object field.
            VisualElement ObjectFieldDisplay = objectField.ElementAt(0).ElementAt(0);

            // Remove the origial image icon from the object field.
            ObjectFieldDisplay.Remove(ObjectFieldDisplay.ElementAt(0));

            // Create a new image element and assign the USS style to it.
            Image objectFieldImage = DSImagesMaker.GetNewImage(DSStylesConfig.Node_ObjectField_Icon);

            // Set the image's texture.
            objectFieldImage.image = newIconTexture;

            // Add the image element to the field.
            ObjectFieldDisplay.Add(objectFieldImage);

            // Place it as the first element within the field's hierarchy list
            // so that it's align on the left side.
            objectFieldImage.SendToBack();
        }
    }
}