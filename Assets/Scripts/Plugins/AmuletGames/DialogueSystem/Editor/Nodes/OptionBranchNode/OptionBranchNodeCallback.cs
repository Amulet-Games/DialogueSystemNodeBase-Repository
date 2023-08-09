using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionBranchNodeCallback : NodeCallbackFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView
    >
    {
        /// <summary>
        /// Reference of the option branch node observer.
        /// </summary>
        OptionBranchNodeObserver observer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The option branch node observer to set for.</param>
        public OptionBranchNodeCallback
        (
            OptionBranchNodeView view,
            OptionBranchNodeObserver observer
        )
        {
            View = view;
            this.observer = observer;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreManualRemove(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputOptionPort);
                graphViewer.Remove(port: View.OutputDefaultPort);

                View.InputOptionPort.Disconnect(graphViewer);
                View.OutputDefaultPort.Disconnect(graphViewer);
            }

            // Unregister events
            {
                observer.UnregisterEvents();
            }
        }


        /// <inheritdoc />
        public override void OnPostManualRemove(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnPostCreate(GeometryChangedEvent evt)
        {
        }
    }
}