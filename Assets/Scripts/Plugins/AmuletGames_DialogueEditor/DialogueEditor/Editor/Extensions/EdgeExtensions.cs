using UnityEditor.Experimental.GraphView;

namespace AG
{
    public static class EdgeExtensions
    {
        /// <summary>
        /// Action that called after an edge was selected by user and removed from the graph.
        /// </summary>
        /// <param name="edge">Extension edge</param>
        public static void EdgeRemovedByManualAction(this Edge edge)
        {
            OptionChannelRemoveConnectedStyle();

            void OptionChannelRemoveConnectedStyle()
            {
                if (edge.output.portColor == DSOptionChannelUtility.ChannelColor)
                {
                    DSOptionChannelUtility.HideEntryConnectedStyle(edge.output);
                    DSOptionChannelUtility.HideTrackConnectedStyle(edge.input);
                }
            }
        }
    }
}