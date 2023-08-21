using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class OptionPortPresenter
    {
        /// <summary>
        /// Create a new option port element.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <returns>A new option port element.</returns>
        public static OptionPort CreateElement<TEdge>
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
            where TEdge : Edge, new()
        {
            return null;
        }
    }
}