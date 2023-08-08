namespace AG.DS
{
    public class DialogueNodeCallback : NodeCallbackFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeObserver
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        public DialogueNodeCallback
        (
            DialogueNodeView view,
            DialogueNodeObserver observer
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
        }
    }
}