using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public static class LanguageFieldFactory
    {
        /// <summary>
        /// Factory method for creating a new language text input field UIElement.
        /// </summary>
        /// <param name="languageTextContainer">Reference of the connecting language text container component.</param>
        /// <param name="fieldIcon">The icon to set for field, it shows up next to the its input area.</param>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new language text input field UIElement.</returns>
        public static TextField GetNewTextField
        (
            LanguageTextContainer languageTextContainer,
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

            ShowEmptyStyle();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                textField = new("");
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                languageTextContainer.TextField = textField;
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

                for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
                {
                    // Set TKey and TValue to each of the language type and empty string.
                    languageTextContainer.LanguageGeneric
                        .ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] = "";
                }

                // Set placeholder text.
                languageTextContainer.PlaceholderText = placeholderText;
            }

            void SetupFieldIcon()
            {
                TextFieldHelper.AddFieldIcon
                (
                    textField: textField,
                    iconTexture: fieldIcon.texture
                );
            }

            void ShowEmptyStyle()
            {
                TextFieldHelper.ShowEmptyStyle(languageTextContainer);
            }

            void RegisterFieldEvents()
            {
                LanguageTextFieldCallbacks.RegisterFocusInEvent(textField);
                LanguageTextFieldCallbacks.RegisterFocusOutEvent(languageTextContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(fieldUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new object input field UIElement.
        /// </summary>
        /// <param name="languageAudioClipContainer">Reference of the connecting language audio clip container component.</param>
        /// <param name="fieldIcon">The icon to set for field, it shows up next to the its input area.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new language object input field UIElement.</returns>
        public static ObjectField GetNewAudioClipField
        (
            LanguageAudioClipContainer languageAudioClipContainer,
            Sprite fieldIcon,
            string fieldUSS01 = ""
        )
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetFieldDetails();

            ReplaceFieldIcon();

            ToggleEmptyStyle();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return objectField;

            void CreateObjectField()
            {
                objectField = new();
            }

            void ConnectFieldToContainer()
            {
                // Connect the field with the container.
                languageAudioClipContainer.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Type of any audio clip.
                objectField.objectType = typeof(AudioClip);

                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;

                for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
                {
                    // Set TKey and TValue to each of the language type and null.
                    languageAudioClipContainer.LanguageGeneric
                        .ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] = null;
                }
            }

            void ReplaceFieldIcon()
            {
                ObjectFieldHelper.ReplaceFieldsIcon
                (
                    objectField: objectField,
                    newIconTexture: fieldIcon.texture
                );
            }

            void ToggleEmptyStyle()
            {
                ObjectFieldHelper.ToggleEmptyStyle(objectField);
            }

            void RegisterFieldEvents()
            {
                LanguageAudioClipFieldCallbacks.RegisterValueChangedEvent(languageAudioClipContainer);
                LanguageAudioClipFieldCallbacks.RegisterFocusInEvent(objectField);
                LanguageAudioClipFieldCallbacks.RegisterFocusOutEvent(objectField);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(fieldUSS01);
            }
        }
    }
}