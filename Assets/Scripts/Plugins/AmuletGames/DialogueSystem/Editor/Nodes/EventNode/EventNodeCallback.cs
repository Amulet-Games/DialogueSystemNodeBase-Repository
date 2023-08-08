namespace AG.DS
{
    public class EventNodeCallback : NodeCallbackFrameBase
    <
        EventNode,
        EventNodeView,
        EventNodeObserver
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        public EventNodeCallback
        (
            EventNodeView view,
            EventNodeObserver observer
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
                GraphViewer.Remove(port: View.OutputDefaultPort);

                View.InputDefaultPort.Disconnect(GraphViewer);
                View.OutputDefaultPort.Disconnect(GraphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostManualRemove()
        {
        }


        /// <inheritdoc />
        public override void OnPostCreate()
        {
            // If there's no modifier being created after loading, create a new one by default.
            if (View.EventModifierGroupView.FirstModifier == null)
            {
                View.ContentButton.Click();
            }
        }
    }
}