using System;

namespace AG.DS
{
    public static class LanguageProvider
    {
        /// <summary>
        /// Is this class has already been setup?
        /// </summary>
        static bool isSetup;


        /// <summary>
        /// The array of language types that are supported in the dialogue system window.
        /// </summary>
        public static LanguageType[] SupportTypes { get; private set; }


        /// <summary>
        /// The supported language type array counter.
        /// </summary>
        public static int SupportTypesCount { get; private set; }


        /// <summary>
        /// Setup for the language provider class.
        /// </summary>
        public static void Setup()
        {
            if (isSetup)
                return;

            SupportTypes = (LanguageType[])Enum.GetValues(typeof(LanguageType));
            SupportTypesCount = SupportTypes.Length;

            isSetup = true;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Retrieve the suffix text of the language type.
        /// </summary>
        /// 
        /// <param name="type">The targeting language type.</param>
        /// 
        /// <returns>The suffix text of the language type.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given language type is invalid to any of the current existing language's type.
        /// </exception>
        public static string GetSuffix(LanguageType type)
            => type switch
            {
                LanguageType.English => " (Eng)",
                LanguageType.German => " (Ger)",
                LanguageType.Danish => " (Dan)",
                LanguageType.Spanish => " (Span)",
                LanguageType.Japanese => " (Jpn)",
                LanguageType.Latin => " (Lat)",

                _ => throw new ArgumentException("Invalid language type: " + type.ToString())
            };


        /// <summary>
        /// Retrieve the abbreviated text of the language type.
        /// </summary>
        /// 
        /// <param name="type">The targeting language type.</param>
        /// 
        /// <returns>The abbreviated text of the language type.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given language type is invalid to any of the current existing language's type.
        /// </exception>
        public static string GetShort(LanguageType type)
            => type switch
            {
                LanguageType.English => "ENG",
                LanguageType.German => "GER",
                LanguageType.Danish => "DAN",
                LanguageType.Spanish => "SPAN",
                LanguageType.Japanese => "JPN",
                LanguageType.Latin => "LATIN",

                _ => throw new ArgumentException("Invalid language type: " + type.ToString())
            };


        /// <summary>
        /// Retrieve the full text of the language type.
        /// </summary>
        /// 
        /// <param name="type">The targeting language type.</param>
        /// 
        /// <returns>The full text of the language type.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given language type is invalid to any of the current existing language's type.
        /// </exception>
        public static string GetFull(LanguageType type)
            => type switch
            {
                LanguageType.English => "English",
                LanguageType.German => "German",
                LanguageType.Danish => "Danish",
                LanguageType.Spanish => "Spanish",
                LanguageType.Japanese => "Japanese",
                LanguageType.Latin => "Latin",

                _ => throw new ArgumentException("Invalid language type: " + type.ToString())
            };


        /// <summary>
        /// Retrieve the language type by try matching the given string to the language full or short text.
        /// </summary>
        /// 
        /// <param name="value">The string to set for.</param>
        /// 
        /// <returns>The matching language type.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given string value is not matched with any of the current existing language full or short text.
        /// </exception>
        public static LanguageType GetType(string value)
            => value switch
            {
                "English" or "ENG" => LanguageType.English,
                "German" or "GER" => LanguageType.English,
                "Danish" or "DAN" => LanguageType.English,
                "Spanish" or "SPAN" => LanguageType.English,
                "Japanese" or "JPN" => LanguageType.English,
                "Latin" or "LATIN" => LanguageType.English,

                _ => throw new ArgumentException("Invalid string value: " + value)
            };
    }
}