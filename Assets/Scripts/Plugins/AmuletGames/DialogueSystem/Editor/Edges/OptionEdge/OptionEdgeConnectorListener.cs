using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Dialogue system's option edge connector listener.
    /// </summary>
    public class OptionEdgeConnectorListener : EdgeConnectorListenerBase<OptionEdge>
    {
        /// <summary>
        /// The option port that the listener is linking to.
        /// </summary>
        OptionPort linkOptionPort;


        /// <summary>
        /// Constructor of the option edge connector listener class.
        /// </summary>
        /// <param name="linkOptionPort">The link option port to set for.</param>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        public OptionEdgeConnectorListener
        (
            OptionPort linkOptionPort,
            NodeCreateConnectorWindow connectorWindow
        )
            : base(connectorWindow)
        {
            this.linkOptionPort = linkOptionPort;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        //protected override void OnDrop(GraphViewer graphViewer, OptionEdge edge)
        //{
        //    m_EdgesToCreate.Clear();
        //    m_EdgesToCreate.Add(edge);

        //    m_EdgesToDelete.Clear();
        //    m_ElementsToRemove.Clear();

        //    foreach (OptionEdge m_edge in edge.input.connections)
        //    {
        //        if (m_edge != edge)
        //        {
        //            m_EdgesToDelete.Add(m_edge);
        //            m_ElementsToRemove.Add(m_edge);
        //        }
        //    }

        //    foreach (OptionEdge m_edge in edge.output.connections)
        //    {
        //        if (m_edge != edge)
        //        {
        //            m_EdgesToDelete.Add(m_edge);
        //            m_ElementsToRemove.Add(m_edge);
        //        }
        //    }

        //    if (m_EdgesToDelete.Count > 0)
        //    {
        //        for (int i = 0; i < m_EdgesToDelete.Count; i++)
        //        {
        //            m_EdgesToDelete[i].Callback.OnPreManualRemove(graphViewer);

        //            graphViewer.Remove(m_EdgesToDelete[i]);

        //            m_EdgesToDelete[i].Callback.OnPostManualRemove(graphViewer);
        //        }
        //    }

        //    var newEdge = EdgeManager.Instance.Connect
        //    (
        //        output: (OptionPort)edge.output,
        //        input: (OptionPort)edge.input
        //    );

        //    graphViewer.Add(newEdge);
        //}


        /// <inheritdoc />
        public override void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                NodeCreateConnectorWindow.Open
                (
                    horizontalAlignmentType: HorizontalAlignmentType.LEFT,

                    connectorType: ConnectorType.OPTION,

                    connectorPort: linkOptionPort,

                    toShowEntries: NodeCreateEntryProvider.OptionChannelInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreateConnectorWindow.Open
                (
                    horizontalAlignmentType: HorizontalAlignmentType.RIGHT,

                    connectorType: ConnectorType.OPTION,

                    connectorPort: linkOptionPort,

                    toShowEntries: NodeCreateEntryProvider.OptionChannelOutputEntries
                );
            }
        }
    }
}