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
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputPort);
                View.InputPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        protected override void _OnCreate(bool byUser)
        {
        }
    }
}