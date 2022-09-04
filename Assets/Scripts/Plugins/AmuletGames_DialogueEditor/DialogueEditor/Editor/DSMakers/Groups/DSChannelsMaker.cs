using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSChannelsMaker
    {
        /// <summary>
        /// Create a new entry remove button.
        /// </summary>
        /// <param name="EntryRemovedAction">The action to invoke when the remove button is pressed.</param>
        /// <returns>Button that is use to remove the entry that it's connecting to.</returns>
        public static Button AddEntryRemoveButton(Action EntryRemovedAction)
        {
            return DSButtonsMaker.GetNewButton(DSAssetsConfig.RemoveEntryButtonIconImage, EntryRemovedAction, DSStylesConfig.Channel_RemoveEntry_Button);
        }
    }
}