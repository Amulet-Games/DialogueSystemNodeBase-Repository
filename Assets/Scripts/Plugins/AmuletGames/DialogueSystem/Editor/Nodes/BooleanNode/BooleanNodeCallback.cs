namespace AG.DS
{
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeObserver
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        public BooleanNodeCallback
        (
            BooleanNodeView view,
            BooleanNodeObserver observer
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
                GraphViewer.Remove(port: View.TrueOutputDefaultPort);
                GraphViewer.Remove(port: View.FalseOutputDefaultPort);

                View.InputDefaultPort.Disconnect(GraphViewer);
                View.TrueOutputDefaultPort.Disconnect(GraphViewer);
                View.FalseOutputDefaultPort.Disconnect(GraphViewer);
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