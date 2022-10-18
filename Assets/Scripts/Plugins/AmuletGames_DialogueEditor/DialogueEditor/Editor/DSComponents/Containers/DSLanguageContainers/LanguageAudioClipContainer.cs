using System.Collections.Generic;
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class LanguageAudioClipContainer
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public List<LanguageGenerics<AudioClip>> Value = new List<LanguageGenerics<AudioClip>>();


        /// <summary>
        /// Visual element
        /// </summary>
        public ObjectField ObjectField;


        /// <summary>
        /// Overwrite the generics content of each language with the datas that from another container,
        /// and update the field with the current language's content to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(LanguageAudioClipContainer source)
        {
            // Foreach language of AudioClips that 'source' container contains.
            for (int i = 0; i < source.Value.Count; i++)
            {
                // Foreach language of AudioClips that 'this' container contains.
                for (int j = 0; j < Value.Count; j++)
                {
                    // If we found a language from 'this' container,
                    // actually matches the language we're looping through from the source. 
                    if (Value[j].LanguageType == source.Value[i].LanguageType)
                    {
                        // Overwrite the value
                        Value[j].GenericsContent = source.Value[i].GenericsContent;

                        // Set field's value without invoking field's value change event.
                        if (Value[j].LanguageType == DSLanguagesConfig.SelectedLanguage)
                        {
                            ObjectField.SetValueWithoutNotify(Value[j].GenericsContent);
                        }
                        break;
                    }
                }
            }
            
            // If field's value is null, add it to empty style class.
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }


        /// <summary>
        /// Create a new Language Generics foreach language from the source container,
        /// and add it to the list of this container.
        /// </summary>
        /// <param name="source">Target container to load from.</param>
        public void SaveContainerValue(LanguageAudioClipContainer source)
        {
            // Loop through all the LGs that we have in the source container,
            // Clone a new LG that based on the current LG we looping through,
            // and add it to this new LG container.

            for (int i = 0; i < source.Value.Count; i++)
            {
                LanguageGenerics<AudioClip> newLG = new LanguageGenerics<AudioClip>()
                {
                    LanguageType = source.Value[i].LanguageType,
                    GenericsContent = source.Value[i].GenericsContent
                };

                Value.Add(newLG);
            }
        }


        /// <summary>
        /// Reload the field's value(audio clip) to the one that matchs the current selected language in editor.
        /// </summary>
        public void ReloadLanguage()
        {
            // Find the audio clip that it's language matches the one that we want to change to. 
            AudioClip matchedLanguageAudioClip = Value.Find(AudioClip_LG => AudioClip_LG.LanguageType == DSLanguagesConfig.SelectedLanguage).GenericsContent;

            // Register a new value change callback to ensure that,
            // any new value given for this field will update to the correct language generics.
            ObjectField.RegisterValueChangedCallback(value =>
            {
                matchedLanguageAudioClip = value.newValue as AudioClip;
            });

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(matchedLanguageAudioClip);

            // If field's value is null, add it to empty style class.
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }
    }
}