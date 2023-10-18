namespace AG.DS
{
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeCallback
    >
    {
        /// <inheritdoc />
        public override BooleanNodeCallback Setup(BooleanNodeView view)
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
        public override void OnPostCreate()
        {
        }
    }
}