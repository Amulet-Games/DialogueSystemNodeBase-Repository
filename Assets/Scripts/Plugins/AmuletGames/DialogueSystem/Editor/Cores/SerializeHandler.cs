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
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public void SaveEdgesAndNodes(DialogueSystemModel dsModel)
        {
            SaveEdges(dsModel);
            SaveNodes(dsModel);

            // Set dirty when the saving is finished.
            EditorUtility.SetDirty(dsModel);
        }


        /// <summary>
        /// Save all the edges that are on the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void SaveEdges(DialogueSystemModel dsModel)
        {
            // Clear existing edge models
            {
                dsModel.ClearEdgeModels();
            }

            // Create new edge models
            {
                var edgeCount = graphViewer.Edges.Count;
                for (int i = 0; i < edgeCount; i++)
                {
                    graphViewer.Edges[i].Save(dsModel);
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void SaveNodes(DialogueSystemModel dsModel)
        {
            // Clear existing node models
            {
                dsModel.ClearNodeModels();
            }

            // Create new node models
            {
                var nodeCount = graphViewer.Nodes.Count;
                for (int i = 0; i < nodeCount; i++)
                {
                    NodeManager.Instance.Save(node: graphViewer.Nodes[i]);
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edge and node models that are stored on the scriptable object asset.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public void LoadEdgesAndNodes(DialogueSystemModel dsModel)
        {
            LoadNodes(dsModel);
            LoadEdges(dsModel);

            // Set dirty when the loading is finished.
            EditorUtility.SetDirty(dsModel);
        }


        /// <summary>
        /// Load the node models and spawn the nodes to the graph.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void LoadNodes(DialogueSystemModel dsModel)
        {
            var modelCount = dsModel.NodeModels.Count;

            for (int i = 0; i < modelCount; i++)
            {
                graphViewer.Add(
                    NodeManager.Instance.Spawn(graphViewer, headBar, model: dsModel.NodeModels[i])
                );
            }
        }


        /// <summary>
        /// Load the edge model and connects the ports on the graph.
        /// and attempt to connect the previously linked nodes again.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void LoadEdges(DialogueSystemModel dsModel)
        {
            var modelCount = dsModel.EdgeModels.Count;

            for (int i = 0; i < modelCount; i++)
            {
                var model = dsModel.EdgeModels[i];

                // Try to find the output port that matches the model's output port GUID.
                if (graphViewer.PortByPortGUID.TryGetValue(model.OutputPortGUID, out PortBase output))
                {
                    // Try to find the input port that matches the model's input port GUID.
                    if (graphViewer.PortByPortGUID.TryGetValue(model.InputPortGUID, out PortBase input))
                    {
                        graphViewer.Add(
                            EdgeManager.Instance.Connect(output, input, model.PortType)
                        );
                    }
                }
            }
        }
    }
}