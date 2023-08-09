using UnityEngine.UIElements;

namespace AG.DS
{
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeView
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        public StartNodeCallback(StartNodeView view)
        {
            View = view;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreManualRemove(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.OutputDefaultPort);
                View.OutputDefaultPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostManualRemove(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnPostCreate(GeometryChangedEvent evt)
        {
        }
    }
}