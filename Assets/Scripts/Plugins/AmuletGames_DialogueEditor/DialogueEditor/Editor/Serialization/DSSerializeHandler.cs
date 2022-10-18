using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

namespace AG
{
    public class DSSerializeHandler
    {
        /// <summary>
        /// The DS graph view that we use to save and load the graph and its elements from.
        /// </summary>
        DSGraphView graphView;


        /// <summary>
        /// Internal list for the nodes that are on the graph.
        /// </summary>
        List<DSNodeBase> nodes;


        /// <summary>
        /// Internal list for the edges that are on the graph.
        /// </summary>
        List<Edge> edges;


        /// <summary>
        /// Internal counter for the nodes that are on the graph.
        /// </summary>
        int nodesCount;


        /// <summary>
        /// Internal counter for the edges that are on the graph.
        /// </summary>
        int edgesCount;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's serialize handler
        /// </summary>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSSerializeHandler(DSGraphView graphView)
        {
            this.graphView = graphView;

            nodes = new List<DSNodeBase>();
            nodesCount = 0;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save all the edges and nodes that are on the graph.
        /// <para>SaveDataToContainerSOEvent - DS Static Event</para>
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that is used to store the saved data.</param>
        public void SaveEdgesAndNodesAction(DialogueContainerSO dialogueContainerSO)
        {
            RefreshInternalEdges();

            SaveEdges(dialogueContainerSO);
            SaveNodes(dialogueContainerSO);

            // Set dirty when all the changes involving ContainerSO is done.
            EditorUtility.SetDirty(dialogueContainerSO);
        }


        /// <summary>
        /// Save all the edges that are on the graph.
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that is used to store the saved data.</param>
        void SaveEdges(DialogueContainerSO dialogueContainerSO)
        {
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dialogueContainerSO.EdgeModelSavables.Clear();
            }

            void CreateSavables()
            {
                // Get edges that are at least connected to one node. 
                Edge[] connectedEdges = edges.Where(edge => edge.input.node != null).ToArray();

                for (int i = 0; i < connectedEdges.Length; i++)
                {
                    Port connectedOutputPort = connectedEdges[i].output;
                    Port connectedInputPort = connectedEdges[i].input;

                    DSEdgeModel edgeData = new DSEdgeModel
                    {
                        OutputNodeGuid = ((DSNodeBase)connectedOutputPort.node).NodeGuid,
                        InputNodeGuid = ((DSNodeBase)connectedInputPort.node).NodeGuid,

                        OutputPortGuid = connectedOutputPort.name,
                        InputPortGuid = connectedInputPort.name
                    };

                    dialogueContainerSO.EdgeModelSavables.Add(edgeData);
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that is used to store the saved data.</param>
        void SaveNodes(DialogueContainerSO dialogueContainerSO)
        {
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dialogueContainerSO.ClearNodeSavables();
            }

            void CreateSavables()
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    switch (nodes[i])
                    {
                        case DSBooleanNode node:
                            dialogueContainerSO.BooleanModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSEndNode node:
                            dialogueContainerSO.EndModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSEventNode node:
                            dialogueContainerSO.EventModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSOptionNode node:
                            dialogueContainerSO.OptionModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSPathNode node:
                            dialogueContainerSO.PathModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSStartNode node:
                            dialogueContainerSO.StartModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                        case DSStoryNode node:
                            dialogueContainerSO.StoryModelSavables.Add(node.Callback.Serializer.SaveNode());
                            break;
                    }
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edges and nodes data that were stored on the scriptable object asset.
        /// <para>LoadDataFromContainerSOEvent - DS Static Event</para>
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that were used to store the data.</param>
        public void LoadEdgesAndNodesAction(DialogueContainerSO dialogueContainerSO)
        {
            RefreshInternalEdges();

            ClearGraph();

            LoadNodes(dialogueContainerSO);
            LoadEdges(dialogueContainerSO);

            // Invoke edge loaded setup event.
            DSEdgeLoadedSetupEvent.Invoke();

            // Set dirty when all the changes involving ContainerSO is done.
            EditorUtility.SetDirty(dialogueContainerSO);
        }


        /// <summary>
        /// Load all the nodes' data and create them back on the graph.
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that were used to store the data.</param>
        void LoadNodes(DialogueContainerSO dialogueContainerSO)
        {
            // Temp variable that cache the count number of each list.
            int modelsCount;

            LoadBooleanNodes();

            LoadEndNodes();

            LoadEventNodes();

            LoadOptionNodes();

            LoadPathNodes();

            LoadStartNodes();

            LoadStoryNodes();

            void LoadBooleanNodes()
            {
                List<DSBooleanNodeModel> booleanNodeModels = dialogueContainerSO.BooleanModelSavables;
                modelsCount = booleanNodeModels.Count;
                for (int i = 0; i < modelsCount; i++)
                {
                    new DSBooleanNode(booleanNodeModels[i], graphView);
                }
            }

            void LoadEndNodes()
            {
                List<DSEndNodeModel> endNodeModels = dialogueContainerSO.EndModelSavables;
                modelsCount = endNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSEndNode(endNodeModels[i], graphView);
                }
            }

            void LoadEventNodes()
            {
                List<DSEventNodeModel> eventNodeModels = dialogueContainerSO.EventModelSavables;
                modelsCount = eventNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSEventNode(eventNodeModels[i], graphView);
                }
            }

            void LoadOptionNodes()
            {
                List<DSOptionNodeModel> optionNodeModels = dialogueContainerSO.OptionModelSavables;
                modelsCount = optionNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSOptionNode(optionNodeModels[i], graphView);
                }
            }

            void LoadPathNodes()
            {
                List<DSPathNodeModel> pathNodeModels = dialogueContainerSO.PathModelSavables;
                modelsCount = pathNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSPathNode(pathNodeModels[i], graphView);
                }
            }

