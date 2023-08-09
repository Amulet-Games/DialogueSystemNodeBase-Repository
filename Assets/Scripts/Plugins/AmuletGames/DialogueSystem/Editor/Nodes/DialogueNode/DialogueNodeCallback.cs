using UnityEngine.UIElements;

namespace AG.DS
{
    public class DialogueNodeCallback : NodeCallbackFrameBase
    <
        DialogueNode,
        DialogueNodeView
    >
    {
        /// <summary>
        /// Reference of the dialogue node observer.
        /// </summary>
        DialogueNodeObserver observer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node callback class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The dialogue node observer to set for.</param>
        public DialogueNodeCallback
        (
            DialogueNodeView view,
            DialogueNodeObserver observer
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
                graphViewer.Remove(port: View.OutputDefaultPort);

                View.InputDefaultPort.Disconnect(graphViewer);
                View.OutputDefaultPort.Disconnect(graphViewer);
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