using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Dialogue system's edge connector listener base.
    /// <br>This script is created base on the original script created by unity official.</br>.
    /// <para></para>
    /// <br>Find the class named "DefaultEdgeConnectorListener" in the GitHub link down below.</br>
    /// <br>Read More https://github.com/Unity-Technologies/UnityCsReference/blob/6c247dc72666deb3d5359564fcab5875c5999dc7/Modules/GraphViewEditor/Elements/Port.cs</br>
    /// </summary>
    public abstract class EdgeConnectorListenerBase : IEdgeConnectorListener
    {
        /// <summary>
        /// Temporary reference of the graph viewer's GraphViewChange callback.
        /// </summary>
        GraphViewChange m_GraphViewChange;


        /// <summary>
        /// Reference of the dialogue system's node creation connector window module.
        /// </summary>
        protected NodeCreationConnectorWindow NodeCreationConnectorWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the edge connector listener base class.
        /// </summary>
        public EdgeConnectorListenerBase(NodeCreationConnectorWindow nodeCreationConnectorWindow)
        {
            NodeCreationConnectorWindow = nodeCreationConnectorWindow;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action for the edge that were created and connected in the onDrop event.
        /// </summary>
        public abstract void EdgeConnectedAction(Edge edge);


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the GraphView.</param>
        /// <param name="edge">The edge being created.</param>
        public virtual void OnDrop(GraphView graphView, Edge edge)
        {
            List<Edge> m_EdgesToCreate = new(){edge};
            m_GraphViewChange.edgesToCreate = m_EdgesToCreate;

            // We can't just add these edges to delete to the m_GraphViewChange
            // because we want the proper deletion code in GraphView to also
            // be called. Of course, that code (in DeleteElements) also
            // sends a GraphViewChange.
            List<GraphElement> m_EdgesToDelete = new();

            // If the input port is single,
            // add the edge that it's using to connect to the m_EdgesToDelete.
            if (edge.input.capacity == Port.Capacity.Single)
                foreach (Edge edgeToDelete in edge.input.connections)
                    if (edgeToDelete != edge)
                        m_EdgesToDelete.Add(edgeToDelete);

            // If the output port is single,
            // add the edge that it's using to connect to the m_EdgesToDelete.
            if (edge.output.capacity == Port.Capacity.Single)
                foreach (Edge edgeToDelete in edge.output.connections)
                    if (edgeToDelete != edge)
                        m_EdgesToDelete.Add(edgeToDelete);

            if (m_EdgesToDelete.Count > 0)
                graphView.DeleteElements(m_EdgesToDelete);

            var edgesToCreate = m_EdgesToCreate;
            if (graphView.graphViewChanged != null)
            {
                edgesToCreate = graphView.graphViewChanged(m_GraphViewChange).edgesToCreate;
            }

            // Add the edge on the graph and connect the ports from both side.
            for (int i = 0; i < edgesToCreate.Count; i++)
            {
                graphView.AddElement(edgesToCreate[i]);
                edge.input.Connect(edgesToCreate[i]);
                edge.output.Connect(edgesToCreate[i]);

                // Execute the EdgeConnectedAction
                EdgeConnectedAction(edgesToCreate[i]);
            }
        }


        /// <summary>
        /// Called when a new edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public abstract void OnDropOutsidePort(Edge edge, Vector2 position);
    }
}