            void LoadStartNodes()
            {
                List<DSStartNodeModel> startNodeModels = dialogueContainerSO.StartModelSavables;
                modelsCount = startNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSStartNode(startNodeModels[i], graphView);
                }
            }

            void LoadStoryNodes()
            {
                List<DSStoryNodeModel> storyNodeModels = dialogueContainerSO.StoryModelSavables;
                modelsCount = storyNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    new DSStoryNode(storyNodeModels[i], graphView);
                }
            }
        }


        /// <summary>
        /// Load all the edges' data and create them back on the graph.
        /// and attempt to connect the previously linked nodes again.
        /// </summary>
        /// <param name="dialogueContainerSO">Reference for the scriptable object asset that were used to store the data.</param>
        void LoadEdges(DialogueContainerSO dialogueContainerSO)
        {
            // Foreach node that we found in the graph
            for (int i = 0; i < nodesCount; i++)
            {
                // Search through the saved edge data list,
                // to find a edge data that has the same outputNodeGuid as the node[i]'s output port's name.
                DSEdgeModel[] matchedEdgeData = dialogueContainerSO.EdgeModelSavables
                    .Where(edgeData => edgeData.OutputNodeGuid == nodes[i].NodeGuid)
                    .ToArray();

                // Foreach matched output port name's edge data that we found
                for (int j = 0; j < matchedEdgeData.Length; j++)
                {
                    // Search through all the visual elements inside the output container of the node[i],
                    // get the ones that are Ports,
                    // search through the ports and find the ones that its name matches the edge data's output guid.
                    DSPortBase matchedOutputPort = nodes[i].outputContainer.Children()
                        .Where(visualElement => visualElement is DSPortBase)
                        .Cast<DSPortBase>()
                        .ToList()
                        .Find(port => port.name == matchedEdgeData[j].OutputPortGuid);


                    // Search through the nodes again to find the one its node Guid matches the edge data,
                    // Search through all the visual elements inside its input container,
                    // get the ones that are Ports,
                    // search through the ports and find the ones that its name matches the edge data's input guid.
                    DSPortBase matchedInputPort = nodes
                        .First(inputNode => inputNode.NodeGuid == matchedEdgeData[j].InputNodeGuid)
                        .inputContainer.Children()
                        .Where(visualElement => visualElement is DSPortBase)
                        .Cast<DSPortBase>()
                        .ToList()
                        .Find(port => port.name == matchedEdgeData[j].InputPortGuid);


                    // Connect the ports and retrieve the edge to register callbacks into it.
                    matchedOutputPort.ConnectedEdgeLoadedAction(graphView.ConnectPorts(matchedOutputPort, matchedInputPort));
                }
            }
        }


        // ----------------------------- Update Internal Nodes Services -----------------------------
        /// <summary>
        /// Add node to the internal node's list.
        /// </summary>
        /// <param name="node">The node to add to the serialize handler's internal list.</param>
        public void AddNodeToList(DSNodeBase node)
        {
            nodes.Add(node);
            nodesCount++;
        }


        /// <summary>
        /// Remove node from the internal node's list.
        /// </summary>
        /// <param name="node">The node to remove from the serialize handler's internal list.</param>
        public void RemoveNodeFromList(DSNodeBase node)
        {
            nodes.Remove(node);
            nodesCount--;
        }


        // ----------------------------- Update Internal Edges Tasks -----------------------------
        /// <summary>
        /// Update internal edges' list by getting all the edges that are on the graph.
        /// </summary>
        void RefreshInternalEdges()
        {
            edges = graphView.edges.ToList();
            edgesCount = edges.Count;
        }


        // ----------------------------- Clear Graph Elements Tasks -----------------------------
        /// <summary>
        /// Find all the edges and nodes that are on the graph and delete them all.
        /// </summary>
        void ClearGraph()
        {
            for (int i = 0; i < edgesCount; i++)
            {
                graphView.RemoveElement(edges[i]);
            }

            // Clear the nodes on graph.
            for (int i = 0; i < nodesCount; i++)
            {
                graphView.RemoveElement(nodes[i]);
            }

            // Clear the nodes inside the list.
            nodes.Clear();

            // Reset nodes count back to zero.
            nodesCount = 0;
        }
    }
}