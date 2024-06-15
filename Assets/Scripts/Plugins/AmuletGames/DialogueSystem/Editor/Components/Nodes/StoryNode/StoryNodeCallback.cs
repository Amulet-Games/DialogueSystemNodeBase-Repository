namespace AG.DS
{
    public class StoryNodeCallback : NodeCallbackFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeCallback
    >
    {
        /// <inheritdoc />
        public override StoryNodeCallback Setup(StoryNodeView view)
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
        protected override void _OnCreate(bool byUser)
        {
        }
    }
}