using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ButtonCallbacks
    {
        /// <summary>
        /// Register new click actions to the given button element.
        /// <para></para>
        /// When the click actions are invoked, <see cref="WindowChangedEvent"/> will be invoked along side.
        /// <br>If you don't want <see cref="WindowChangedEvent"/> to be invoked, Use <see cref="RegisterClickEventNonAlert"/> instead.</br>
        /// </summary>
        /// <param name="button">The button to assign the click actions to.</param>
        /// <param name="clickAction">The click action itself.</param>
        public static void RegisterClickEvent
        (
            Button button,
            Action clickAction
        )
        {
            button.RegisterCallback<ClickEvent>(callback =>
            {
                clickAction.Invoke();

                WindowChangedEvent.Invoke();
            });
        }


        /// <summary>
        /// Register new click actions to the given button element.
        /// <para></para>
        /// <see cref="WindowChangedEvent"/> will not be invoked along side with the click action.
        /// <br>If you want <see cref="WindowChangedEvent"/> to be invoked, Use <see cref="RegisterClickEvent"/> instead.</br>
        /// </summary>
        /// <param name="button">The button to assign the click actions to.</param>
        /// <param name="clickAction">The click action itself.</param>
        public static void RegisterClickEventNonAlert
        (
            Button button,
            Action clickAction
        )
        {
            button.RegisterCallback<ClickEvent>(callback =>
            {
                clickAction.Invoke();
            });
        }
    }
}