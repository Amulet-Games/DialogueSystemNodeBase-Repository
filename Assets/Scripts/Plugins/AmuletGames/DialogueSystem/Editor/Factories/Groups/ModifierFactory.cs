using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ModifierFactory
    {
        /// <summary>
        /// Factory method for creating a new remove modifier button UIElement.
        /// </summary>
        /// <param name="action">The action to invoke when the button is pressed.</param>
        /// <param name="buttonUSS01">The first USS style to set for.</param>
        /// <returns>A new remove modifier button UIElement.</returns>
        public static Button GetNewModifierRemoveButton
        (
            Action action,
            string buttonUSS01
        )
        {
            return ButtonFactory.GetNewButton
            (
                isAlert: true,
                btnSprite: AssetsConfig.RemoveModifierButtonIconSprite,
                btnPressedAction: action,
                buttonUSS01: buttonUSS01
            );
        }
    }
}