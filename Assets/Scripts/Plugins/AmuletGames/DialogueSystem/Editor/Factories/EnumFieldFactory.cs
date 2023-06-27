using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new enum input field UIElement.
        /// </summary>
        /// <param name="enumContainer">Reference of the enum container component.</param>
        /// <param name="containerValueChangedAction">The action to invoke along side with the field's ValueChangeEvent.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new enum input field UIElement.</returns>
        public static EnumField GetNewEnumField
        (
            EnumFieldViewBase enumContainer,
            Action containerValueChangedAction = null,
            string fieldUSS = ""
        )
        {
            EnumField enumField;

            CreateEnumField();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return enumField;

            void CreateEnumField()
            {
                enumField = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                enumContainer.EnumField = enumField;
            }

            void SetFieldDetails()
            {
                // Initialize the field's underlying type.
                enumContainer.InitFieldValue();

                // Set the field's input element picking mode to position
                // so that it reacts to the user's cursor.
                enumField.ElementAt(0).pickingMode = PickingMode.Position;
            }

            void RegisterFieldEvents()
            {
                EnumFieldCallbacks.RegisterValueChangedEvent
                (
                    enumContainer,
                    containerValueChangedAction
                );
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(fieldUSS);
            }
        }


        /// <summary>
        /// Factory method for creating a new iconic enum input field UIElement.
        /// </summary>
        /// <param name="iconicEnumContainer">Reference of the iconic enum container component.</param>
        /// <param name="containerValueChangedAction">The action to invoke along side with the field's ValueChangeEvent.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <param name="iconImageUSS">The USS style to set for the symbol image.</param>
        /// <returns>A new iconic enum input field UIElement.</returns>
        public static EnumField GetNewIconicEnumField
        (
            IconicEnumFieldViewBase iconicEnumContainer,
            Action containerValueChangedAction = null,
            string fieldUSS = "",
            string iconImageUSS = ""
        )
        {
            EnumField enumField;
            Image iconImage;

            CreateFieldElements();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return enumField;

            void CreateFieldElements()
            {
                enumField = new();
                iconImage = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                iconicEnumContainer.EnumField = enumField;
                iconicEnumContainer.IconImage = iconImage;
            }

            void SetFieldDetails()
            {
                // Initialize the field's underlying type.
                iconicEnumContainer.InitFieldValue();

                // Retrieve the input element from the field.
                VisualElement inputElement = enumField.ElementAt(0);

                // Remove all the child elements under the enum field's input element.
                inputElement.Clear();

                // Add the icon image to the input element.
                inputElement.Add(iconImage);

                // Set the field's input element picking mode to position
                // so that it reacts to the user's cursor.
                inputElement.pickingMode = PickingMode.Position;
            }

            void RegisterFieldEvents()
            {
                IconicEnumFieldCallbacks.RegisterValueChangedEvent
                (
                    iconicEnumContainer,
                    containerValueChangedAction
                );
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(fieldUSS);
                iconImage.AddToClassList(iconImageUSS);
            }
        }
    }
}