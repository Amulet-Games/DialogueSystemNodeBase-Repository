using UnityEditor;

namespace AG.DS
{
    public class SerializeHandler
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the serialize handler class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        public SerializeHandler(GraphViewer graphViewer, HeadBar headBar)
        {
            this.graphViewer = graphViewer;
            this.headBar = headBar;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save all the edges and nodes that are on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        public void SaveEdgesAndNodes(DialogueSystemData dsData)
        {
            SaveEdges(dsData);
            SaveNodes(dsData);

            // Set dirty when the saving is finished.
            EditorUtility.SetDirty(dsData);
        }


        /// <summary>
        /// Save all the edges that are on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        void SaveEdges(DialogueSystemData dsData)
        {
            // Clear data
            {
                dsData.ClearDataEdge();
            }

            // Create data
            {
                var edgeCount = graphViewer.Edges.Count;
                for (int i = 0; i < edgeCount; i++)
                {
                    graphViewer.Edges[i].Save(dsData);
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        void SaveNodes(DialogueSystemData dsData)
        {
            // Clear data
            {
                dsData.ClearDataNode();
            }

            // Create data
            {
                var nodeCount = graphViewer.Nodes.Count;
                for (int i = 0; i < nodeCount; i++)
                {
                    graphViewer.Nodes[i].Save(dsData);
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edges and nodes data that were stored on the scriptable object asset.
        /// </summary>
        /// <param name="dsData">The dialogue system data to load the data from.</param>
        public void LoadEdgesAndNodes(DialogueSystemData dsData)
        {
            LoadNodes(dsData);
            LoadEdges(dsData);

            // Set dirty when the loading is finished.
            EditorUtility.SetDirty(dsData);
        }


        /// <summary>
        /// Load all the nodes' data and create them back on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to load the data from.</param>
        void LoadNodes(DialogueSystemData dsData)
        {
            var dataCount = dsData.NodeData.Count;

            for (int i = 0; i < dataCount; i++)
            {
                graphViewer.Add(
                    NodeManager.Instance.Spawn(graphViewer, headBar, data: dsData.NodeData[i])
                );
            }
        }


        /// <summary>
        /// Load all the edges' data and create them back on the graph.
        /// and attempt to connect the previously linked nodes again.
        /// </summary>
        /// <param name="dsData">The dialogue system data to load the data from.</param>
        void LoadEdges(DialogueSystemData dsData)
        {
            var dataCount = dsData.EdgeData.Count;

            for (int i = 0; i < dataCount; i++)
            {
                var data = dsData.EdgeData[i];

                // Try to find the output port that matches the data's output port GUID.
                if (graphViewer.PortByPortGUID.TryGetValue(data.OutputPortGUID, out PortBase output))
                {
                    // Try to find the input port that matches the data's input port GUID.
                    if (graphViewer.PortByPortGUID.TryGetValue(data.InputPortGUID, out PortBase input))
                    {
                        graphViewer.Add(
                            EdgeManager.Instance.Connect(output, input, data.PortType)
                        );
                    }
                }
            }
        }
    }
}