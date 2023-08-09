using UnityEngine.UIElements;

namespace AG.DS
{
    public class EndNodeCallback : NodeCallbackFrameBase
    <
        EndNode,
        EndNodeView
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        public EndNodeCallback(EndNodeView view)
        {
            View = view;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreManualRemove(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputDefaultPort);
                View.InputDefaultPort.Disconnect(graphViewer);
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