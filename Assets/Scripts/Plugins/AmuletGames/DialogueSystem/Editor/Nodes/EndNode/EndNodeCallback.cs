namespace AG.DS
{
    public class EndNodeCallback : NodeCallbackFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeObserver
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        public EndNodeCallback
        (
            EndNodeView view,
            EndNodeObserver observer
        )
        {
            View = view;
            Observer = observer;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreManualRemove()
        {
            // Remove, disconnect ports
            {
                GraphViewer.Remove(port: View.InputDefaultPort);
                View.InputDefaultPort.Disconnect(GraphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostManualRemove()
        {
        }


        /// <inheritdoc />
        public override void OnPostCreate()
        {
        }
    }
}