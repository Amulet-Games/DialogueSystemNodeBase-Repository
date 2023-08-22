using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class DefaultPortPresenter
    {
        /// <summary>
        /// Create a new default port element.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <param name="capacity">The capacity type to set for.</param>
        /// <param name="label">The port's label to set for.</param>
        /// <param name="isSiblings">Is this port a sibling to another already existed port?</param>
        /// <returns>A new default port element.</returns>
        public static DefaultPort CreateElement<TEdge>
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction,
            Capacity capacity,
            string label,
            bool isSiblings = false
        )
            where TEdge : Edge, new()
        {
            return null;
        }
    }
}