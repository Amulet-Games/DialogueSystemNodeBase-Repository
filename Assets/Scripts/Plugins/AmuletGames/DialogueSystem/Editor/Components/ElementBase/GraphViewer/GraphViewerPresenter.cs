using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphViewerPresenter
    {
        /// <summary>
        /// Create a new graph viewer element.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// <returns>A new graph viewer element.</returns>
        public static GraphViewer CreateElement
        (
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            GraphViewer graphViewer;

            CreateGraphViewer();

            CreateNodeCreationRequestSearchWindow();

            CreateEdgeConnectorSearchWindow();

            CreateOptionEdgeConnectorSearchWindow();

            SetupDetails();

            AddManipulators();

            AddStyleSheet();

            return graphViewer;

            void CreateGraphViewer()
            {
                graphViewer = new(languageHandler, dialogueSystemWindow);
            }

            void CreateNodeCreationRequestSearchWindow()
            {
                graphViewer.NodeCreationRequestSearchWindowView.SearchWindow = NodeCreationRequestSearchWindowPresenter.CreateWindow();
            }

            void CreateEdgeConnectorSearchWindow()
            {
                graphViewer.EdgeConnectorSearchWindowView.SearchWindow = EdgeConnectorSearchWindowPresenter.CreateWindow();
            }

            void CreateOptionEdgeConnectorSearchWindow()
            {
                graphViewer.OptionEdgeConnectorSearchWindowView.SearchWindow = EdgeConnectorSearchWindowPresenter.CreateWindow();
            }

            void SetupDetails()
            {
                // Grid Background
                {
                    GridBackground grid = new();
                    graphViewer.Insert(index: 0, element: grid);
                    grid.StretchToParentSize();
                }

                // Size
                {
                    graphViewer.StretchToParentSize();
                }

                // Zoom
                {
                    // Default Min Scale = 0.25f;
                    // Default Max Scale = 1f;
                    graphViewer.SetupZoom
                    (
                        minScaleSetup: ContentZoomer.DefaultMinScale,
                        maxScaleSetup: 1.15f
                    );
                }
            }

            void AddManipulators()
            {
                graphViewer.AddManipulator(manipulator: new ContentDragger());          // The ability to drag nodes around.
                graphViewer.AddManipulator(manipulator: new SelectionDragger());        // The ability to drag all selected nodes around.
                graphViewer.AddManipulator(manipulator: new RectangleSelector());       // The ability to drag select a rectangle area.
                graphViewer.AddManipulator(manipulator: new FreehandSelector());        // The ability to select a single node.
            }

            void AddStyleSheet()
            {
                graphViewer.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.GraphViewerStyle);
            }
        }
    }
}
