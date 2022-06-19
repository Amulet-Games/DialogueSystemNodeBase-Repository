using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    public static class SupportLanguage
    {
        public static G_LanguageType selectedLanguage = G_LanguageType.English;

        static G_LanguageType[] supportLanguageTypes;
        public static G_LanguageType[] SupportLanguageTypes { get { return supportLanguageTypes; } }

        static int supportLanguageLength;
        public static int SupportLanguageLength { get { return supportLanguageLength; } }

        /// Setup.
        public static void Setup()
        {
            supportLanguageTypes = (G_LanguageType[])Enum.GetValues(typeof(G_LanguageType));
            supportLanguageLength = supportLanguageTypes.Length;
        }

        public static string GetLanguageSuffix()
        {
            switch (selectedLanguage)
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
    }
}