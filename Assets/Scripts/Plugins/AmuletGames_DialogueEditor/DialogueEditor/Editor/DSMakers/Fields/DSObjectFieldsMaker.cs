using UnityEditor.UIElements;
using UnityEngine.UIElements;
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
        public static ObjectField GetNewObjectField<TObject>(ObjectContainer<TObject> objectContainer, string USS01 = "") where TObject : Object
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetupContainerField();

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

            void SetupContainerField()
            {
                objectContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSObjectFieldEventRegister.RegisterValueChangedEvent(objectContainer);
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
        public static ObjectField GetNewSpriteField(SpriteContainer spriteContainer, Image imageElement, string USS01 = "", string USS02 = "")
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetupContainerField();

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

            void SetupContainerField()
            {
                spriteContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSSpriteFieldEventRegister.RegisterValueChangedEvent(spriteContainer, imageElement);
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