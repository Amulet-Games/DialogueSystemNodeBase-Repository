using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        /// Internal cache of the ports that the handler is going to save.
        /// </summary>
        Dictionary<string, PortBase> portBaseByPortGUID;


        /// <summary>
        /// Counter of the node cache.
        /// </summary>
        int nodesCount;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's serialize handler class.
        /// </summary>
        /// <param name="graphViewer">Dialogue system's graph viewer module.</param>
        public SerializeHandler(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;

            nodes = new();
            portBaseByPortGUID = new();
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save all the edges and nodes that are on the graph.
        /// <para>SaveToDSDataEvent - Static Event</para>
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        public void SaveEdgesAndNodesAction(DialogueSystemData dsData)
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
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dsData.EdgeData.Clear();
            }

            void CreateSavables()
            {
                foreach (var pair in portBaseByPortGUID)
                {
                    // If the port is an input port or it's not connected.
                    if (pair.Value.IsInput() || !pair.Value.connected)
                        continue;

                    foreach (Edge connection in pair.Value.connections)
                    {
                        // Otherwise create a new edge data foreach connections the port has.
                        dsData.EdgeData.Add(new EdgeData
                        (
                            inputPortGUID: connection.input.name,
                            outputPortGUID: pair.Value.name
                        ));
                    }
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save the data to.</param>
        void SaveNodes(DialogueSystemData dsData)
        {
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dsData.ClearNodesData();
            }

            void CreateSavables()
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    nodes[i].SaveNode(dsData);
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edges and nodes data that were stored on the scriptable object asset.
        /// <para>LoadFromDsDataEvent - Static Event</para>
        /// </summary>
        /// <param name="dsData">The dialogue system data to load the data from.</param>
        public void LoadEdgesAndNodesAction(DialogueSystemData dsData)
        {
            ClearGraph();
            ClearCache();

            LoadNodes(dsData);
            LoadEdges(dsData);

            // Invoke edge loaded setup event.
            EdgesLoadingCompletedEvent.Invoke();

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

            LoadOptionTrackNodes();

            LoadOptionWindowNodes();

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

            void LoadOptionTrackNodes()
            {
                dataCount = dsData.OptionTrackNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new OptionTrackNode(dsData.OptionTrackNodeData[i], graphViewer);
            }

            void LoadOptionWindowNodes()
            {
                dataCount = dsData.OptionWindowNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                    new OptionWindowNode(dsData.OptionWindowNodeData[i], graphViewer);
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
            int dataCount = dsData.EdgeData.Count;
            for (int i = 0; i < dataCount; i++)
            {
                // Searching through the internal port's dictionary cache to find the output that the data is refering to.
                if (portBaseByPortGUID.TryGetValue(dsData.EdgeData[i].OutputPortGUID, out PortBase outputPort))
                {
                    // Searching through the internal port's dictionary cache to find the input that the data is refering to.
                    if (portBaseByPortGUID.TryGetValue(dsData.EdgeData[i].InputPortGUID, out PortBase inputPort))
                    {
                        // Connect and register callback to them.
                        outputPort.ConnectionLoadedAction(
                            graphViewer.ConnectPorts(outputPort, inputPort)
                        );
                    }
                }
            }
        }


        // ----------------------------- Add / Remove Node Services -----------------------------
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
        /// Remove the given node from the node cache.
        /// </summary>
        /// <param name="node">The node to remove from the cache.</param>
        public void RemoveCacheNode(NodeBase node)
        {
            nodes.Remove(node);
            nodesCount--;
        }


        // ----------------------------- Add / Remove Port Services -----------------------------
        /// <summary>
        /// Add the given port to the port cache.
        /// </summary>
        /// <param name="port">The port to add to the cache.</param>
        public void AddCachePort(PortBase port)
        {
            if (!portBaseByPortGUID.ContainsKey(port.name))
            {
                portBaseByPortGUID.Add(key: port.name, value: port);
            }
            else
            {
                Debug.LogWarning("A port with the same cache key has already been added!");
            }
        }


        /// <summary>
        /// Remove the port with the give port name(GUID) from the port cache.
        /// </summary>
        /// <param name="node">The port to remove from the cache.</param>
        public void RemoveCachePort(PortBase port)
        {
            if (portBaseByPortGUID.ContainsKey(port.name))
            {
                portBaseByPortGUID.Remove(port.name);
            }
            else
            {
                Debug.LogWarning($"Can't remove the port {port} because it can't be found in the cache.");
            }
        }


        // ----------------------------- Clear Graph Elements Tasks -----------------------------
        /// <summary>
        /// Find all the edges and nodes that are on the graph and delete them all.
        /// </summary>
        void ClearGraph()
        {
            // Removes all edges.
            var edges = graphViewer.edges.ToList();
            var edgesCount = edges.Count;
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
        /// Clear the internal cached lists.
        /// </summary>
        void ClearCache()
        {
            // Nodes
            nodes.Clear();
            nodesCount = 0;

            // Ports
            portBaseByPortGUID.Clear();
        }
    }
}