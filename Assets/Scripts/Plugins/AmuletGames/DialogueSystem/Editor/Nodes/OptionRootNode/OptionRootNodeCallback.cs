using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionRootNodeCallback : NodeCallbackFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeCallback
    >
    {
        /// <inheritdoc />
        public override OptionRootNodeCallback Setup(OptionRootNodeView view)
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
                graphViewer.Remove(port: View.OutputOptionPort);

                for (int i = 0; i < View.OutputOptionPortGroupView.Cells.Count; i++)
                {
                    graphViewer.Remove(port: View.OutputOptionPortGroupView.Cells[i].Port);
                }

                View.InputDefaultPort.Disconnect(graphViewer);
                View.OutputOptionPort.Disconnect(graphViewer);
                View.OutputOptionPortGroupView.DisconnectAll(graphViewer);
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