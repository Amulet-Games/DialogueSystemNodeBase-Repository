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
        /// <param name="enumContainer">Reference of the connecting enum container component.</param>
        /// <param name="containerValueChangedAction">The action to invoke along side with the field's ValueChangeEvent.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new enum input field UIElement.</returns>
        public static EnumField GetNewEnumField
        (
            EnumContainerBase enumContainer,
            Action containerValueChangedAction = null,
            string fieldUSS01 = ""
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
                enumField = new EnumField();
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
                enumField.AddToClassList(fieldUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new iconic enum input field UIElement.
        /// </summary>
        /// <param name="iconicEnumContainer">Reference of the connecting iconic enum container component.</param>
        /// <param name="containerValueChangedAction">The action to invoke along side with the field's ValueChangeEvent.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="iconImageUSS01">The first USS style to set for the symbol image.</param>
        /// <returns>A new iconic enum input field UIElement.</returns>
        public static EnumField GetNewIconicEnumField
        (
            IconicEnumContainerBase iconicEnumContainer,
            Action containerValueChangedAction = null,
            string fieldUSS01 = "",
            string iconImageUSS01 = ""
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
                enumField = new EnumField();
                iconImage = new Image();
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

                // Retreive the input element from the field.
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
                enumField.AddToClassList(fieldUSS01);
                iconImage.AddToClassList(iconImageUSS01);
            }
        }
    }
}