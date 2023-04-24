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
    public abstract class EdgeConnectorListenerBase<TEdge>
        : IEdgeConnectorListener
        where TEdge : EdgeBase
    {
        /// <summary>
        /// Reference of the graph view's GraphViewChange callback.
        /// </summary>
        protected GraphViewChange m_GraphViewChange;


        /// <summary>
        /// The list of edges that are going to be created to the graph from the OnDrop callback.
        /// </summary>
        protected List<Edge> m_EdgesToCreate;


        /// <summary>
        /// The list of edges that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        protected List<TEdge> m_EdgesToDelete;


        /// <summary>
        /// The list of elements that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        protected List<GraphElement> m_ElementsToRemove;


        /// <summary>
        /// Reference of the node creation connector window module.
        /// </summary>
        protected NodeCreationConnectorWindow NodeCreationConnectorWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the edge connector listener base class.
        /// </summary>
        /// <param name="nodeCreationConnectorWindow">The node creation connector window module to set for.</param>
        public EdgeConnectorListenerBase(NodeCreationConnectorWindow nodeCreationConnectorWindow)
        {
            NodeCreationConnectorWindow = nodeCreationConnectorWindow;

            m_EdgesToCreate = new();
            m_EdgesToDelete = new();
            m_ElementsToRemove = new();

            m_GraphViewChange.edgesToCreate = m_EdgesToCreate;
            m_GraphViewChange.elementsToRemove = m_ElementsToRemove;
        }


        // ----------------------------- IEdgeConnectorListener -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the graph view module.</param>
        /// <param name="edge">The edge being created.</param>
        public void OnDrop(GraphView graphView, Edge edge)
        {
            OnDrop((GraphViewer)graphView, edge);

            graphView.graphViewChanged(m_GraphViewChange);
        }


        /// <summary>
        /// <see cref="OnDrop(GraphView, Edge)"/>
        /// </summary>
        protected abstract void OnDrop(GraphViewer graphViewer, TEdge edge);


        /// <summary>
        /// Called when edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public abstract void OnDropOutsidePort(Edge edge, Vector2 position);
    }
}

/*
 *  public virutal void OnDrop(GraphView graphView, Edge edge)
    {
        var m_EdgesToCreate = new List<Edge>(){edge};
        m_GraphViewChange.edgesToCreate = m_EdgesToCreate;

        // We can't just add these edges to delete to the m_GraphViewChange
        // because we want the proper deletion code in GraphView to also
        // be called. Of course, that code (in DeleteElements) also
        // sends a GraphViewChange.
        var m_EdgesToDelete = new List<GraphElement>();

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
 */

/*
    void ConnectPorts(GraphView graphView, Edge edge)
    {
        m_EdgesToCreate.Clear();
        m_EdgesToCreate.Add(edge);

        // We can't just add these edges to delete to the m_GraphViewChange
        // because we want the proper deletion code in GraphView to also
        // be called. Of course, that code (in DeleteElements) also
        // sends a GraphViewChange.
        m_EdgesToDelete.Clear();

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
            OnDropCreateEdge(
                output: edge.output,
                input: edge.input,
                graphView: graphView);
        }
    }
 */