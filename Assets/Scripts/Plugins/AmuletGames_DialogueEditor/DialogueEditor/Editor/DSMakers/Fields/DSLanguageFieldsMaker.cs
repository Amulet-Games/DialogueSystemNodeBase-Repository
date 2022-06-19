using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public static class DSLanguageFieldsMaker
    {
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

                for (int i = 0; i < SupportLanguage.SupportLanguageLength; i++)
                {
                    LanguageGenerics<string> new_LG_Text = new LanguageGenerics<string>();

                    new_LG_Text.languageType = SupportLanguage.SupportLanguageTypes[i];
                    new_LG_Text.genericsContent = "";

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
                    String_LG => String_LG.languageType == SupportLanguage.selectedLanguage
                )
                .genericsContent);
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                LG_Texts_Container.TextField = textField;
            }

            void RegisterFieldEvents()
            {
                DSLanguageTextFieldUtilityEditor.RegisterValueChangedEvent(LG_Texts_Container);
                DSLanguageTextFieldUtilityEditor.RegisterFieldFocusInEvent(textField);
                DSLanguageTextFieldUtilityEditor.RegisterFieldFocusOutEvent(LG_Texts_Container);
            }

            void UpdatePlaceHolderText()
            {
                // Save the placeholder texts to Container.
                LG_Texts_Container.PlaceholderText = placeholderText;

                // Update text field's placeholder. 
                DSTextFieldUtility.ToggleEmptyStyle(LG_Texts_Container);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }

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

                for (int i = 0; i < SupportLanguage.SupportLanguageLength; i++)
                {
                    LanguageGenerics<AudioClip> new_LG_AudioClip = new LanguageGenerics<AudioClip>();

                    new_LG_AudioClip.languageType = SupportLanguage.SupportLanguageTypes[i];
                    new_LG_AudioClip.genericsContent = null;

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
                DSLanguageAudioClipFieldUtilityEditor.RegisterValueChangedEvent(LG_AudioClip_Container);
                DSLanguageAudioClipFieldUtilityEditor.RegisterFieldFocusInEvent(objectField);
                DSLanguageAudioClipFieldUtilityEditor.RegisterFieldFocusOutEvent(objectField);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }
    }
}