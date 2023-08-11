using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Dialogue system's default edge connector listener.
    /// </summary>
    public class DefaultEdgeConnectorListener : EdgeConnectorListenerBase<DefaultEdge>
    {
        /// <summary>
        /// Constructor of the default edge connector listener class.
        /// </summary>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        public DefaultEdgeConnectorListener(NodeCreateConnectorWindow connectorWindow)
            : base(connectorWindow)
        {
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        protected override void OnDrop(GraphViewer graphViewer, DefaultEdge edge)
        {
            m_EdgesToCreate.Clear();
            m_EdgesToCreate.Add(edge);

            m_EdgesToDelete.Clear();
            m_ElementsToRemove.Clear();

            if (edge.input.IsSingle())
            {
                foreach (DefaultEdge m_edge in edge.input.connections)
                {
                    if (m_edge != edge)
                    {
                        m_EdgesToDelete.Add(m_edge);
                        m_ElementsToRemove.Add(m_edge);
                    }
                }
            }

            if (edge.output.IsSingle())
            {
                foreach (DefaultEdge m_edge in edge.output.connections)
                {
                    if (m_edge != edge)
                    {
                        m_EdgesToDelete.Add(m_edge);
                        m_ElementsToRemove.Add(m_edge);
                    }
                }
            }

            if (m_EdgesToDelete.Count > 0)
            {
                for (int i = 0; i < m_EdgesToDelete.Count; i++)
                {
                    m_EdgesToDelete[i].Disconnect();

                    graphViewer.Remove(m_EdgesToDelete[i]);
                }
            }

            var newEdge = EdgeManager.Instance.Connect
            (
                output: (DefaultPort)edge.output,
                input: (DefaultPort)edge.input
            );

            graphViewer.Add(newEdge);
        }


        /// <inheritdoc />
        public override void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                NodeCreateConnectorWindow.UpdateNodeCreateDetails
                (
                    horizontalAlignmentType: HorizontalAlignmentType.LEFT,

                    connectorType: ConnectorType.DEFAULT,

                    connectorPort: (PortBase)edge.input,

                    toShowSearchEntries: NodeCreateEntryProvider.DefaultNodeInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreateConnectorWindow.UpdateNodeCreateDetails
                (
                    horizontalAlignmentType: HorizontalAlignmentType.RIGHT,

                    connectorType: ConnectorType.DEFAULT,

                    connectorPort: (PortBase)edge.output,

                    toShowSearchEntries: NodeCreateEntryProvider.DefaultNodeOutputEntries
                );
            }

            // Open window.
            NodeCreateConnectorWindow.Open();
        }
    }
}