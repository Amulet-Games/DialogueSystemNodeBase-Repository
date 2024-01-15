using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Used by the EdgeConnector manipulator to finish the actual edge creation.
    /// <para></para>
    /// <br>Read More:</br>
    /// <br>https://github.com/Unity-Technologies/UnityCsReference/blob/6c247dc72666deb3d5359564fcab5875c5999dc7/Modules/GraphViewEditor/Elements/Port.cs</br>
    /// </summary>
    public class EdgeConnectorListener : IEdgeConnectorListener
    {
        /// <summary>
        /// Reference of the graph view's GraphViewChange struct.
        /// </summary>
        GraphViewChange graphViewChange;


        /// <summary>
        /// The list of edges that are going to be created to the graph from the OnDrop callback.
        /// </summary>
        List<Edge> edgesToCreate;


        /// <summary>
        /// The list of edges that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        List<EdgeBase> edgesToDelete;


        /// <summary>
        /// The list of elements that are going to be removed from the graph from the OnDrop callback.
        /// </summary>
        List<GraphElement> elementsToRemove;


        /// <summary>
        /// Reference of the edge connector search window view.
        /// </summary>
        EdgeConnectorSearchWindowView edgeConnectorSearchWindowView;


        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        EdgeModel edgeModel;


        /// <summary>
        /// Reference of the connector port element.
        /// </summary>
        PortBase connectorPort;


        /// <summary>
        /// Constructor of the edge connector callback class.
        /// </summary>
        /// <param name="connectorPort">The connector port to set for.</param>
        /// <param name="edgeConnectorSearchWindowView">The edge connector window view to set for.</param>
        /// <param name="edgeFocusable">The edge's focusable value to set for.</param>
        /// <param name="edgeStyleSheet">The edge's style sheet to set for.</param>
        public EdgeConnectorListener
        (
            PortBase connectorPort,
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            bool edgeFocusable,
            StyleSheet edgeStyleSheet
        )
        {
            this.connectorPort = connectorPort;
            this.edgeConnectorSearchWindowView = edgeConnectorSearchWindowView;
            edgeModel = new(edgeFocusable, edgeStyleSheet);

            edgesToCreate = new();
            edgesToDelete = new();
            elementsToRemove = new();

            graphViewChange.edgesToCreate = edgesToCreate;
            graphViewChange.elementsToRemove = elementsToRemove;
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the graph view element.</param>
        /// <param name="edge">The edge being created.</param>
        public void OnDrop(GraphView graphView, Edge edge)
        {
            var graphViewer = (GraphViewer)graphView;

            edgesToCreate.Clear();

            if (connectorPort.IsSingle())
            {
                edgesToDelete.Clear();
                elementsToRemove.Clear();

                foreach (var m_edge in edge.input.connections)
                {
                    if (m_edge != edge)
                    {
                        edgesToDelete.Add((EdgeBase)m_edge);
                        elementsToRemove.Add(m_edge);
                    }
                }

                foreach (var m_edge in edge.output.connections)
                {
                    if (m_edge != edge)
                    {
                        edgesToDelete.Add((EdgeBase)m_edge);
                        elementsToRemove.Add(m_edge);
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
                model: edgeModel,
                input: edge.input as PortBase,
                output: edge.output as PortBase
            );

            edgesToCreate.Add(newEdge);

            graphViewer.Add(newEdge);
            graphViewer.graphViewChanged(graphViewChange);
        }


        /// <summary>
        /// The callback to invoke when the edge is dropped in an empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            edgeConnectorSearchWindowView.ConnectorPort = connectorPort;
            edgeConnectorSearchWindowView.EdgeModel = edgeModel;

            edgeConnectorSearchWindowView.SearchWindow.OpenWindow(openScreenPosition: GUIUtility.GUIToScreenPoint(Event.current.mousePosition));

            connectorPort.Callback.OnPostConnectingEdgeDropOutside();
        }
    }
}