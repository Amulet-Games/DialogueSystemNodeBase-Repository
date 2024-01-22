using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueSystemWindowPresenter
    {
        /// <summary>
        /// Create a new dialogue system window.
        /// </summary>
        /// <returns>A new dialogue system window.</returns>
        public static DialogueSystemWindow CreateWindow()
        {
            DialogueSystemWindow window;

            CreateWindow();

            SetupDetails();

            CenterToMainWindow();

            return window;

            void CreateWindow()
            {
                window = EditorWindow.CreateWindow<DialogueSystemWindow>();
            }

            void SetupDetails()
            {
                window.minSize = new Vector2
                (
                    x: DialogueSystemWindowConfig.WindowMinSize.x,
                    y: DialogueSystemWindowConfig.WindowMinSize.y
                );
            }

            void CenterToMainWindow()
            {
                var mainWindowPosition = EditorGUIUtility.GetMainWindowPosition();
                
                window.CenterToMainWindow(
                    customWidth: mainWindowPosition.width * DialogueSystemWindowConfig.WindowStartSizeScreenRatio.x,
                    customHeight: mainWindowPosition.height * DialogueSystemWindowConfig.WindowStartSizeScreenRatio.y);
            }
        }
    }
}