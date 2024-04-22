using UnityEngine;

namespace AG.DS
{
    public static class GUIExtensions
    {
        /// <summary>
        /// Convert a position from GUI position to screen space.
        /// </summary>
        /// <param name="position">The position to set for.</param>
        /// <returns>The screen space position of the giving position.</returns>
        public static Vector2 GetScreenSpacePosition(this Vector2 position)
        {
            return GUIUtility.GUIToScreenPoint(guiPoint: position);
        }


        /// <summary>
        /// Convert a rect from GUI position to screen space.
        /// </summary>
        /// <param name="rect">The rect to set for.</param>
        /// <returns>The screen space rect of the giving rect.</returns>
        public static Rect GetScreenSpacePosition(this Rect rect)
        {
            return GUIUtility.GUIToScreenRect(guiRect: rect);
        }
    }
}