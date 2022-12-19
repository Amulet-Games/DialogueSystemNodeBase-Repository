using UnityEditor.UIElements;

namespace AG.DS
{
    public class IntFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new int input field UIElement.
        /// </summary>
        /// <param name="intContainer">Reference of the connecting int container component.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new int input field UIElement.</returns>
        public static IntegerField GetNewIntegerField
        (
            IntContainer intContainer,
            string fieldUSS01 = ""
        )
        {
            IntegerField intField;

            CreateIntField();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return intField;

            void CreateIntField()
            {
                intField = new IntegerField();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                intContainer.IntField = intField;
            }

            void SetFieldDetails()
            {
                intContainer.Value = default;
            }

            void RegisterFieldEvents()
            {
                IntFieldCallbacks.RegisterFieldFocusOutEvent(intContainer);
            }

            void AddFieldToStyleClass()
            {
                intField.AddToClassList(fieldUSS01);
            }
        }
    }
}