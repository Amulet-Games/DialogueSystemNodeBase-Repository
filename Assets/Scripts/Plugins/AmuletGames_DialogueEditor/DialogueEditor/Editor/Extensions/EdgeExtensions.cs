using UnityEditor.Experimental.GraphView;

namespace AG
{
    public static class EdgeExtensions
    {
        public static void EdgeRemovedByManualAction(this Edge edge)
        {
            RemoveOptionChannelConnectedStyle();

            void RemoveOptionChannelConnectedStyle()
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