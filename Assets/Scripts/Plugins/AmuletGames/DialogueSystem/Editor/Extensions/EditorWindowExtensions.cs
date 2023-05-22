using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public static class EditorWindowExtensions
    {
        /// <summary>
        /// Place the editor window to the center of the unity editor's main window.
        /// </summary>
        /// <param name="window">Extension editor window.</param>
        /// <param name="customWidth">The custom width to set for.</param>
        /// <param name="customHeight">The custom height to set for.</param>
        public static void CenterToMainWindow(
            this EditorWindow window,
            float customWidth = -1,
            float customHeight = -1
        )
        {
            Rect main = EditorGUIUtility.GetMainWindowPosition();
            Rect pos = window.position;

            float finalWidth = customWidth == -1 ? pos.width : customWidth;
            float finalHeight = customHeight == -1 ? pos.height : customHeight;

            float centerWidth = (main.width - finalWidth) * 0.5f;
            float centerHeight = (main.height - finalHeight) * 0.5f;
            
            const float POS_Y_Offset = 43;

            pos.x = main.x + centerWidth;
            pos.y = main.y + centerHeight - POS_Y_Offset;
            pos.width = finalWidth;
            pos.height = finalHeight;

            window.position = pos;
        }
    }
}