using UnityEngine;

namespace AG.DS
{
    public class NodeCreateConnectorWindowPresenter
    {
        /// <summary>
        /// Method for creating a new node create connector window.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        /// <returns>A new node create connector window.</returns>
        public static NodeCreateConnectorWindow CreateWindow
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            NodeCreateDetails details,
            DialogueSystemWindow dsWindow
        )
        {
            var window = ScriptableObject.CreateInstance<NodeCreateConnectorWindow>();

            window.Setup(graphViewer, languageHandler, details, dsWindow);
            window.IsUpdateScreenMousePosition = false;

            return window;
        }
    }
}