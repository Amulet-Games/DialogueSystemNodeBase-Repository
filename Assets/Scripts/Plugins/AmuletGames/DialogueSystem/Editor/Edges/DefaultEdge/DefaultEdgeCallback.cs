using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeCallback : EdgeCallbackFrameBase
    <
        DefaultPort,
        PortModel
    >
    {
        /// <inheritdoc />
        public override void Setup(Edge<DefaultPort, PortModel> edge)
        {
            Edge = edge;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Disconnect ports
            {
                Edge.Input.Disconnect(Edge);
                Edge.Output.Disconnect(Edge);

                Debug.Log("OnPreRemoveByUser");
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }
    }
}