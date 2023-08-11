using UnityEngine.UIElements;

namespace AG.DS
{
    public class EndNodeCallback : NodeCallbackFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeCallback
    >
    {
        /// <inheritdoc />
        public override EndNodeCallback Setup(EndNodeView view)
        {
            View = view;
            return this;
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