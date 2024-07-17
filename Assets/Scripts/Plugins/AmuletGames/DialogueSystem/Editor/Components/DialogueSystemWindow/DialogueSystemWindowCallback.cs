using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace AG.DS
{
    public class DialogueSystemWindowCallback
    {
        /// <summary>
        /// The callback to invoke when the dialogue system window is created.
        /// </summary>
        /// <param name="window">The dialogue system window to set for.</param>
        public static void OnCreate(DialogueSystemWindow window)
        {
        }


        /// <summary>
        /// The callback to invoke when the dialogue system window's OnEnable is called.
        /// </summary>
        /// <param name="asset">The dialogue system window asset to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="window">The dialogue system window to set for.</param>
        public static void OnEnable(DialogueSystemWindow window)
        {
            if (window.Asset == null)
                return;

            window.Setup();

            window.Load(isForceLoadWindow: true);

            window.GraphViewer.ReframeGraphOnGeometryChanged(
                geometryChangedElement: window.rootVisualElement,
                frameType: FrameType.All
            );
        }


        /// <summary>
        /// The callback to invoke when the dialogue system window's OnDisable is called.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public static void OnDisable(GraphViewer graphViewer)
        {
            // Dispose search windows
            {
                Object.DestroyImmediate(graphViewer.NodeCreationRequestSearchWindowView.SearchWindow, allowDestroyingAssets: true);
                Object.DestroyImmediate(graphViewer.EdgeConnectorSearchWindowView.SearchWindow, allowDestroyingAssets: true);
                Object.DestroyImmediate(graphViewer.OptionEdgeConnectorSearchWindowView.SearchWindow, allowDestroyingAssets: true);
            }
        }


        /// <summary>
        /// The callback to invoke when the dialogue system window's OnDestroy is called.
        /// </summary>
        /// <param name="window">The dialogue system window to set for.</param>
        public static void OnDestroy(DialogueSystemWindow window)
        {
            WindowChangedEvent.Unregister(window.DialogueSystemWindowChangedEvent);
            window.Asset.IsAlreadyOpened = false;
        }
    }
}