using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class HotkeyManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static HotkeyManager Instance { get; private set; } = null;


        /// <summary>
        /// The key that user will often need to press and hold first before pressing other
        /// <br>action keys to perform the desired action.</br>
        /// </summary>
        public KeyCode SupportKey = KeyCode.LeftShift;


        /// <summary>
        /// The action key for saving the dialogue editor window.
        /// <para>Press and hold the support key before pressing this key to perform the desired action.</para>
        /// </summary>
        public KeyCode SaveKey = KeyCode.F12;


        /// <summary>
        /// The action key for loading the dialogue editor window.
        /// <para>Press and hold the support key before pressing this key to perform the desired action.</para>
        /// </summary>
        public KeyCode LoadKey = KeyCode.F11;


        /// <summary>
        /// Initialize for the class.
        /// </summary>
        public static void Initialize()
        {
            Instance ??= new();
        }


        // ----------------------------- Retrieve Key Down -----------------------------
        /// <summary>
        /// Returns true if the support key is being held down at the moment. 
        /// </summary>
        /// <param name="evt">The processing KeyDownEvent.</param>
        /// <returns>True if the support key is being held down at the moment.</returns>
        public bool IsSupportKeyDown(KeyDownEvent evt)
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