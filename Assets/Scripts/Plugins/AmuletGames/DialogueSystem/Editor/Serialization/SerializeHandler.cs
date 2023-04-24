using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class SerializeHandler
    {
        /// <summary>
        /// Reference of the dialogue system's graph viewer module.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Internal cache of the nodes that the handler is going to save.
        /// </summary>
        List<NodeBase> nodes;


        /// <summary>
        /// Internal cache of the edges that the handler is going to save.
        /// </summary>
        List<EdgeBase> edges;


        /// <summary>
        /// Internal cache of the ports that the handler is going to save.
        /// </summary>
        Dictionary<string, PortBase> portByPortGUID;


        /// <summary>
        /// Counter of the node cache.
        /// </summary>
        int nodesCount;


        /// <summary>
        /// Counter of the edge cache.
        /// </summary>
        int edgesCount;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's serialize handler class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public SerializeHandler(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;

            nodes = new();
            edges = new();
            portByPortGUID = new();
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
            ClearEdgeData();

            CreateEdgeData();

            void ClearEdgeData()
            {
                dsData.EdgeData.Clear();
            }

            void CreateEdgeData()
            {
                for (int i = 0; i < edgesCount; i++)
                {
                    edges[i].Save(dsData);
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        void SaveNodes(DialogueSystemData dsData)
        {
            ClearNodeData();

            CreateNodeData();

            void ClearNodeData()
            {
                dsData.ClearDataNodes();
            }

            void CreateNodeData()
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    nodes[i].Save(dsData);
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
            ClearGraph();
            ClearCache();

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
                    new BooleanNode(dsData.BooleanNodeData[i], graphViewer);
            }

            void LoadDialogueNodes()
            {
                dataCount = dsData.DialogueNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new DialogueNode(dsData.DialogueNodeData[i], graphViewer);
            }

            void LoadEndNodes()
            {
                dataCount = dsData.EndNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new EndNode(dsData.EndNodeData[i], graphViewer);
            }

            void LoadEventNodes()
            {
                dataCount = dsData.EventNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new EventNode(dsData.EventNodeData[i], graphViewer);
            }

            void LoadOptionBranchNodes()
            {
                dataCount = dsData.OptionBranchNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new OptionBranchNode(dsData.OptionBranchNodeData[i], graphViewer);
            }

            void LoadOptionRootNodes()
            {
                dataCount = dsData.OptionRootNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new OptionRootNode(dsData.OptionRootNodeData[i], graphViewer);
            }

            void LoadPreviewNodes()
            {
                dataCount = dsData.PreviewNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new PreviewNode(dsData.PreviewNodeData[i], graphViewer);
            }

            void LoadStartNodes()
            {
                dataCount = dsData.StartNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new StartNode(dsData.StartNodeData[i], graphViewer);
            }

            void LoadStoryNodes()
            {
                dataCount = dsData.StoryNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new StoryNode(dsData.StoryNodeData[i], graphViewer);
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
                if (portByPortGUID.TryGetValue(data.OutputPortGUID, out PortBase output))
                {
                    // Try to find the input port that matches the data's input port GUID.
                    if (portByPortGUID.TryGetValue(data.InputPortGUID, out PortBase input))
                    {
                        EdgeManager.Instance.Connect(output, input, data.PortType);
                    }
                }
            }
        }


        // ----------------------------- Add Cache -----------------------------
        /// <summary>
        /// Add the given node to the node cache.
        /// </summary>
        /// <param name="node">The node to add to the cache.</param>
        public void AddCacheNode(NodeBase node)
        {
            nodes.Add(node);
            nodesCount++;
        }


        /// <summary>
        /// Add the given edge to the edge cache.
        /// </summary>
        /// <param name="edge">The edge to add to the cache.</param>
        public void AddCacheEdge(EdgeBase edge)
        {
            edges.Add(edge);
            edgesCount++;
        }


        /// <summary>
        /// Add the given port to the port cache.
        /// </summary>
        /// <param name="port">The port to add to the cache.</param>
        public void AddCachePort(PortBase port)
        {
            if (!portByPortGUID.ContainsKey(port.name))
            {
                portByPortGUID.Add(key: port.name, value: port);
            }
            else
            {
                Debug.LogWarning("A port with the same cache key has already been added!");
            }
        }


        // ----------------------------- Remove Cache -----------------------------
        /// <summary>
        /// Remove the given node from the node cache.
        /// </summary>
        /// <param name="node">The node to remove from the cache.</param>
        public void RemoveCacheNode(NodeBase node)
        {
            nodes.Remove(node);
            nodesCount--;
        }


        /// <summary>
        /// Remove the given edge from the edge cache.
        /// </summary>
        /// <param name="node">The edge to remove from the cache.</param>
        public void RemoveCacheEdge(EdgeBase edge)
        {
            edges.Remove(edge);
            edgesCount--;
        }


        /// <summary>
        /// Remove the port with the give port name(GUID) from the port cache.
        /// </summary>
        /// <param name="node">The port to remove from the cache.</param>
        public void RemoveCachePort(PortBase port)
        {
            if (portByPortGUID.ContainsKey(port.name))
            {
                portByPortGUID.Remove(port.name);
            }
            else
            {
                Debug.LogWarning($"Can't remove the port {port} because it can't be found in the cache.");
            }
        }


        // ----------------------------- Clear Graph Elements -----------------------------
        /// <summary>
        /// Remove all the node and edge elements on the graph.
        /// </summary>
        void ClearGraph()
        {
            // Removes all edges.
            for (int i = 0; i < edgesCount; i++)
            {
                graphViewer.RemoveElement(edges[i]);
            }

            // Removes all nodes.
            for (int i = 0; i < nodesCount; i++)
            {
                graphViewer.RemoveElement(nodes[i]);
            }
        }


        /// <summary>
        /// Clear the internal cache.
        /// </summary>
        void ClearCache()
        {
            // Nodes
            nodes.Clear();
            nodesCount = 0;

            // Edges
            edges.Clear();
            edgesCount = 0;

            // Ports
            portByPortGUID.Clear();
        }
    }
}