using UnityEngine;

namespace AG.DS
{
    public static class WindowConfig
    {
        /// <summary>
        /// The minimum size of the dialogue editor window when it's floating or modal.
        /// </summary>
        public static Vector2 WindowMinSize = new(x: 200, y: 200);


        /// <summary>
        /// The size of the dialogue editor window when it's first opened.
        /// </summary>
        public static Vector2 WindowStartSizeScreenRatio = new(x: 0.7f, y: 0.7f);
    }
}