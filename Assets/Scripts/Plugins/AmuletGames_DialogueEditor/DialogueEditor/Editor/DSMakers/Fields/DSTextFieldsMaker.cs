using UnityEngine.UIElements;

namespace AG
{
    public class DSTextFieldsMaker
    {
        /// <summary>
        /// Returns a new text input field.
        /// </summary>
        /// <param name="textContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the text container.</returns>
        public static TextField GetNewTextField(TextContainer textContainer, string placeholderText, string USS01 = "")
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
                // Create a new text field.
                textField = new TextField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                textContainer.TextField = textField;
            }

            void RegisterFieldEvents()
            {
                DSTextFieldEventRegister.RegisterValueChangedEvent(textContainer);
                DSTextFieldEventRegister.RegisterFieldFocusInEvent(textField);
                DSTextFieldEventRegister.RegisterFieldFocusOutEvent(textContainer);
            }

            void UpdatePlaceHolderText()
            {
                // Save the placeholder texts to Container.
                textContainer.PlaceholderText = placeholderText;

                // Setup field's placeholder.
                DSTextFieldUtility.ShowEmptyStyle(textContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Returns a new text input field for the node's title.
        /// </summary>
        /// <param name="textContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="currentTitleText">The current title text of the node that the field is created upon on.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the text container.</returns>
        public static TextField GetNewNodeTitleField(TextContainer textContainer, string currentTitleText, string USS01 = "")
        {
            TextField nodeTitleField;

            CreateTextField();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return nodeTitleField;

            void CreateTextField()
            {
                // Create a new text field.
                nodeTitleField = new TextField();

                // Set its value with the current node's title.
                nodeTitleField.SetValueWithoutNotify(currentTitleText);
            }

            void ConnectFieldToContainer()
            {
                // Connect the node title field to the Container's Reference.
                textContainer.TextField = nodeTitleField;
                textContainer.Value = nodeTitleField.value;
            }

            void SetFieldDetails()
            {
                // Field will not invoke OnValueChangedCallback unless user has pressed enter.
                nodeTitleField.isDelayed = true;

                // Field cannot have more than one line.
                nodeTitleField.multiline = false;

                // Set both the field and input base to block user's mouse interaction.
                nodeTitleField.pickingMode = PickingMode.Ignore;
                nodeTitleField.GetTextFieldInputBase().pickingMode = PickingMode.Ignore;
            }

            void RegisterFieldEvents()
            {
                DSNodeTitleFieldEventRegister.RegisterNodeTitleChangedEvent(textContainer);
                DSNodeTitleFieldEventRegister.RegisterNodeTitleFocusInEvent(textContainer);
                DSNodeTitleFieldEventRegister.RegisterNodeTitleFocusOutEvent(textContainer);
            }

            void AddFieldToStyleClass()
            {
                nodeTitleField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Returns a new text input field for the custom graph editor's title.
        /// </summary>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which doesn't connect to any containers and will stay on top in the editor window.</returns>
        public static TextField GetNewGraphTitleField(string USS01 = "")
        {
            TextField graphTitleField;

            CreateGraphTitleField();

            SetFieldIsDelayedToTrue();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return graphTitleField;

            void CreateGraphTitleField()
            {
                graphTitleField = new TextField();
            }

            void SetFieldIsDelayedToTrue()
            {
                // Field will not invoke OnValueChangedCallback unless user has pressed enter.
                graphTitleField.isDelayed = true;
            }

            void RegisterFieldEvents()
            {
                DSGraphTitleFieldEventRegister.RegisterGraphTitleChangedEvent(graphTitleField);
                DSGraphTitleFieldEventRegister.RegisterGraphTitleFocusOutEvent(graphTitleField);
            }

            void AddFieldToStyleClass()
            {
                graphTitleField.AddToClassList(USS01);
            }
        }
    }
}