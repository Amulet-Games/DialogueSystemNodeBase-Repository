using UnityEditor;

namespace AG.DS
{
    public class SerializeHandler
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the serialize handler class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public SerializeHandler(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;
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
            // Temp counter variable for each of the data list.
            int dataCount;

            LoadBooleanNodes();

            LoadDialogueNodes();

            LoadEndNodes();

            LoadEventNodes();

            LoadOptionBranchNodes();

            LoadOptionRootNodes();

            LoadPreviewNodes();

            LoadStartNodes();

            LoadStoryNodes();

            void LoadBooleanNodes()
            {
                dataCount = dsData.BooleanNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new BooleanNode(graphViewer);
                    node.Serializer.Load(dsData.BooleanNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadDialogueNodes()
            {
                dataCount = dsData.DialogueNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new DialogueNode(graphViewer);
                    node.Serializer.Load(dsData.DialogueNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadEndNodes()
            {
                dataCount = dsData.EndNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new EndNode(graphViewer);
                    node.Serializer.Load(dsData.EndNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadEventNodes()
            {
                dataCount = dsData.EventNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new EventNode(graphViewer);
                    node.Serializer.Load(dsData.EventNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadOptionBranchNodes()
            {
                dataCount = dsData.OptionBranchNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new OptionBranchNode(graphViewer);
                    node.Serializer.Load(dsData.OptionBranchNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadOptionRootNodes()
            {
                dataCount = dsData.OptionRootNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new OptionRootNode(graphViewer);
                    node.Serializer.Load(dsData.OptionRootNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadPreviewNodes()
            {
                dataCount = dsData.PreviewNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new PreviewNode(graphViewer);
                    node.Serializer.Load(dsData.PreviewNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadStartNodes()
            {
                dataCount = dsData.StartNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new StartNode(graphViewer);
                    node.Serializer.Load(dsData.StartNodeData[i]);
                    node.CreatedAction();
                }
            }

            void LoadStoryNodes()
            {
                dataCount = dsData.StoryNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    var node = new StoryNode(graphViewer);
                    node.Serializer.Load(dsData.StoryNodeData[i]);
                    node.CreatedAction();
                }
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
                        EdgeManager.Instance.Connect(output, input, data.PortType);
                    }
                }
            }
        }
    }
}