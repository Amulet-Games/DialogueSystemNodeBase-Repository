using UnityEngine;

namespace AG.DS
{
    public class NodeCreateRequestWindowPresenter
    {
        /// <summary>
        /// Method for creating a new node create request window.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="serializeHandler">The serialize handler to set for.</param>
        /// <returns>A new node create request window.</returns>
        public static NodeCreateRequestWindow CreateWindow
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow,
            SerializeHandler serializeHandler
        )
        {
            var window = ScriptableObject.CreateInstance<NodeCreateRequestWindow>();

            window.GraphViewer = graphViewer;
            window.DsWindow = dsWindow;
            window.SerializeHandler = serializeHandler;
            window.Details = new
            (
                horizontalAlignType: HorizontalAlignmentType.MIDDLE,
                connectorPort: null
            );

            window.IsUpdatePositionSelectEntry = true;

            return window;
        }
    }
}