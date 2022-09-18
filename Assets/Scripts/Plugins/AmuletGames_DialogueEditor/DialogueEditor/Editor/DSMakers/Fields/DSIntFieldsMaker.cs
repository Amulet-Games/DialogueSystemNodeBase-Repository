using UnityEditor.UIElements;

namespace AG
{
    public class DSIntFieldsMaker
    {
        /// <summary>
        /// Returns a new int input field.
        /// </summary>
        /// <param name="intContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new int field UIElement which connected to the int container.</returns>
        public static IntegerField GetNewIntegerField(IntContainer intContainer, string USS01 = "")
        {
            IntegerField intField;

            CreateIntField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return intField;

            void CreateIntField()
            {
                intField = new IntegerField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this IntField to the Container's Reference.
                intContainer.IntField = intField;
            }

            void SetupContainerField()
            {
                intContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSIntFieldEventRegister.RegisterValueChangedEvent(intContainer);
            }

            void AddFieldToStyleClass()
            {
                intField.AddToClassList(USS01);
            }
        }
    }
}