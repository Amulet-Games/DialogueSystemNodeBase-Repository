namespace AG.DS
{
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeCallback
    >
    {
        /// <inheritdoc />
        public override StartNodeCallback Setup(StartNodeView view)
        {
            View = view;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.OutputPort);
                View.OutputPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnCreate(bool byUser)
        {
        }
    }
}