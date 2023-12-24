using System;

namespace AG.DS
{
    public static class FlagElementExtensions
    {
        /// <summary>
        /// Add the flag element to the first element style class.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="flagElement">Extension flag element.</param>
        public static void ShowFirstElementStyle<TEnum>
        (
            this FlagElement<TEnum> flagElement
        )
            where TEnum : struct, Enum
        {
            flagElement.AddToClassList(StyleConfig.FlagElement_First);
        }


        /// <summary>
        /// Add the flag element to the last element style class.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="flagElement">Extension flag element.</param>
        public static void ShowLastElementStyle<TEnum>
        (
            this FlagElement<TEnum> flagElement
        )
            where TEnum : struct, Enum
        {
            flagElement.AddToClassList(StyleConfig.FlagElement_Last);
        }
    }
}