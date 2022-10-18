using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEnumFieldsMaker
    {
        /// <summary>
        /// Returns a new enum input field.
        /// </summary>
        /// <param name="enumContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new enum field UIElement which connected to the enum container.</returns>
        public static EnumField GetNewEnumField
        (
            EnumContainerBase enumContainer,
            string USS01 = ""
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
                // Connect this EnumField to the Container's Reference.
                enumContainer.EnumField = enumField;
            }

            void SetFieldDetails()
            {
                // Initialize the field's underlying type.
                enumContainer.InitFieldValue();

                // Set the field's picking mode to be position so that it reacts to users' cursor.
                enumField.ElementAt(0).pickingMode = PickingMode.Position;
            }

            void RegisterFieldEvents()
            {
                DSEnumFieldCallbacks.RegisterValueChangedEvent(enumContainer);
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Returns a new enum input field.
        /// <para>
        /// Note that changing the selected type of the field will invoke DSWindowChangedEvent right after the specified enumFieldValueChangedAction.
        /// </para>
        /// </summary>
        /// <param name="enumContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="enumFieldValueChangedAction">The action to invoke when changed the field's selected type.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new enum field UIElement which connected to the enum container.</returns>
        public static EnumField GetNewEnumField
        (
            EnumContainerBase enumContainer,
            Action enumFieldValueChangedAction,
            string USS01 = ""
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
                // Connect this EnumField to the Container's Reference.
                enumContainer.EnumField = enumField;
            }

            void SetFieldDetails()
            {
                // Initialize the field's underlying type.
                enumContainer.InitFieldValue();

                // Set the field's picking mode to be position so that it reacts to users' cursor.
                enumField.ElementAt(0).pickingMode = PickingMode.Position;
            }

            void RegisterFieldEvents()
            {
                DSEnumFieldCallbacks.RegisterValueChangedEvent(enumContainer, enumFieldValueChangedAction);
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(USS01);
            }
        }
    }
}