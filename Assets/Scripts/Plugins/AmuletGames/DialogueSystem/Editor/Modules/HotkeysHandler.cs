using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class HotkeysHandler
    {
        /// <summary>
        /// The key that user will often need to press and hold first before pressing other
        /// <br>action keys to perform the desired action.</br>
        /// </summary>
        public static KeyCode SupportKey = KeyCode.LeftShift;


        /// <summary>
        /// The action key for saving the dialogue editor window.
        /// <para>Press and hold the support key before pressing this key to perform the desired action.</para>
        /// </summary>
        public static KeyCode SaveKey = KeyCode.F12;


        /// <summary>
        /// The action key for loading the dialogue editor window.
        /// <para>Press and hold the support key before pressing this key to perform the desired action.</para>
        /// </summary>
        public static KeyCode LoadKey = KeyCode.F11;


        /// <summary>
        /// Reference of the dialogue dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Is the action key that the user pressed before released now?
        /// </summary>
        bool isKeyReleased;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the hotkeys catcher module class.
        /// </summary>
        /// <param name="dsWindow">The dialogue editor window module to set for.</param>
        public HotkeysHandler(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// Action that invoked when the user has pressed any hotkeys in a empty space inside the window.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        public void HotkeysDownAction(KeyDownEvent evt)
        {
            // If the hotkey function has executed once but the user hasn't released the key yet.
            if (!isKeyReleased)
                return;

            // If hotkey function is not available at the moment.
            if (!dsWindow.IsHotkeysFunctionAvailable())
                return;

            // If support key is being held down,
            if (IsSupportKeyHeldDown(evt))
            {
                // Saving
                if (evt.keyCode == SaveKey)
                {
                    dsWindow.SaveWindow();
                    isKeyReleased = false;
                }

                // Loading
                if (evt.keyCode == LoadKey)
                {
                    dsWindow.LoadWindow(false);
                    isKeyReleased = false;
                }
            }
        }


        /// <summary>
        /// Action that invoked when the user has released the hotkey that pressed in a empty space inside the window.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        public void HotkeysUpAction(KeyUpEvent evt) => isKeyReleased = true;


        // ----------------------------- Retrieve Key Down -----------------------------
        /// <summary>
        /// Returns true if the support key is held down at the moment. 
        /// </summary>
        /// <param name="evt">The keydown event that's being procossing at the moment.</param>
        /// <returns>True if the support key is held down at the moment.</returns>
        bool IsSupportKeyHeldDown(KeyDownEvent evt)
        {
            return SupportKey switch
            {
                KeyCode.LeftControl => evt.ctrlKey,
                KeyCode.LeftShift => evt.shiftKey,
                KeyCode.LeftAlt => evt.altKey,
                _ => false
            };
        }
    }
}