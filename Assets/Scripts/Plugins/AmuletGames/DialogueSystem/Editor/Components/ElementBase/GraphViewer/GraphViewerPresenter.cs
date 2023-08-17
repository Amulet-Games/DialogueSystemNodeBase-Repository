using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphViewerPresenter
    {
        /// <summary>
        /// Create a new graph viewer element.
        /// </summary>
        /// <returns>A new graph viewer element.</returns>
        public static GraphViewer CreateElement()
        {
            GraphViewer graphViewer;

            CreateGraphViewer();

            SetupGridBackground();

            SetupGraphSize();

            SetupGraphManipulator();

            SetupGraphZoom();

            AddStyleSheet();

            return graphViewer;

            void CreateGraphViewer()
            {
                graphViewer = new();
            }

            void SetupGridBackground()
            {
                // Add a visible grid to the background.
                GridBackground grid = new();
                graphViewer.Insert(index: 0, element: grid);
                grid.StretchToParentSize();
            }

            void SetupGraphSize()
            {
                graphViewer.StretchToParentSize();
            }

            void SetupGraphManipulator()
            {
                graphViewer.AddManipulator(manipulator: new ContentDragger());          // The ability to drag nodes around.
                graphViewer.AddManipulator(manipulator: new SelectionDragger());        // The ability to drag all selected nodes around.
                graphViewer.AddManipulator(manipulator: new RectangleSelector());       // The ability to drag select a rectangle area.
                graphViewer.AddManipulator(manipulator: new FreehandSelector());        // The ability to select a single node.
            }

            void SetupGraphZoom()
            {
                // Default Min Scale = 0.25f;
                // Default Max Scale = 1f;
                graphViewer.SetupZoom
                (
                    minScaleSetup: ContentZoomer.DefaultMinScale,
                    maxScaleSetup: 1.15f
                );
            }

            void AddStyleSheet()
            {
                graphViewer.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGraphViewerStyle);
            }
        }
    }
}