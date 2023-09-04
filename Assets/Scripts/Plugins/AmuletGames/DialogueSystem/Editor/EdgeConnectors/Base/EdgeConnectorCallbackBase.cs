using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Used by EdgeConnector manipulator to finish the actual edge creation.
    /// <para></para>
    /// <br>Read More:</br>
    /// <br>https://github.com/Unity-Technologies/UnityCsReference/blob/6c247dc72666deb3d5359564fcab5875c5999dc7/Modules/GraphViewEditor/Elements/Port.cs</br>
    /// </summary>
    public abstract class EdgeConnectorCallbackBase : IEdgeConnectorListener
    {
        /// <summary>
        /// Reference of the graph view's GraphViewChange struct.
        /// </summary>
        protected GraphViewChange GraphViewChange;


        /// <summary>
        /// The list of edges that are going to be created to the graph from the OnDrop callback.
        /// </summary>
        protected List<Edge> EdgesToCreate;


        /// <summary>
        /// The list of elements that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        protected List<GraphElement> ElementsToRemove;


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the graph view element.</param>
        /// <param name="edge">The edge being created.</param>
        public abstract void OnDrop(GraphView graphView, Edge edge);


        /// <summary>
        /// Called when edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public abstract void OnDropOutsidePort(Edge edge, Vector2 position);
    }
}