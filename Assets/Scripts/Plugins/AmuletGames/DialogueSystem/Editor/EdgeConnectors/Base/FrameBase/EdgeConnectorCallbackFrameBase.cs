using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeConnectorCallbackFrameBase
    <
        TEdgeConnectorCallback,
        TNodeCreateConnectorWindow
    >
        : EdgeConnectorCallbackBase
        where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
        where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TEdgeConnectorCallback, TNodeCreateConnectorWindow>
    {
        /// <summary>
        /// The list of edges that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        List<EdgeBase> edgesToDelete;


        /// <summary>
        /// Reference of the connector port element.
        /// </summary>
        protected PortBase ConnectorPort;


        /// <summary>
        /// Reference of the connector edge's style sheet.
        /// </summary>
        protected StyleSheet ConnectorEdgeStyleSheet;


        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        protected TNodeCreateConnectorWindow NodeCreateConnectorWindow;


        /// <summary>
        /// Setup for the edge connector callback base class.
        /// </summary>
        /// <param name="connectorPort">The connector port to set for.</param>
        /// <param name="connectorEdgeStyleSheet">The connector edge style sheet to set for.</param>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        public virtual TEdgeConnectorCallback Setup
        (
            PortBase connectorPort,
            StyleSheet connectorEdgeStyleSheet,
            TNodeCreateConnectorWindow nodeCreateConnectorWindow
        )
        {
            ConnectorPort = connectorPort;
            ConnectorEdgeStyleSheet = connectorEdgeStyleSheet;
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
            var graphViewer = (GraphViewer)graphView;

            EdgesToCreate.Clear();

            if (ConnectorPort.IsSingle())
            {
                edgesToDelete.Clear();
                ElementsToRemove.Clear();

                foreach (var m_edge in edge.input.connections)
                {
                    if (m_edge != edge)
                    {
                        edgesToDelete.Add((EdgeBase)m_edge);
                        ElementsToRemove.Add(m_edge);
                    }
                }

                foreach (var m_edge in edge.output.connections)
                {
                    if (m_edge != edge)
                    {
                        edgesToDelete.Add((EdgeBase)m_edge);
                        ElementsToRemove.Add(m_edge);
                    }
                }

                if (edgesToDelete.Count > 0)
                {
                    for (int i = 0; i < edgesToDelete.Count; i++)
                    {
                        edgesToDelete[i].Callback.OnPreRemoveByUser(graphViewer);

                        graphViewer.Remove(edgesToDelete[i]);

                        edgesToDelete[i].Callback.OnPostRemoveByUser(graphViewer);
                    }
                }
            }

            var newEdge = EdgeManager.Instance.Connect
            (
                output: edge.output as PortBase,
                input: edge.input as PortBase,
                styleSheet: ConnectorEdgeStyleSheet
            );

            EdgesToCreate.Add(newEdge);

            graphViewer.Add(newEdge);
            graphViewer.graphViewChanged(GraphViewChange);
        }


        /// <inheritdoc />
        public override void OnDropOutsidePort(Edge edge, Vector2 position) => OnDropOutsidePort((EdgeBase)edge, position);


        /// <summary>
        /// Read more: 
        /// <br><see cref="OnDropOutsidePort(Edge, Vector2)"/></br>
        /// </summary>
        protected abstract void OnDropOutsidePort(EdgeBase edge, Vector2 position);
    }
}