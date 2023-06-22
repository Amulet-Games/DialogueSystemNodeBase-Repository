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
        public G_LanguageType SelectedLanguage = G_LanguageType.English;


        /// <summary>
        /// The array of languages types supported in the dialogue system.
        /// </summary>
        public G_LanguageType[] SupportLanguageTypes { get; private set; }


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
            Instance.SupportLanguageTypes = (G_LanguageType[])Enum.GetValues(typeof(G_LanguageType));
            Instance.SupportLanguageLength = Instance.SupportLanguageTypes.Length;
        }


        // ----------------------------- Retrieve Language String -----------------------------
        /// <summary>
        /// Retrieve the suffix text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The suffix text of the given language type.</returns>
        public string GetSuffix(G_LanguageType type)
        {
            return type switch
            {
                G_LanguageType.English => " (Eng)",
                G_LanguageType.German => " (Ger)",
                G_LanguageType.Danish => " (Dan)",
                G_LanguageType.Spanish => " (Span)",
                G_LanguageType.Japanese => " (Jpn)",
                G_LanguageType.Latin => " (Lat)",
                _ => " (Eng)",
            };
        }


        /// <summary>
        /// Retrieve the abbreviated text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The abbreviated text of the given language type.</returns>
        public string GetShort(G_LanguageType type)
        {
            return type switch
            {
                G_LanguageType.English => "ENG",
                G_LanguageType.German => "GER",
                G_LanguageType.Danish => "DAN",
                G_LanguageType.Spanish => "SPAN",
                G_LanguageType.Japanese => "JPN",
                G_LanguageType.Latin => "LATIN",
                _ => "ENG",
            };
        }


        /// <summary>
        /// Retrieve the full text of the given language type.
        /// </summary>
        /// <param name="type">The targeting language type.</param>
        /// <returns>The full text of the given language type.</returns>
        public string GetFull(G_LanguageType type)
        {
            return type switch
            {
                G_LanguageType.English => "English",
                G_LanguageType.German => "German",
                G_LanguageType.Danish => "Danish",
                G_LanguageType.Spanish => "Spanish",
                G_LanguageType.Japanese => "Japanese",
                G_LanguageType.Latin => "Latin",
                _ => "ENG",
            };
        }
    }
}