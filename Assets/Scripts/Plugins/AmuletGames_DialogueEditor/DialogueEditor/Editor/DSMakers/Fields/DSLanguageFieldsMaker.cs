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
        /// <param name="placeholderText">The text that'll show up in the field when there's no actual content within it.</param>
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new text field UIElement which connected to the language text container.</returns>
        public static TextField GetNewLanguageField_Text(LanguageTextContainer LG_Texts_Container, string placeholderText, string USS01 = "")
        {
            TextField textField;

            Create_LG_Texts();

            CreateTextField();

            ConnectFieldToContainer();

            RegisterFieldEvents();

            UpdatePlaceHolderText();

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

                // TextField is set to be multi-line.
                textField.multiline = true;

                // At the moment, we can just set the TextField's value to whatever the string content that matched the editor language.
                textField.SetValueWithoutNotify(LG_Texts_Container.Value.Find
                (
                    String_LG => String_LG.LanguageType == DSLanguagesConfig.SelectedLanguage
                )
                .GenericsContent);
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                LG_Texts_Container.TextField = textField;
            }

            void RegisterFieldEvents()
            {
                DSLanguageTextFieldEventRegister.RegisterValueChangedEvent(LG_Texts_Container);
                DSLanguageTextFieldEventRegister.RegisterFieldFocusInEvent(textField);
                DSLanguageTextFieldEventRegister.RegisterFieldFocusOutEvent(LG_Texts_Container);
            }

            void UpdatePlaceHolderText()
            {
                // Save the placeholder texts to Container.
                LG_Texts_Container.PlaceholderText = placeholderText;

                // Update text field's placeholder. 
                DSTextFieldUtility.ShowEmptyStyle(LG_Texts_Container);
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
        /// <param name="USS01">The first style for the field to use when it appeared on the editor window.</param>
        /// <returns>A new object field UIElement which connected to the language audio clip container.</returns>
        public static ObjectField GetNewLanguageField_AudioClip(LanguageAudioClipContainer LG_AudioClip_Container, string USS01 = "")
        {
            ObjectField objectField;

            Create_LG_AudioClips();

            CreateObjectField();

            ConnectFieldToContainer();

            SetupContainerField();

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

            void SetupContainerField()
            {
                LG_AudioClip_Container.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSLanguageAudioClipFieldEventRegister.RegisterValueChangedEvent(LG_AudioClip_Container);
                DSLanguageAudioClipFieldEventRegister.RegisterFieldFocusInEvent(objectField);
                DSLanguageAudioClipFieldEventRegister.RegisterFieldFocusOutEvent(objectField);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }
    }
}