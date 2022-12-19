using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ChannelFactory
    {
        /// <summary>
        /// Factory method for creating a new remove channel button UIElement.
        /// </summary>
        /// <param name="action">The action to invoke when the button is pressed.</param>
        /// <returns>A new remove channel button UIElement.</returns>
        public static Button CreateRemoveChannelButton(Action action) =>
            ButtonFactory.GetNewButton
            (
                isAlert: true,
                btnSprite: AssetsConfig.RemoveChannelButtonIconSprite,
                btnPressedAction: action,
                buttonUSS01: StylesConfig.Channel_Option_Output_RemoveChannel_Button
            );
    }
}