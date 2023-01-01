using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class FloatFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new float input field UIElement.
        /// </summary>
        /// <param name="floatContainer">Reference of the connecting float container component.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new float input field UIElement.</returns>
        public static FloatField GetNewFloatField
        (
            FloatContainer floatContainer,
            Sprite fieldIcon = null,
            string fieldUSS01 = ""
        )
        {
            FloatField floatField;

            CreateFloatField();

            ConnectFieldToContainer();

            SetFieldDetails();

            SetupFieldIcon();

            RegisterFieldEvents();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return floatField;

            void CreateFloatField()
            {
                floatField = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                floatContainer.FloatField = floatField;
            }

            void SetFieldDetails()
            {
                floatContainer.Value = default;
            }

            void SetupFieldIcon()
            {
                if (fieldIcon != null)
                    FloatFieldHelper.AddFieldIcon(floatField, fieldIcon.texture);
            }

            void RegisterFieldEvents()
            {
                FloatFieldCallbacks.RegisterFocusInEvent(floatField);
                FloatFieldCallbacks.RegisterFocusOutEvent(floatContainer);
            }

            void ShowEmptyStyle()
            {
                FloatFieldHelper.ShowEmptyStyle(floatField);
            }

            void AddFieldToStyleClass()
            {
                floatField.AddToClassList(fieldUSS01);
            }
        }
    }
}