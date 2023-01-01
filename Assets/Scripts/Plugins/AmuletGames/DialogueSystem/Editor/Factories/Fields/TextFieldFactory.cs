using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class TextFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new text input field UIElement.
        /// </summary>
        /// <param name="textContainer">Reference of the connecting text container component.</param>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The placeholder text to set for the field when there's no actual text within it.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new text input field UIElement.</returns>
        public static TextField GetNewTextField
        (
            TextContainer textContainer,
            Sprite fieldIcon,
            bool isMultiLine,
            string placeholderText,
            string fieldUSS01 = ""
        )
        {
            TextField textField;

            CreateTextField();

            ConnectFieldToContainer();

            SetFieldDetails();

            SetupFieldIcon();

            RegisterFieldEvents();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                // Create a new text field.
                textField = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
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

                // Set value as empty.
                textContainer.Value = "";

                // Set placeholder text.
                textContainer.PlaceholderText = placeholderText;
            }

            void SetupFieldIcon()
            {
                TextFieldHelper.AddFieldIcon(textField, fieldIcon.texture);
            }

            void RegisterFieldEvents()
            {
                TextFieldCallbacks.RegisterFocusInEvent(textField);
                TextFieldCallbacks.RegisterFocusOutEvent(textContainer);
            }

            void ShowEmptyStyle()
            {
                TextFieldHelper.ShowEmptyStyle(textContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(fieldUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new delayable text input field UIElement.
        /// </summary>
        /// <param name="textContainer">Reference of the connecting text container component.</param>
        /// <param name="defaultText">The default text to set for the field when it's first created.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new delayable text input field UIElement.</returns>
        public static TextField GetNewDelayableTextField
        (
            TextContainer textContainer,
            string defaultText,
            string fieldUSS01 = ""
        )
        {
            TextField textField;

            CreateTextField();

            ConnectFieldToContainer();

            SetFieldDetails();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                // Create a new text field.
                textField = new();

                // Set its value with the current node's title.
                textField.SetValueWithoutNotify(defaultText);
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                textContainer.TextField = textField;
                textContainer.Value = textField.value;
            }

            void SetFieldDetails()
            {
                // The new field's value won't be set unless the user pressed enter.
                textField.isDelayed = true;

                // The field cannot have more than one line.
                textField.multiline = false;

                // Set both the field and input base to block user's mouse interaction.
                textField.pickingMode = PickingMode.Ignore;
                textField.GetFieldInputBase().pickingMode = PickingMode.Ignore;
            }

            void RegisterFieldEvents()
            {
                DelayableTextFieldCallbacks.RegisterValueChangedEvent(textContainer);
                DelayableTextFieldCallbacks.RegisterFocusInEvent(textContainer);
                DelayableTextFieldCallbacks.RegisterFocusOutEvent(textContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(fieldUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new text input field for the graph's title.
        /// </summary>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new graph title's text input field UIElement.</returns>
        public static TextField GetNewGraphTitleField
        (
            DialogueEditorWindow dsWindow,
            string fieldUSS01 = ""
        )
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
                graphTitleField = new();
            }

            void SetFieldDetails()
            {
                // The new field's value won't be set unless the user pressed enter.
                graphTitleField.isDelayed = true;
            }

            void BindGraphTitleField()
            {
                // Create the serialized object from the dialogue system data.
                SerializedObject so = new(dsWindow.DsData);

                // Bind object to the field directly.
                graphTitleField.Bind(so);

                // Setup callback action when the bound serialized object's value has changed.
                graphTitleField.TrackSerializedObjectValue(obj: so, so =>
                {
                    graphTitleField.SetValueWithoutNotify(so.targetObject.name);
                });
            }

            void RegisterFieldEvents()
            {
                GraphTitleFieldCallbacks.RegisterValueChangedEvent(graphTitleField);
                GraphTitleFieldCallbacks.RegisterGraphTitleFocusOutEvent(graphTitleField);
            }

            void AddFieldToStyleClass()
            {
                graphTitleField.AddToClassList(fieldUSS01);
            }
        }
    }
}