using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionRootNodeCallback : NodeCallbackFrameBase
    <
        OptionRootNode,
        OptionRootNodeView
    >
    {
        /// <summary>
        /// Reference of the option root observer.
        /// </summary>
        OptionRootNodeObserver observer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The option root node observer to set for.</param>
        public OptionRootNodeCallback
        (
            OptionRootNodeView view,
            OptionRootNodeObserver observer
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
                graphViewer.Remove(port: View.InputDefaultPort);
                graphViewer.Remove(port: View.OutputOptionPort);

                for (int i = 0; i < View.OutputOptionPortGroupView.Cells.Count; i++)
                {
                    graphViewer.Remove(port: View.OutputOptionPortGroupView.Cells[i].Port);
                }

                View.InputDefaultPort.Disconnect(graphViewer);
                View.OutputOptionPort.Disconnect(graphViewer);
                View.OutputOptionPortGroupView.DisconnectAll(graphViewer);
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