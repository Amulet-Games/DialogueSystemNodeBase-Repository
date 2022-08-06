using UnityEngine.UIElements;

namespace AG
{
    public class DSTextFieldsMaker
    {
        /// <summary>
        /// Create a new text input field.
        /// </summary>
        /// <param name="textsContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the text container.</returns>
        public static TextField GetNewTextField(TextContainer textsContainer, string placeholderText, string USS01 = "")
        {
            TextField textField;

            CreateTextField();

            ConnectFieldToContainer();

            RegisterFieldEvents();

            UpdatePlaceHolderText();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                textField = new TextField();

                textField.SetValueWithoutNotify(textsContainer.Value);
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                textsContainer.TextField = textField;
            }

            void RegisterFieldEvents()
            {
                DSTextFieldEventRegister.RegisterValueChangedEvent(textsContainer);
                DSTextFieldEventRegister.RegisterFieldFocusInEvent(textField);
                DSTextFieldEventRegister.RegisterFieldFocusOutEvent(textsContainer);
            }

            void UpdatePlaceHolderText()
            {
                // Save the placeholder texts to Container.
                textsContainer.PlaceholderText = placeholderText;

                // Setup field's placeholder.
                DSTextFieldUtility.ShowEmptyStyle(textsContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Create a new text input field for the dialogue system's title.
        /// </summary>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which doesn't connect to any containers and will stay on top in the editor window.</returns>
        public static TextField GetTitleTextField(string USS01 = "")
        {
            TextField textField;

            CreateTextField();

            SetFieldIsDelayedToTrue();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                textField = new TextField();
            }

            void SetFieldIsDelayedToTrue()
            {
                // Field will not invoke OnValueChangedCallback unless user has pressed enter.
                textField.isDelayed = true;
            }

            void RegisterFieldEvents()
            {
                DSTitleTextEventRegister.RegisterTitleChangedEvent(textField);
                DSTitleTextEventRegister.RegisterTitleFocusOutEvent(textField);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }
    }
}