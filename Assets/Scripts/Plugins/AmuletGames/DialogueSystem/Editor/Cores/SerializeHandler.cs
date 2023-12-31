using UnityEditor;

namespace AG.DS
{
    public class SerializeHandler
    {
        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save all the edges and nodes that are on the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void Save
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer
        )
        {
            SaveEdges(dsModel, graphViewer);
            SaveNodes(dsModel, graphViewer);

            // Set dirty when the saving is finished.
            EditorUtility.SetDirty(dsModel);
        }


        /// <summary>
        /// Save all the edges that are on the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void SaveEdges
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer
        )
        {
            // Clear existing edges data
            {
                dsModel.ClearEdgesData();
            }

            // Create new edges data
            {
                var edgeCount = graphViewer.Edges.Count;
                for (int i = 0; i < edgeCount; i++)
                {
                    dsModel.EdgesData.Add(
                        EdgeManager.Instance.Save(graphViewer.Edges[i])
                    );
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void SaveNodes
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer
        )
        {
            // Clear existing nodes data
            {
                dsModel.ClearNodesData();
            }

            // Create new nodes data
            {
                var nodeCount = graphViewer.Nodes.Count;
                for (int i = 0; i < nodeCount; i++)
                {
                    dsModel.NodesData.Add(
                        NodeManager.Instance.Save(graphViewer.Nodes[i])
                    );
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edges and nodes data that are stored on the scriptable object asset.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        public void Load
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            LoadNodes(dsModel, graphViewer, languageHandler);
            LoadEdges(dsModel, graphViewer);

            // Set dirty when the loading is finished.
            EditorUtility.SetDirty(dsModel);
        }


        /// <summary>
        /// Load the nodes data and spawn the nodes to the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        void LoadNodes
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            var count = dsModel.NodesData.Count;
            for (int i = 0; i < count; i++)
            {
                graphViewer.Add(
                    NodeManager.Instance.Spawn(graphViewer, dsModel.NodesData[i], languageHandler)
                );
            }
        }


        /// <summary>
        /// Load the edges data and connects the ports on the graph.
        /// and attempt to connect the previously linked nodes again.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void LoadEdges
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer
        )
        {
            var count = dsModel.EdgesData.Count;

            for (int i = 0; i < count; i++)
            {
                var data = dsModel.EdgesData[i];

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