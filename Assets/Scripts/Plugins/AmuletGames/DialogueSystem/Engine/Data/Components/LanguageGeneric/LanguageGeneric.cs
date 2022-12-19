using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageGeneric<T>
    {
        /// <summary>
        /// A serializable dictionary that takes language index as TKey and typed object as TValue.
        /// </summary>
        [SerializeField] public SerializableDictionary<G_LanguageType, T> ValueByLanguageType;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language generic component class. 
        /// </summary>
        public LanguageGeneric() =>
            ValueByLanguageType = new SerializableDictionary<G_LanguageType, T>();
    }
}