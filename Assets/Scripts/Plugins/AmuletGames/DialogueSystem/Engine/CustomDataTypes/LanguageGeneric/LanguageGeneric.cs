using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageGeneric<T>
    {
        /// <summary>
        /// A serializable dictionary that takes language type as TKey and object as TValue.
        /// </summary>
        [SerializeField] public SerializableDictionary<LanguageType, T> ValueByLanguageType;


        /// <summary>
        /// The property of the internal stored value that matches the current dialogue editor window's language.
        /// </summary>
        public T CurrentLanguageValue
        {
            get => ValueByLanguageType[LanguageManager.Instance.CurrentLanguage];
            set => ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = value;
        }


        /// <summary>
        /// Constructor of the language generic component class. 
        /// </summary>
        public LanguageGeneric()
        {
            // new dictionary
            {
                ValueByLanguageType = new();
            }

            // init dictionary
            {
                var languageManager = LanguageManager.Instance;
                for (int i = 0; i < languageManager.SupportLanguageLength; i++)
                {
                    ValueByLanguageType[languageManager.SupportLanguageTypes[i]] = default;
                }
            }
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value for each of the language type stored within the internal dictionary.
        /// </summary>
        /// <param name="value"></param>
        public void SetValues(LanguageGeneric<T> value)
        {
            var languageManager = LanguageManager.Instance;
            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                    value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }
        }
    }
}