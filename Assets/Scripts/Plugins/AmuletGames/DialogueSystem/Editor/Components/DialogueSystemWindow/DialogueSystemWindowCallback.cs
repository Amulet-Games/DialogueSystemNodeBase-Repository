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
            HeadbarCallback.OnCreate(window.Headbar);
        }


        /// <summary>
        /// The callback to invoke when the dialogue system window's OnEnable is called.
        /// </summary>
        /// <param name="asset">The dialogue system window asset to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="window">The dialogue system window to set for.</param>
        public static void OnEnable
        (
            DialogueSystemWindowAsset asset,
            GraphViewer graphViewer,
            DialogueSystemWindow window
        )
        {
            if (asset == null)
                return;

            window.Setup();

            window.Load(isForceLoadWindow: true);

            graphViewer.ReframeGraphOnGeometryChanged(
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
        /// <param name="asset">The dialogue system window asset to set for.</param>
        /// <param name="window">The dialogue system window to set for.</param>
        public static void OnDestroy
        (
            DialogueSystemWindowAsset asset,
            DialogueSystemWindow window
        )
        {
            WindowChangedEvent.Unregister(window.DialogueSystemWindowChangedEvent);
            asset.IsAlreadyOpened = false;
        }
    }
}