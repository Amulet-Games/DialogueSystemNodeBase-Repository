using System;
using UnityEditor.UIElements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class ObjectFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new object input field UIElement.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="objectContainer">Reference of the connecting object container component.</param>
        /// <param name="containerValueChangedAction">The action to invoke along side with the field's ValueChangeEvent.</param>
        /// <param name="fieldIcon">The icon to set for field, it shows up next to the its input area.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="fieldUSS02">The second USS style to set for the field.</param>
        /// <returns>A new object input field UIElement.</returns>
        public static ObjectField GetNewObjectField<TObject>
        (
            ObjectContainer<TObject> objectContainer,
            Action containerValueChangedAction = null,
            Sprite fieldIcon = null,
            string fieldUSS01 = "",
            string fieldUSS02 = ""
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
                objectField = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field to the container's.
                objectContainer.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Type of any object.
                objectField.objectType = typeof(TObject);

                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;

                // Set value as null.
                objectField.value = null;
            }

            void ReplaceFieldIcon()
            {
                if (fieldIcon != null)
                {
                    ObjectFieldHelper.ReplaceFieldsIcon
                    (
                        objectField: objectField,
                        newIconTexture: fieldIcon.texture
                    );
                }
            }

            void ShowEmptyStyle()
            {
                ObjectFieldHelper.ShowEmptyStyle(objectField);
            }

            void RegisterFieldEvents()
            {
                ObjectFieldCallbacks.RegisterValueChangedEvent
                (
                    objectContainer,
                    containerValueChangedAction
                );
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(fieldUSS01);

                if (fieldUSS02 != "")
                    objectField.AddToClassList(fieldUSS02);
            }
        }
    }
}