using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSSpriteFieldEventRegister : DSObjectFieldEventRegister
    {
        /// <summary>
        /// Each time the object field is assigned to a new sprite,
        /// <br>the Value(sprite) in the object Container will changed at the sametime.</br>
        /// </summary>
        /// <param name="spriteContainer">Object container of which the object field is connecting to.</param>
        /// <param name="referedImage">The image of which this field is connecting to and will get updated.</param>
        public static void RegisterValueChangedEvent(SpriteContainer spriteContainer, Image referedImage)
        {
            spriteContainer.ObjectField.RegisterValueChangedCallback(value => 
            {
                spriteContainer.Value = value.newValue as Sprite;

                DSImageUtility.UpdateImagePreview(spriteContainer.Value, referedImage);

                DSObjectFieldUtility.ToggleEmptyStyle(spriteContainer.ObjectField);

                InvokeDSWindowChangedEvent();
            });
        }
    }
}