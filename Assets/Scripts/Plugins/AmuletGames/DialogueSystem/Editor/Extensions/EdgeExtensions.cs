using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public static class EdgeExtensions
    {
        /// <summary>
        /// Returns true if the edge is an option edge.
        /// </summary>
        /// <param name="edge">Extension edge</param>
        /// <returns>True if the edge is an option edge.</returns>
        public static bool IsOptionEdge(this Edge edge)
        {
            return edge.output.portColor == PortConfig.OptionPortColor;
        }
    }
}