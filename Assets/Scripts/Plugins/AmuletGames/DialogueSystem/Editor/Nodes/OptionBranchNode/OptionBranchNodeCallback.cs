namespace AG.DS
{
    public class OptionBranchNodeCallback : NodeCallbackFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeObserver
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        public OptionBranchNodeCallback
        (
            OptionBranchNodeView view,
            OptionBranchNodeObserver observer
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
                GraphViewer.Remove(port: View.InputOptionPort);
                GraphViewer.Remove(port: View.OutputDefaultPort);

                View.InputOptionPort.Disconnect(GraphViewer);
                View.OutputDefaultPort.Disconnect(GraphViewer);
            }

            // Unregister events
            {
                Observer.UnregisterEvents();
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