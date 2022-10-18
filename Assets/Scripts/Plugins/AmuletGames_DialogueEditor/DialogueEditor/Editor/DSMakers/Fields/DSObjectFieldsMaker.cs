using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG
{
    public class DSObjectFieldsMaker
    {
        /// <summary>
        /// Returns a new object field which accepts any assets as type object as inputs.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="objectContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new object field UIElement which connected to the TObject's object container.</returns>
        public static ObjectField GetNewObjectField<TObject>
        (
            DSObjectContainer<TObject> objectContainer,
            Sprite fieldIcon,
            string USS01 = ""
        )
            where TObject : Object
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetFieldDetails();

            ReplaceFieldIcon();

            ShowEmptyStyle();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return objectField;

            void CreateObjectField()
            {
                objectField = new ObjectField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this ObjectField to the Container's Reference.
                objectContainer.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Type of any object.
                objectField.objectType = typeof(TObject);

                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;

                // Make sure the field's value matches the connecting container's.
                objectField.value = objectContainer.Value;
            }

            void ReplaceFieldIcon()
            {
                DSObjectFieldUtility.ReplaceFieldsIcon(objectField, fieldIcon.texture);
            }

            void ShowEmptyStyle()
            {
                DSObjectFieldUtility.ShowEmptyStyle(objectField);
            }

            void RegisterFieldEvents()
            {
                DSObjectFieldCallbacks.RegisterValueChangedEvent(objectContainer);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Returns a new object field which accepts sprite assets as inputs.
        /// </summary>
        /// <param name="spriteContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="imageElement">The image UIElement to use to show the sprite's texture as previews.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <param name="USS02">The second style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new object field UIElement which connected to the sprite container.</returns>
        public static ObjectField GetNewSpriteField
        (
            DSObjectContainer<Sprite> spriteContainer,
            Image imageElement,
            string USS01 = "",
            string USS02 = ""
        )
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetFieldDetails();

            ShowEmptyStyle();

            RegisterFieldEvents();

            UpdateImagePreview();

            AddFieldToStyleClass();

            return objectField;

            void CreateObjectField()
            {
                objectField = new ObjectField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this ObjectField to the Container's Reference.
                spriteContainer.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Type of any object.
                objectField.objectType = typeof(Sprite);

                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;

                // Make sure the field's value matches the connecting container's.
                objectField.value = spriteContainer.Value;
            }

            void ShowEmptyStyle()
            {
                DSObjectFieldUtility.ShowEmptyStyle(objectField);
            }

            void RegisterFieldEvents()
            {
                DSObjectFieldCallbacks.RegisterValueChangedEvent(spriteContainer);
                DSSpriteFieldCallbacks.AddValueChangedListeners(spriteContainer, imageElement);
            }

            void UpdateImagePreview()
            {
                DSImageUtility.UpdateImagePreview(spriteContainer.Value, imageElement);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
                objectField.AddToClassList(USS02);
            }
        }
    }
}