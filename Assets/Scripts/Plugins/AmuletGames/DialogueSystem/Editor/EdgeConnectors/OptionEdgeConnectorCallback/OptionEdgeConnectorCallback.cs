using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        OptionEdge,
        OptionPort,
        OptionEdgeConnectorCallback
    >
    {
        /// <inheritdoc />
        public override OptionEdgeConnectorCallback Setup
        (
            NodeCreateConnectorWindow connectorWindow,
            OptionPort connectorPort
        )
        {
            base.Setup(connectorWindow, connectorPort);
            return this;
        }


        // ----------------------------- Callback -----------------------------
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

                    connectorPort: ConnectorPort,

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

                    connectorPort: ConnectorPort,

                    toShowEntries: NodeCreateEntryProvider.OptionChannelOutputEntries
                );
            }
        }
    }
}

/*
 *  /// <inheritdoc />
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
 */