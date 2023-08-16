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
        /// Reference of the graph view's GraphViewChange struct.
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
        /// Reference of the node create connector window.
        /// </summary>
        protected NodeCreateConnectorWindow NodeCreateConnectorWindow;


        /// <summary>
        /// Constructor of the edge connector listener base class.
        /// </summary>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        public EdgeConnectorListenerBase(NodeCreateConnectorWindow nodeCreateConnectorWindow)
        {
            NodeCreateConnectorWindow = nodeCreateConnectorWindow;

            m_EdgesToCreate = new();
            m_EdgesToDelete = new();
            m_ElementsToRemove = new();

            m_GraphViewChange.edgesToCreate = m_EdgesToCreate;
            m_GraphViewChange.elementsToRemove = m_ElementsToRemove;
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the graph view element.</param>
        /// <param name="edge">The edge being created.</param>
        public void OnDrop(GraphView graphView, Edge edge) => OnDrop((GraphViewer)graphView, (TEdge)edge);


        /// <summary>
        /// <see cref="OnDrop(GraphView, Edge)"/>
        /// </summary>
        void OnDrop(GraphViewer graphViewer, TEdge edge)
        {
            m_EdgesToCreate.Clear();
            m_EdgesToCreate.Add(edge);

            m_EdgesToDelete.Clear();
            m_ElementsToRemove.Clear();

            foreach (TEdge m_edge in edge.input.connections)
            {
                if (m_edge != edge)
                {
                    m_EdgesToDelete.Add(m_edge);
                    m_ElementsToRemove.Add(m_edge);
                }
            }

            foreach (TEdge m_edge in edge.output.connections)
            {
                if (m_edge != edge)
                {
                    m_EdgesToDelete.Add(m_edge);
                    m_ElementsToRemove.Add(m_edge);
                }
            }

            if (m_EdgesToDelete.Count > 0)
            {
                for (int i = 0; i < m_EdgesToDelete.Count; i++)
                {
                    m_EdgesToDelete[i].Callback.OnPreManualRemove(graphViewer);

                    graphViewer.Remove(m_EdgesToDelete[i]);

                    m_EdgesToDelete[i].Callback.OnPostManualRemove(graphViewer);
                }
            }

            var newEdge = EdgeManager.Instance.Connect
            (
                output: edge.output,
                input: edge.input
            );

            graphViewer.Add(newEdge);
            graphViewer.graphViewChanged(m_GraphViewChange);
        }


        /// <summary>
        /// Called when edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public abstract void OnDropOutsidePort(Edge edge, Vector2 position);
    }
}