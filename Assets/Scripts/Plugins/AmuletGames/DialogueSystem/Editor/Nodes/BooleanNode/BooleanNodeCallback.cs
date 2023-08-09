using UnityEngine.UIElements;

namespace AG.DS
{
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeView
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        public BooleanNodeCallback(BooleanNodeView view)
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
                graphViewer.Remove(port: View.TrueOutputDefaultPort);
                graphViewer.Remove(port: View.FalseOutputDefaultPort);

                View.InputDefaultPort.Disconnect(graphViewer);
                View.TrueOutputDefaultPort.Disconnect(graphViewer);
                View.FalseOutputDefaultPort.Disconnect(graphViewer);
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