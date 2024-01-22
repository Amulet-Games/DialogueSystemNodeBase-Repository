namespace AG.DS
{
    public class PreviewNodeCallback : NodeCallbackFrameBase
    <
        PreviewNode,
        PreviewNodeView,
        PreviewNodeCallback
    >
    {
        /// <inheritdoc />
        public override PreviewNodeCallback Setup(PreviewNodeView view)
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
                graphViewer.Remove(port: View.InputPort);
                graphViewer.Remove(port: View.OutputPort);

                View.InputPort.Disconnect(graphViewer);
                View.OutputPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnCreate()
        {
        }
    }
}