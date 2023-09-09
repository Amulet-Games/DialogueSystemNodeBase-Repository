using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeConnectorCallbackFrameBase
    <
        TPort,
        TEdge,
        TEdgeView,
        TNodeCreateConnectorWindow,
        TEdgeConnectorCallback
    >
        : EdgeConnectorCallbackBase
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdge, TEdgeView>
        where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TPort, TEdge, TEdgeView, TNodeCreateConnectorWindow>
        where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TPort, TEdge, TEdgeView, TNodeCreateConnectorWindow, TEdgeConnectorCallback>
    {
        /// <summary>
        /// The list of edges that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        List<TEdge> edgesToDelete;


        /// <summary>
        /// Reference of the connector's port element.
        /// </summary>
        protected TPort ConnectorPort;


        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        protected TNodeCreateConnectorWindow NodeCreateConnectorWindow;


        /// <summary>
        /// Setup for the edge connector callback base class.
        /// </summary>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        public virtual TEdgeConnectorCallback Setup
        (
            TPort connectorPort,
            TNodeCreateConnectorWindow nodeCreateConnectorWindow
        )
        {
            ConnectorPort = connectorPort;
            NodeCreateConnectorWindow = nodeCreateConnectorWindow;

            EdgesToCreate = new();
            edgesToDelete = new();
            ElementsToRemove = new();

            GraphViewChange.edgesToCreate = EdgesToCreate;
            GraphViewChange.elementsToRemove = ElementsToRemove;

            return null;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnDrop(GraphView graphView, Edge edge)
        {
            GraphViewer graphViewer = (GraphViewer)graphView;

            EdgesToCreate.Clear();
            edgesToDelete.Clear();
            ElementsToRemove.Clear();

            foreach (var m_edge in edge.input.connections)
            {
                if (m_edge != edge)
                {
                    edgesToDelete.Add((TEdge)m_edge);
                    ElementsToRemove.Add(m_edge);
                }
            }

            foreach (var m_edge in edge.output.connections)
            {
                if (m_edge != edge)
                {
                    edgesToDelete.Add((TEdge)m_edge);
                    ElementsToRemove.Add(m_edge);
                }
            }

            if (edgesToDelete.Count > 0)
            {
                for (int i = 0; i < edgesToDelete.Count; i++)
                {
                    edgesToDelete[i].Callback.OnPreManualRemove(graphViewer);

                    graphViewer.Remove(edgesToDelete[i]);

                    edgesToDelete[i].Callback.OnPostManualRemove(graphViewer);
                }
            }

            var newEdge = EdgeManager.Instance.Connect
            (
                output: edge.output,
                input: edge.input
            );

            EdgesToCreate.Add(newEdge);

            graphViewer.Add(newEdge);
            graphViewer.graphViewChanged(GraphViewChange);
        }
    }
}