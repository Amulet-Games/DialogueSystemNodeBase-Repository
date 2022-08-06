using UnityEditor.UIElements;

namespace AG
{
    public class DSFloatFieldsMaker
    {
        /// <summary>
        /// Create a new float input field.
        /// </summary>
        /// <param name="floatContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new float field UIElement which connected to the float container.</returns>
        public static FloatField GetNewFloatField(FloatContainer floatContainer, string USS01 = "")
        {
            FloatField floatField;

            CreateFloatField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return floatField;

            void CreateFloatField()
            {
                floatField = new FloatField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this FloatField to the Container's Reference.
                floatContainer.FloatField = floatField;
            }

            void SetupContainerField()
            {
                floatContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSFloatFieldEventRegister.RegisterValueChangedEvent(floatContainer);
            }

            void AddFieldToStyleClass()
            {
                floatField.AddToClassList(USS01);
            }
        }
    }
}