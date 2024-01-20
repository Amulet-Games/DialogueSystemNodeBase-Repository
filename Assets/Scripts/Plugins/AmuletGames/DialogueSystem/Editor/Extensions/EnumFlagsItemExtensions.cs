using System;

namespace AG.DS
{
    public static class EnumFlagsItemExtensions
    {
        /// <summary>
        /// Add the enum flags item to the first item style class.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="enumFlagsItem">Extension enum flags item.</param>
        public static void ShowFirstStyle<TEnum>(this EnumFlagsItem<TEnum> enumFlagsItem)
            where TEnum : struct, Enum
        {
            enumFlagsItem.AddToClassList(StyleConfig.EnumFlagsItem_First);
        }


        /// <summary>
        /// Add the enum flags item to the last item style class.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="enumFlagsItem">Extension enum flags item.</param>
        public static void ShowLastStyle<TEnum>(this EnumFlagsItem<TEnum> enumFlagsItem)
            where TEnum : struct, Enum
        {
            enumFlagsItem.AddToClassList(StyleConfig.EnumFlagsItem_Last);
        }
    }
}