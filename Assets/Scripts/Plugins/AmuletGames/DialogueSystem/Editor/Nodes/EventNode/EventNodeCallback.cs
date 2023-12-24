namespace AG.DS
{
    public class EventNodeCallback : NodeCallbackFrameBase
    <
        EventNode,
        EventNodeView,
        EventNodeCallback
    >
    {
        /// <inheritdoc />
        public override EventNodeCallback Setup(EventNodeView view)
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
            // If there's no modifier being created after loading, create a new one by default.
            if (View.EventModifierGroupView.FirstModifier == null)
            {
                View.ContentButton.Click();
            }
        }
    }
}