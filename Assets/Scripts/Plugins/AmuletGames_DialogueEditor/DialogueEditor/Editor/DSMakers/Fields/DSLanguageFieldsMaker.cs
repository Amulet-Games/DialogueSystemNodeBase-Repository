using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public static class DSLanguageFieldsMaker
    {
        /// <summary>
        /// Returns a new text input field which can change it's input content base on the current selected language in the editor window.
        /// </summary>
        /// <param name="LG_Texts_Container">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="fieldIcon">The sprite that'll show up next to the input area.</param>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the language text container.</returns>
        public static TextField GetNewTextField
        (
            LanguageTextContainer LG_Texts_Container,
            Sprite fieldIcon,
            bool isMultiLine,
            string placeholderText,
            string USS01 = ""
        )
        {
            TextField textField;

            Create_LG_Texts();

            CreateTextField();

            ConnectFieldToContainer();

            SetFieldDetails();

            SetupFieldIcon();

            ShowEmptyStyle();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return textField;

            void Create_LG_Texts()
            {
                // Make new LGs foreach languages that this editor supports,
                // and add it to the list that inside the Container_LG_Texts.

                for (int i = 0; i < DSLanguagesConfig.SupportLanguageLength; i++)
                {
                    LanguageGenerics<string> new_LG_Text = new LanguageGenerics<string>();

                    new_LG_Text.LanguageType = DSLanguagesConfig.SupportLanguageTypes[i];
                    new_LG_Text.GenericsContent = "";

                    LG_Texts_Container.Value.Add(new_LG_Text);
                }
            }

            void CreateTextField()
            {
                textField = new TextField("");
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                LG_Texts_Container.TextField = textField;
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

                // At the moment, we can just set the TextField's value to whatever the string content that matched the editor language.
                textField.SetValueWithoutNotify
                (
                    LG_Texts_Container.Value
                    .Find(String_LG => String_LG.LanguageType == DSLanguagesConfig.SelectedLanguage)
                    .GenericsContent
                );

                // Set placeholder text.
                LG_Texts_Container.PlaceholderText = placeholderText;
            }

            void SetupFieldIcon()
            {
                DSTextFieldUtility.AddFieldIcon(textField, fieldIcon.texture);
            }

            void ShowEmptyStyle()
            {
                DSTextFieldUtility.ShowEmptyStyle(LG_Texts_Container);
            }

            void RegisterFieldEvents()
            {
                DSLanguageTextFieldCallbacks.RegisterValueChangedEvent(LG_Texts_Container);
                DSLanguageTextFieldCallbacks.RegisterFieldFocusInEvent(textField);
                DSLanguageTextFieldCallbacks.RegisterFieldFocusOutEvent(LG_Texts_Container);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }


        /// <summary>
        /// Returns a new object field which accepts audio clip assets as inputs,
        /// <br>and can change it's input content base on the current selected language in the editor window.</br>
        /// </summary>
        /// <param name="LG_AudioClip_Container">The container that'll combine and save the field as reference for other modules to use.</param>
        /// <param name="fieldIcon">The sprite that'll show up next to the input area.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new object field UIElement which connected to the language audio clip container.</returns>
        public static ObjectField GetNewAudioClipField
        (
            LanguageAudioClipContainer LG_AudioClip_Container,
            Sprite fieldIcon,
            string USS01 = ""
        )
        {
            ObjectField objectField;

            Create_LG_AudioClips();

            CreateObjectField();

            ConnectFieldToContainer();

            SetFieldDetails();

            ReplaceFieldIcon();

            ToggleEmptyStyle();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return objectField;

            void Create_LG_AudioClips()
            {
                // Make new LGs foreach languages that this editor supports,
                // and add it to the list that inside the Container_LG_AudioClips.

                for (int i = 0; i < DSLanguagesConfig.SupportLanguageLength; i++)
                {
                    LanguageGenerics<AudioClip> new_LG_AudioClip = new LanguageGenerics<AudioClip>();

                    new_LG_AudioClip.LanguageType = DSLanguagesConfig.SupportLanguageTypes[i];
                    new_LG_AudioClip.GenericsContent = null;

                    LG_AudioClip_Container.Value.Add(new_LG_AudioClip);
                }
            }

            void CreateObjectField()
            {
                objectField = new ObjectField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this ObjectField to the Container's Reference.

                LG_AudioClip_Container.ObjectField = objectField;
            }

            void SetFieldDetails()
            {
                // Type of any audio clip.
                objectField.objectType = typeof(AudioClip);

                // Don't allow scene references to be input to the field.
                objectField.allowSceneObjects = false;

                // Make sure the field's audio clip matches the current editor language's audio clip.
                objectField.SetValueWithoutNotify
                (
                    LG_AudioClip_Container.Value
                    .Find(AudioClip_LG => AudioClip_LG.LanguageType == DSLanguagesConfig.SelectedLanguage)
                    .GenericsContent
                );
            }

            void ReplaceFieldIcon()
            {
                DSObjectFieldUtility.ReplaceFieldsIcon(objectField, fieldIcon.texture);
            }

            void ToggleEmptyStyle()
            {
                DSObjectFieldUtility.ToggleEmptyStyle(objectField);
            }

            void RegisterFieldEvents()
            {
                DSLanguageAudioClipFieldCallbacks.RegisterValueChangedEvent(LG_AudioClip_Container);
                DSLanguageAudioClipFieldCallbacks.RegisterFieldFocusInEvent(objectField);
                DSLanguageAudioClipFieldCallbacks.RegisterFieldFocusOutEvent(objectField);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }
    }
}