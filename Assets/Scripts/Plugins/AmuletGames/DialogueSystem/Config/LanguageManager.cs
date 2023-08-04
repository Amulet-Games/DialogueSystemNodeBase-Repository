using System;

namespace AG.DS
{
    public class LanguageManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static LanguageManager Instance { get; private set; } = null;


        /// <summary>
        /// The current language type of the custom graph editor.
        /// </summary>
        public LanguageType CurrentLanguage { get; private set; } = LanguageType.English;


        /// <summary>
        /// The array of languages types supported in the dialogue system.
        /// </summary>
        public LanguageType[] SupportLanguageTypes { get; private set; }


        /// <summary>
        /// The number of supported languages in the dialogue system.
        /// </summary>
        public int SupportLanguageLength { get; private set; }


        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
            Instance.SupportLanguageTypes = (LanguageType[])Enum.GetValues(typeof(LanguageType));
            Instance.SupportLanguageLength = Instance.SupportLanguageTypes.Length;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the current language.
        /// </summary>
        /// <param name="value">The new value to set for.</param>
        public void SetCurrentLanguage(LanguageType value) => CurrentLanguage = value;


        /// <summary>
        /// Retrieve the suffix text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The suffix text of the given language type.</returns>
        public string GetSuffix(LanguageType type)
        {
            return type switch
            {
                LanguageType.English => " (Eng)",
                LanguageType.German => " (Ger)",
                LanguageType.Danish => " (Dan)",
                LanguageType.Spanish => " (Span)",
                LanguageType.Japanese => " (Jpn)",
                LanguageType.Latin => " (Lat)",
                _ => " (Eng)",
            };
        }


        /// <summary>
        /// Retrieve the abbreviated text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The abbreviated text of the given language type.</returns>
        public string GetShort(LanguageType type)
        {
            return type switch
            {
                LanguageType.English => "ENG",
                LanguageType.German => "GER",
                LanguageType.Danish => "DAN",
                LanguageType.Spanish => "SPAN",
                LanguageType.Japanese => "JPN",
                LanguageType.Latin => "LATIN",
                _ => "ENG",
            };
        }


        /// <summary>
        /// Retrieve the full text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The full text of the given language type.</returns>
        public string GetFull(LanguageType type)
        {
            return type switch
            {
                LanguageType.English => "English",
                LanguageType.German => "German",
                LanguageType.Danish => "Danish",
                LanguageType.Spanish => "Spanish",
                LanguageType.Japanese => "Japanese",
                LanguageType.Latin => "Latin",
                _ => "ENG",
            };
        }
    }
}