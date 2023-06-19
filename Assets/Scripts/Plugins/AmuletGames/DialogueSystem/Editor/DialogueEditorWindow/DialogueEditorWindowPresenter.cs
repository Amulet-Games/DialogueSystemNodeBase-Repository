using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueEditorWindowPresenter
    {
        /// <summary>
        /// Method for creating a new dialogue editor window.
        /// </summary>
        public static DialogueEditorWindow CreateWindow()
        {
            DialogueEditorWindow window;

            CreateWindow();

            SetupDetail();

            CenterToMainWindow();

            return window;

            void CreateWindow()
            {
                window = EditorWindow.CreateWindow<DialogueEditorWindow>();
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