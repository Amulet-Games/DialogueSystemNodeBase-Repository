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
            switch (SelectedLanguage)
            {
                case G_LanguageType.English:
                    return " (Eng)";
                case G_LanguageType.German:
                    return " (Ger)";
                case G_LanguageType.Danish:
                    return " (Dan)";
                case G_LanguageType.Spanish:
                    return " (Span)";
                case G_LanguageType.Japanese:
                    return " (Jp)";
                case G_LanguageType.Latin:
                    return " (Lat)";
                default:
                    return " (Eng)";
            }
        }


        /// <summary>
        /// Retrieve the string label of current selected language type.
        /// </summary>
        /// <returns>The string label of current selected language type.</returns>
        public static string GetLanguageLabel()
        {
            switch (SelectedLanguage)
            {
                case G_LanguageType.English:
                    return "ENG";
                case G_LanguageType.German:
                    return "GER";
                case G_LanguageType.Danish:
                    return "DAN";
                case G_LanguageType.Spanish:
                    return "SPAN";
                case G_LanguageType.Japanese:
                    return "JPN";
                case G_LanguageType.Latin:
                    return "LATIN";
                default:
                    return " (Eng)";
            }
        }
    }
}