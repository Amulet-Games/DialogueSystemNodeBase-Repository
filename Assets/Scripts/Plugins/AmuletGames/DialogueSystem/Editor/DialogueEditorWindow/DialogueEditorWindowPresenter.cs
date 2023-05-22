using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueEditorWindowPresenter
    {
        /// <summary>
        /// Method for creating a new dialogue editor window.
        /// </summary>
        /// <param name="dsData">The dialogue system data to set for.</param>
        /// <param name="projectManager">The project manager to set for.</param>
        public static DialogueEditorWindow CreateWindow
        (
            DialogueSystemData dsData,
            ProjectManager projectManager
        )
        {
            DialogueEditorWindow window;

            CreateWindow();

            SetupDetail();

            CenterToMainWindow();

            return window;

            void CreateWindow()
            {
                window = (DialogueEditorWindow)EditorWindow.GetWindow(typeof(DialogueEditorWindow));
                window.SkipOnEnable = true;
            }

            void SetupDetail()
            {
                window.DsData = dsData;
                window.ProjectManager = projectManager;
                window.minSize = new Vector2(
                    x: dsData.WindowMinSize.x,
                    y: dsData.WindowMinSize.y);
            }

            void CenterToMainWindow()
            {
                var mainWindowPosition = EditorGUIUtility.GetMainWindowPosition();
                
                window.CenterToMainWindow(
                    customWidth: mainWindowPosition.width * dsData.WindowStartSizeScreenRatio.x,
                    customHeight: mainWindowPosition.height * dsData.WindowStartSizeScreenRatio.y);
            }
        }
    }
}