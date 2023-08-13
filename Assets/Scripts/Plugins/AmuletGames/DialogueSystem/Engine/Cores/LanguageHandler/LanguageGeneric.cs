using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageGeneric<T>
    {
        /// <summary>
        /// The property of the serializable value of the component.
        /// </summary>
        public SerializableDictionary<LanguageType, T> ValueByLanguageType
        {
            get
            {
                return m_value;
            }
            private set
            {
                if (value == null || value == default)
                {
                    for (int i = 0; i < LanguageProvider.SupportTypesCount; i++)
                        m_value[LanguageProvider.SupportTypes[i]] = default;
                }
                else
                {
                    for (int i = 0; i < LanguageProvider.SupportTypesCount; i++)
                        m_value[LanguageProvider.SupportTypes[i]] = value[LanguageProvider.SupportTypes[i]];
                }
            }
        }


        /// <summary>
        /// A serializable value of the component.
        /// </summary>
        [SerializeField] SerializableDictionary<LanguageType, T> m_value;


        /// <summary>
        /// Constructor of the language generic component class. 
        /// </summary>
        public LanguageGeneric()
        {
            // Init dictionary
            {
                m_value = new();
                ValueByLanguageType = default;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the component values.
        /// </summary>
        /// <param name="value">The language generic component to set for.</param>
        public void Save(LanguageGeneric<T> value)
        {
            value.ValueByLanguageType = ValueByLanguageType;
        }


        /// <summary>
        /// Load the component values.
        /// </summary>
        /// <param name="value">The language generic component to set for.</param>
        public void Load(LanguageGeneric<T> value)
        {
            ValueByLanguageType = value.ValueByLanguageType;
        }
    }
}