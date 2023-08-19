using UnityEngine.UIElements;

namespace AG.DS
{
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeCallback
    >
    {
        /// <inheritdoc />
        public override StartNodeCallback Setup(StartNodeView view)
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
                graphViewer.Remove(port: View.OutputDefaultPort);
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