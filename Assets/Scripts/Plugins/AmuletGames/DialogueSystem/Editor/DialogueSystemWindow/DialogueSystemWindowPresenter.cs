using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueSystemWindowPresenter
    {
        /// <summary>
        /// Method for creating a new dialogue system window.
        /// </summary>
        public static DialogueSystemWindow CreateWindow()
        {
            DialogueSystemWindow window;

            CreateWindow();

            SetupDetail();

            CenterToMainWindow();

            return window;

            void CreateWindow()
            {
                window = EditorWindow.CreateWindow<DialogueSystemWindow>();
            }

            void SetupDetail()
            {
                window.minSize = new Vector2
                (
                    x: WindowConfig.WindowMinSize.x,
                    y: WindowConfig.WindowMinSize.y
                );
            }

            void CenterToMainWindow()
            {
                var mainWindowPosition = EditorGUIUtility.GetMainWindowPosition();
                
                window.CenterToMainWindow(
                    customWidth: mainWindowPosition.width * WindowConfig.WindowStartSizeScreenRatio.x,
                    customHeight: mainWindowPosition.height * WindowConfig.WindowStartSizeScreenRatio.y);
            }
        }
    }
}