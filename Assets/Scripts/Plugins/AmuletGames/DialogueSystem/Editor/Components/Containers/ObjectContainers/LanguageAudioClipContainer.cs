using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageAudioClipContainer : IReversible
    {
        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> LanguageGeneric;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language audio clip container component class.
        /// </summary>
        public LanguageAudioClipContainer()
        {
            LanguageGeneric = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the container values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveContainerValue(LanguageGeneric<AudioClip> data)
        {
            for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
            {
                // Save the TKey and TValue to the data.
                data.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] =
                    LanguageGeneric.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]];
            }
        }


        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(LanguageGeneric<AudioClip> data)
        {
            for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
            {
                // Load the TKey and TValue from the data.
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] =
                    data.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]];
            }

            ObjectField.SetValueWithoutNotify
            (
                // Load field.
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage]
            );

            // Toggle empty style.
            ObjectFieldHelper.ToggleEmptyStyle(ObjectField);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            AudioClip selectedLanguageValue =
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage];

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: selectedLanguageValue != null

                        // Serialize value's asset path.
                        ? AssetDatabase.GetAssetPath(selectedLanguageValue)

                        // Serialize empty string.
                        : ""
            );

            memoryStream.Close();
            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                // Load the stashed asset's value path and retrieve it from asset data base.
                var reverseValue = (AudioClip)AssetDatabase.LoadAssetAtPath
                (
                    assetPath: (string)new BinaryFormatter().Deserialize(new MemoryStream(array)),
                    type: typeof(AudioClip)
                );

                if (reverseValue != null)
                {
                    // Load value.
                    LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage] = reverseValue;

                    // Load field.
                    ObjectField.SetValueWithoutNotify(reverseValue);

                    // Toggle empty style.
                    ObjectFieldHelper.ToggleEmptyStyle(ObjectField);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }


        // ----------------------------- Update Language Field Services -----------------------------
        /// <summary>
        /// Update the field's value base on the current editor's language.
        /// </summary>
        public void UpdateLanguageField()
        {
            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify
            (
                // Set the new value base on the language that the editor has changed to.
                newValue: LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage]
            );

            // Toggle the field empty style.
            ObjectFieldHelper.ToggleEmptyStyle(ObjectField);
        }
    }
}