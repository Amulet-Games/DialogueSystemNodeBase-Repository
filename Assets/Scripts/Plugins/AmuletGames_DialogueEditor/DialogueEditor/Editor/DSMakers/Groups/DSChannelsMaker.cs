using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSChannelsMaker
    {
        /// <summary>
        /// Returns a new entry remove button.
        /// </summary>
        /// <param name="EntryRemovedAction">The action to invoke when the remove button is pressed.</param>
        /// <returns>Button that is use to remove the entry that it's connecting to.</returns>
        public static Button GetNewEntryRemoveButton(Action EntryRemovedAction)
            =>
            DSButtonsMaker.GetNewButton
            (
                DSAssetsConfig.RemoveEntryButtonIconImage,
                EntryRemovedAction,
                DSStylesConfig.Channel_Option_RemoveEntry_Button
            );
    }
}