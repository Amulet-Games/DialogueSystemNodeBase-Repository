using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeCallback : EdgeCallbackFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override void Setup
        (
            Edge<DefaultPort, PortModel, DefaultEdgeView> edge,
            DefaultEdgeView view
        )
        {
            Edge = edge;
            View = view;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Disconnect ports
            {
                View.Input.Disconnect(Edge);
                View.Output.Disconnect(Edge);

                Debug.Log("OnPreRemoveByUser");
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }
    }
}