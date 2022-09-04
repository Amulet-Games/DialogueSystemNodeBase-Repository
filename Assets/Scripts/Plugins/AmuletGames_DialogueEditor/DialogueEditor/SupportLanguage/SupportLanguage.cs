using System;

namespace AG
{
    public static class SupportLanguage
    {
        /// <summary>
        /// The current language type of the custom graph editor.
        /// </summary>
        public static G_LanguageType SelectedLanguage = G_LanguageType.English;


        /// <summary>
        /// The array of languages types supported in the dialogue system.
        /// </summary>
        static G_LanguageType[] supportLanguageTypes;
        public static G_LanguageType[] SupportLanguageTypes => supportLanguageTypes;


        /// <summary>
        /// The number of supported languages in the dialogue system.
        /// </summary>
        static int supportLanguageLength;
        public static int SupportLanguageLength => supportLanguageLength;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, used to initialize internal fields.
        /// </summary>
        public static void Setup()
        {
            supportLanguageTypes = (G_LanguageType[])Enum.GetValues(typeof(G_LanguageType));
            supportLanguageLength = supportLanguageTypes.Length;
        }


        // ----------------------------- Retrieve Language String Services -----------------------------
        /// <summary>
        /// Retrieve the string suffix of current selected language type.
        /// </summary>
        /// <returns>The string suffix of current selected language type.</returns>
        public static string GetLanguageSuffix()
        {
            return SelectedLanguage switch
            {
                G_LanguageType.English => " (Eng)",
                G_LanguageType.German => " (Ger)",
                G_LanguageType.Danish => " (Dan)",
                G_LanguageType.Spanish => " (Span)",
                G_LanguageType.Japanese => " (Jp)",
                G_LanguageType.Latin => " (Lat)",
                _ => " (Eng)",
            };
        }


        /// <summary>
        /// Retrieve the string label of current selected language type.
        /// </summary>
        /// <returns>The string label of current selected language type.</returns>
        public static string GetLanguageLabel()
        {
            return SelectedLanguage switch
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
    }
}