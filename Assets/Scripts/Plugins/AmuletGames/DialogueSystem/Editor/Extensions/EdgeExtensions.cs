using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public static class EdgeExtensions
    {
        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called after an edge was selected by user and removed from the graph.
        /// </summary>
        /// <param name="edge">Extension edge</param>
        public static void PreManualRemovedAction(this Edge edge)
        {
            OptionChannelRemoveConnectedStyle();

            void OptionChannelRemoveConnectedStyle()
            {
                if (edge.IsOptionChannelEdge())
                {
                    OptionChannelHelper.HideConnectedStyleBoth
                    (
                        inputPort: edge.input,
                        outputPort: edge.output
                    );
                }
            }
        }


        // ----------------------------- Extensions -----------------------------
        /// <summary>
        /// Extension method that returns true if the edge is created from an option channel's port.
        /// </summary>
        /// <param name="edge">Extension edge</param>
        /// <returns>True if the edge is created from an option channel's port.</returns>
        public static bool IsOptionChannelEdge(this Edge edge) =>
            edge.output.portColor == PortsConfig.OptionChannelPortColor;
    }
}