using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class VariableFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new variable object input field UIElement.
        /// </summary>
        /// <param name="variableContainer">The variable object container to set for.</param>
        /// <param name="fieldIcon">The icon to set for field, it shows up next to the its input area.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new variable object input field UIElement.</returns>
        public static ObjectField GetNewObjectField
        (
            VariableFieldModel variableContainer,
            Sprite fieldIcon,
            string fieldUSS01
        )
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetFieldDetails();

            ReplaceFieldIcon();

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
                variableContainer.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;
            }

            void ReplaceFieldIcon()
            {
                if (fieldIcon != null)
                {
                    //TODO: This should be Remove and Add.
                    objectField.RemoveFieldIcon();
                }
            }

            void RegisterFieldEvents()
            {
                VariableObjectFieldCallbacks.RegisterValueChangedEvent(variableContainer);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(fieldUSS01);
            }
        }
    }
}