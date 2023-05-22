using UnityEngine;

namespace AG.DS
{
    public class NodeCreateConnectorWindowPresenter
    {
        /// <summary>
        /// Method for creating a new node create connector window.
        /// <br>Since the class is a scriptable object, the method is also a constructor for the class.</br>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="serializeHandler">The serialize handler to set for.</param>
        /// <returns>A new node create connector window.</returns>
        public static NodeCreateConnectorWindow CreateWindow
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow,
            SerializeHandler serializeHandler
        )
        {
            var window = ScriptableObject.CreateInstance<NodeCreateConnectorWindow>();

            window.DsWindow = dsWindow;
            window.GraphViewer = graphViewer;
            window.SerializeHandler = serializeHandler;
            window.Details = new();
            window.IsUpdatePositionSelectEntry = false;

            return window;
        }
    }
}