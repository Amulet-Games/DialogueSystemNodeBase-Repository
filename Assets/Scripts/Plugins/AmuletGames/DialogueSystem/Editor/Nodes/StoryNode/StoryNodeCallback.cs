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
                graphViewer.Remove(port: View.InputDefaultPort);
                graphViewer.Remove(port: View.OutputDefaultPort);

                View.InputDefaultPort.Disconnect(graphViewer);
                View.OutputDefaultPort.Disconnect(graphViewer);
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