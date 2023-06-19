using UnityEngine;

namespace AG.DS
{
    public class NodeCreateRequestWindowPresenter
    {
        /// <summary>
        /// Method for creating a new node create request window.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <returns>A new node create request window.</returns>
        public static NodeCreateRequestWindow CreateWindow
        (
            GraphViewer graphViewer,
            NodeCreateDetails details,
            DialogueEditorWindow dsWindow
        )
        {
            var window = ScriptableObject.CreateInstance<NodeCreateRequestWindow>();

            window.Setup(graphViewer, details, dsWindow);
            window.IsUpdateScreenMousePosition = true;

            return window;
        }
    }
}