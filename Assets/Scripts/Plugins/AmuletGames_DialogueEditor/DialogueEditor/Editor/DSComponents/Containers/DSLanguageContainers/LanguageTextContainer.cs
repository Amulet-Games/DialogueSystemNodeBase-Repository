using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class LanguageTextContainer : TextContainerBase
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public List<LanguageGenerics<string>> Value = new List<LanguageGenerics<string>>();


        /// <summary>
        /// Overwrite the generics content of each language with the datas that from another container,
        /// and update the field with the current language's content to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(LanguageTextContainer source)
        {
            // Foreach language of Texts that 'source' container contains.
            for (int i = 0; i < source.Value.Count; i++)
            {
                // Foreach language of Texts that 'this' container contains.
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
                            TextField.SetValueWithoutNotify(Value[j].GenericsContent);
                        }
                        break;
                    }
                }
            }

            // If field's value is null, add it to empty style class.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }


        /// <summary>
        /// Create a new Language Generics foreach language from the source container,
        /// and add it to the list of this container.
        /// </summary>
        /// <param name="source">Target container to save toward.</param>
        public void SaveContainerValue(LanguageTextContainer source)
        {
            // Loop through all the LGs that we have in the source container,
            // Clone a new LG that based on the current LG we looping through,
            // and add it to this new LG container.

            for (int i = 0; i < source.Value.Count; i++)
            {
                LanguageGenerics<string> newLG = new LanguageGenerics<string>()
                {
                    LanguageType = source.Value[i].LanguageType,
                    GenericsContent = source.Value[i].GenericsContent
                };

                Value.Add(newLG);
            }
        }


        /// <summary>
        /// Reload the field's value(string) to the one that matchs the current selected language in editor,
        /// </summary>
        public void ReloadLanguage()
        {
            // Find the string that it's language matches the one that we want to change to.
            string matchedLanguageText = Value
               .Find(String_LG => String_LG.LanguageType == DSLanguagesConfig.SelectedLanguage)
               .GenericsContent;

            // Register a new value change callback to ensure that,
            // any new value given for this field will update to the correct language generics.
            TextField.RegisterValueChangedCallback(value =>
            {
                matchedLanguageText = value.newValue;
            });

            // Set field's value without invoking field's value change event.
            TextField.SetValueWithoutNotify(matchedLanguageText);

            // If field's value is null, add it to empty style class.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }
    }
}
