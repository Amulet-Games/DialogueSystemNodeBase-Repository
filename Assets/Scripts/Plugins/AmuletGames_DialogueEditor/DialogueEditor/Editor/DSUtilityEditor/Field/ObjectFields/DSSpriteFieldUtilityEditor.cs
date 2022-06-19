using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSSpriteFieldUtilityEditor : DSObjectFieldUtilityEditor
    {
        /// <summary>
        /// Each time the object field is assigned to a new sprite,
        /// the Value(sprite) in the object Container will changed at the sametime.
        /// </summary>
        /// <param name="spriteContainer">Object container of which the object field is connecting to.</param>
        /// <param name="referedImage">The image of which this field is connecting to and will get updated.</param>
        public static void RegisterValueChangedEvent(SpriteObjectContainer spriteContainer, Image referedImage)
        {
            spriteContainer.ObjectField.RegisterValueChangedCallback(value => 
            {
                spriteContainer.Value = value.newValue as Sprite;

                DSObjectFieldUtility.UpdateImagePreview(spriteContainer.Value, referedImage);

                DSObjectFieldUtility.ToggleEmptyStyle(spriteContainer.ObjectField);

                InvokeDSWindowChangedEvent();
            });
        }
    }
}