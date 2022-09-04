using System.Collections.Generic;
using System.Linq;
using System;
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


        /// <summary>
        /// The action to invoke when the handler has finished loading all the nodes and edges.
        /// </summary>
        event Action PostLoadingSetupAction;


        // ----------------------------- Pre Setup -----------------------------
        /// <summary>
        /// Clear all the actions that have been registered to the PostLoadingSetupAction.
        /// </summary>
        public void ClearActions()
        {
            PostLoadingSetupAction = null;
        }


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
                dialogueContainerSO.StartModelSavables.Clear();
                dialogueContainerSO.DialogueModelSavables.Clear();
                dialogueContainerSO.OptionModelSavables.Clear();
                dialogueContainerSO.EventModelSavables.Clear();
                dialogueContainerSO.BranchModelSavables.Clear();
                dialogueContainerSO.EndModelSavables.Clear();
            }

            void CreateSavables()
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    switch (nodes[i])
                    {
                        case DSStartNode node:
                            dialogueContainerSO.StartModelSavables.Add(node.Serializer.SaveNode());
                            break;
                        case DSDialogueNode node:
                            dialogueContainerSO.DialogueModelSavables.Add(node.Serializer.SaveNode());
                            break;
                        case DSOptionNode node:
                            dialogueContainerSO.OptionModelSavables.Add(node.Serializer.SaveNode());
                            break;
                        case DSEventNode node:
                            dialogueContainerSO.EventModelSavables.Add(node.Serializer.SaveNode());
                            break;
                        case DSBranchNode node:
                            dialogueContainerSO.BranchModelSavables.Add(node.Serializer.SaveNode(edges));
                            break;
                        case DSEndNode node:
                            dialogueContainerSO.EndModelSavables.Add(node.Serializer.SaveNode());
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

            InvokePostLoadingSetupAction();

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

            LoadStartNodes();

            LoadDialogueNodes();

            LoadOptionNodes();

            LoadBranchNodes();

            LoadEventNodes();

            LoadEndNodes();

            void LoadStartNodes()
            {
                List<DSStartNodeModel> startNodeModels = dialogueContainerSO.StartModelSavables;
                modelsCount = startNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    DSStartNode newStartNode = DSNodesMaker.CreateStartNode(startNodeModels[i].SavedNodePosition, graphView);
                    newStartNode.Serializer.LoadNode(startNodeModels[i]);
                }
            }

            void LoadDialogueNodes()
            {
                List<DSDialogueNodeModel> dialogueNodeModels = dialogueContainerSO.DialogueModelSavables;
                modelsCount = dialogueNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    DSDialogueNode newDialogueNode = DSNodesMaker.CreateDialogueNode(dialogueNodeModels[i].SavedNodePosition, graphView);
                    newDialogueNode.Serializer.LoadNode(dialogueNodeModels[i]);
                }
            }

            void LoadOptionNodes()
            {
                List<DSOptionNodeModel> optionNodeModels = dialogueContainerSO.OptionModelSavables;
                modelsCount = optionNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    DSOptionNode newOptionNode = DSNodesMaker.CreateOptionNode(optionNodeModels[i].SavedNodePosition, graphView);
                    newOptionNode.Serializer.LoadNode(optionNodeModels[i]);
                }
            }

            void LoadBranchNodes()
            {
                List<DSBranchNodeModel> branchNodeModels = dialogueContainerSO.BranchModelSavables;
                modelsCount = branchNodeModels.Count;
                for (int i = 0; i < modelsCount; i++)
                {
                    DSBranchNode newBranchNode = DSNodesMaker.CreateBranchNode(branchNodeModels[i].SavedNodePosition, graphView);
                    newBranchNode.Serializer.LoadNode(branchNodeModels[i]);
                }
            }

            void LoadEventNodes()
            {
                List<DSEventNodeModel> eventNodeModels = dialogueContainerSO.EventModelSavables;
                modelsCount = eventNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    DSEventNode newEventNode = DSNodesMaker.CreateEventNode(eventNodeModels[i].SavedNodePosition, graphView);
                    newEventNode.Serializer.LoadNode(eventNodeModels[i]);
                }
            }

            void LoadEndNodes()
            {
                List<DSEndNodeModel> endNodeModels = dialogueContainerSO.EndModelSavables;
                modelsCount = endNodeModels.Count;

                for (int i = 0; i < modelsCount; i++)
                {
                    DSEndNode newEndNode = DSNodesMaker.CreateEndNode(endNodeModels[i].SavedNodePosition, graphView);
                    newEndNode.Serializer.LoadNode(endNodeModels[i]);
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
                List<DSEdgeModel> matchedEdgeData = dialogueContainerSO.EdgeModelSavables.Where(edgeData => edgeData.OutputNodeGuid == nodes[i].NodeGuid).ToList();

                // Search through all the visual elements inside the output container of the node[i],
                // and only get the ones that are Ports, and group them into a list.
                List<Port> allOutputPorts = nodes[i].outputContainer.Children().Where(visualElement => visualElement is Port).Cast<Port>().ToList();

                // Foreach matched output port name's edge data that we found
                for (int j = 0; j < matchedEdgeData.Count; j++)
                {
                    // Find its corresponding input node by searching through all the nodes again,
                    // and if we do found one, we can start the nodes linking process.
                    DSNodeBase connectingInputNode = nodes.First(inputNode => inputNode.NodeGuid == matchedEdgeData[j].InputNodeGuid);
                    if (connectingInputNode != null)
                    {
                        // From all the output ports that we have found
                        for (int k = 0; k < allOutputPorts.Count; k++)
                        {
                            // Find the correct output port that the edge data matches
                            if (allOutputPorts[k].name == matchedEdgeData[j].OutputPortGuid)
                            {
                                // Make an new edge to connect two ports together
                                LinkNodesTogether(allOutputPorts[k], (Port)connectingInputNode.inputContainer[0]);
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Recreate the edges that were connecting with the different nodes,
        /// <br>and attempt to reconnect them again by linking the selected two ports together.</br>
        /// </summary>
        /// <param name="outputPort">Selected output port for the edge to make connection.</param>
        /// <param name="inputPort">Selected input port for the edge to make connection.</param>
        void LinkNodesTogether(Port outputPort, Port inputPort)
        {
            Edge edge = new Edge()
            {
                output = outputPort,
                input = inputPort
            };

            edge.output.Connect(edge);
            edge.input.Connect(edge);

            graphView.Add(edge);
        }


        /// <summary>
        /// Invoke the PostLoadingSetupAction.
        /// </summary>
        void InvokePostLoadingSetupAction()
        {
            PostLoadingSetupAction?.Invoke();
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


        // ----------------------------- Register Action Services -----------------------------
        /// <summary>
        /// Register the action to PostLoadingSetupAction.
        /// </summary>
        /// <param name="action">The action to add to the PostLoadingSetupAction.</param>
        public void RegisterPostLoadingSetupAction(Action action)
        {
            PostLoadingSetupAction += action;
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