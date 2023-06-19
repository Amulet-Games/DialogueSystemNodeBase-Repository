using UnityEngine;

namespace AG.DS
{
    public class NodeCreateConnectorWindowPresenter
    {
        /// <summary>
        /// Method for creating a new node create connector window.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <returns>A new node create connector window.</returns>
        public static NodeCreateConnectorWindow CreateWindow
        (
            GraphViewer graphViewer,
            NodeCreateDetails details,
            DialogueEditorWindow dsWindow
        )
        {
            var window = ScriptableObject.CreateInstance<NodeCreateConnectorWindow>();

            window.Setup(graphViewer, details, dsWindow);
            window.IsUpdateScreenMousePosition = false;

            return window;
        }
    }
}