using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSTextFieldsMaker
    {
        /// <summary>
        /// Returns a new text input field.
        /// </summary>
        /// <param name="textContainer">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the text container.</returns>
        public static TextField GetNewTextField
        (
            TextContainer textContainer,
            bool isMultiLine,
            string placeholderText,
            string USS01 = ""
        )
        {
            TextField textField;

            CreateTextField();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            ShowEmptyStyle();

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

            void SetFieldDetails()
            {
                // Set multi-line property.
                textField.multiline = isMultiLine;

                // Set white space style,
                // Normal means the texts'll auto line break when it reached the end of the input box,
                // NoWarp means the texts are shown in one line even it's expanded outside the input box.
                textField.style.whiteSpace = isMultiLine
                    ? WhiteSpace.Normal
                    : WhiteSpace.NoWrap;

                // Set placeholder text.
                textContainer.PlaceholderText = placeholderText;
            }

            void RegisterFieldEvents()
            {
                DSTextFieldCallbacks.RegisterValueChangedEvent(textContainer);
                DSTextFieldCallbacks.RegisterFieldFocusInEvent(textField);
                DSTextFieldCallbacks.RegisterFieldFocusOutEvent(textContainer);
            }

            void ShowEmptyStyle()
            {
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
        public static TextField GetNewNodeTitleField
        (
            TextContainer textContainer,
            string currentTitleText,
            string USS01 = ""
        )
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
                nodeTitleField.GetFieldInputBase().pickingMode = PickingMode.Ignore;
            }

            void RegisterFieldEvents()
            {
                DSNodeTitleFieldCallbacks.RegisterNodeTitleChangedEvent(textContainer);
                DSNodeTitleFieldCallbacks.RegisterNodeTitleFocusInEvent(textContainer);
                DSNodeTitleFieldCallbacks.RegisterNodeTitleFocusOutEvent(textContainer);
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
        public static TextField GetNewGraphTitleField(DialogueEditorWindow dsWindow, string USS01 = "")
        {
            TextField graphTitleField;

            CreateGraphTitleField();

            SetFieldDetails();

            BindGraphTitleField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return graphTitleField;

            void CreateGraphTitleField()
            {
                graphTitleField = new TextField();
            }

            void SetFieldDetails()
            {
                // Field will not invoke OnValueChangedCallback unless user has pressed enter.
                graphTitleField.isDelayed = true;
            }

            void BindGraphTitleField()
            {
                // Create the serialized object from the DSContainerSO.
                SerializedObject so = new SerializedObject(dsWindow.DSContainerSO);

                // Bind object to the field directly.
                graphTitleField.Bind(so);

                // Setup callback action when the bound serialized object's value has changed.
                graphTitleField.TrackSerializedObjectValue(so, so =>
                {
                    graphTitleField.SetValueWithoutNotify(so.targetObject.name);
                });
            }

            void RegisterFieldEvents()
            {
                DSGraphTitleFieldCallbacks.RegisterGraphTitleChangedEvent(graphTitleField);
                DSGraphTitleFieldCallbacks.RegisterGraphTitleFocusOutEvent(graphTitleField);
            }

            void AddFieldToStyleClass()
            {
                graphTitleField.AddToClassList(USS01);
            }
        }
    }
}