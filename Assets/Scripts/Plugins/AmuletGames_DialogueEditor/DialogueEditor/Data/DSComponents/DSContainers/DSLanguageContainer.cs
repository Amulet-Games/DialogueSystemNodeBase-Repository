using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class LanguageTextContainer : TextContainerBase
    {
        public List<LanguageGenerics<string>> Value = new List<LanguageGenerics<string>>();

#if UNITY_EDITOR
        /// <summary>
        /// Overwrite the generics content of each language with the datas that from another container,
        /// and update the field with the current language's content to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(LanguageTextContainer source)
        {
            int matchedValueIndex = 0;

            // Foreach language of Texts that 'source' container contains.
            for (int i = 0; i < source.Value.Count; i++)
            {
                // Foreach language of Texts that 'this' container contains.
                for (matchedValueIndex = 0; matchedValueIndex < Value.Count; matchedValueIndex++)
                {
                    // If we found a language from 'this' container,
                    // actually matches the language we're looping through from the source. 
                    if (Value[matchedValueIndex].languageType == source.Value[i].languageType)
                    {
                        // Overwrite the value
                        Value[matchedValueIndex].genericsContent = source.Value[i].genericsContent;
                        break;
                    }
                }
            }

            // Set field's value without invoking field's value change event.
            TextField.SetValueWithoutNotify(Value[matchedValueIndex].genericsContent);

            // Set fields value to placeholder text if the field is empty.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }

        /// <summary>
        /// Create a new Language Generics foreach language,
        /// and add it to the container that we want to save to.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(LanguageTextContainer saveToContainer)
        {
            // Loop through all the LGs that we have in Value on this container,
            // Clone a new LG that based on the current LG we looping through,
            // Add this new LG to the container we are saving to.

            for (int i = 0; i < Value.Count; i++)
            {
                LanguageGenerics<string> newLG = new LanguageGenerics<string>()
                {
                    languageType = Value[i].languageType,
                    genericsContent = Value[i].genericsContent
                };

                saveToContainer.Value.Add(newLG);
            }
        }

        /// <summary>
        /// Reload the field's value(string) to the one that matchs the current selected language in editor,
        /// </summary>
        public void ReloadLanguage()
        {
            // Find the string that it's language matches the one that we want to change to.
            string matchedLanguageText = Value.Find(String_LG => String_LG.languageType == SupportLanguage.selectedLanguage).genericsContent;

            // Register a new value change callback to ensure that,
            // any new value given for this field will update to the correct language generics.
            TextField.RegisterValueChangedCallback(value =>
            {
                matchedLanguageText = value.newValue;
            });

            // Set field's value without invoking field's value change event.
            TextField.SetValueWithoutNotify(matchedLanguageText);

            // Set fields value to placeholder text if the field is empty.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }
#endif 
    }

    [Serializable]
    public class LanguageAudioClipContainer
    {
        public List<LanguageGenerics<AudioClip>> Value = new List<LanguageGenerics<AudioClip>>();

#if UNITY_EDITOR
        /// <summary>
        /// Visual element
        /// </summary>
        public ObjectField ObjectField;

        /// <summary>
        /// Setup the object field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            ObjectField.objectType = typeof(AudioClip);
            ObjectField.allowSceneObjects = false;

            // Make sure the field's audio clip matches the current editor language's audio clip.
            ObjectField.value = Value.Find(AudioClip_LG => AudioClip_LG.languageType == SupportLanguage.selectedLanguage).genericsContent;

            // Update field's empty style
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }

        /// <summary>
        /// Overwrite the generics content of each language with the datas that from another container,
        /// and update the field with the current language's content to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(LanguageAudioClipContainer source)
        {
            int matchedValueIndex = 0;

            // Foreach language of AudioClips that 'source' container contains.
            for (int i = 0; i < source.Value.Count; i++)
            {
                // Foreach language of AudioClips that 'this' container contains.
                for (matchedValueIndex = 0; matchedValueIndex < Value.Count; matchedValueIndex++)
                {
                    // If we found a language from 'this' container,
                    // actually matches the language we're looping through from the source. 
                    if (Value[matchedValueIndex].languageType == source.Value[i].languageType)
                    {
                        // Overwrite the value
                        Value[matchedValueIndex].genericsContent = source.Value[i].genericsContent;
                        break;
                    }
                }
            }

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(Value[matchedValueIndex].genericsContent);

            // USS
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }

        /// <summary>
        /// Create a new Language Generics foreach language,
        /// and add it to the container that we want to save to.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(LanguageAudioClipContainer saveToContainer)
        {
            // Loop through all the LGs that we have in Value on this container,
            // Clone a new LG that based on the current LG we looping through,
            // Add this new LG to the container we are saving to.

            for (int i = 0; i < Value.Count; i++)
            {
                LanguageGenerics<AudioClip> newLG = new LanguageGenerics<AudioClip>()
                {
                    languageType = Value[i].languageType,
                    genericsContent = Value[i].genericsContent
                };

                saveToContainer.Value.Add(newLG);
            }
        }

        /// <summary>
        /// Reload the field's value(audio clip) to the one that matchs the current selected language in editor.
        /// </summary>
        public void ReloadLanguage()
        {
            // Find the audio clip that it's language matches the one that we want to change to. 
            AudioClip matchedLanguageAudioClip = Value.Find(AudioClip_LG => AudioClip_LG.languageType == SupportLanguage.selectedLanguage).genericsContent;

            // Register a new value change callback to ensure that,
            // any new value given for this field will update to the correct language generics.
            ObjectField.RegisterValueChangedCallback(value =>
            {
                matchedLanguageAudioClip = value.newValue as AudioClip;
            });

            ObjectField.SetValueWithoutNotify(matchedLanguageAudioClip);
        }
#endif
    }
}
