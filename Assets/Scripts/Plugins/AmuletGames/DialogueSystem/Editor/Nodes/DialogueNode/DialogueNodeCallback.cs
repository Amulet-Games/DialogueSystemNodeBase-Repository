using UnityEngine.UIElements;

namespace AG.DS
{
    public class DialogueNodeCallback : NodeCallbackFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeCallback
    >
    {
        /// <inheritdoc />
        public override DialogueNodeCallback Setup(DialogueNodeView view)
        {
            View = view;
            return this;
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
        public override void OnPostCreate()
        {
        }
    }
}