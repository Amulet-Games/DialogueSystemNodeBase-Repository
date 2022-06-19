using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class SerializeHandler
    {
        private DSGraphView graphView;

        private List<Edge> edges;
        private List<BaseNode> nodes;

        public SerializeHandler(DSGraphView graphView)
        {
            this.graphView = graphView;
        }

        #region Save.
        public void SaveEdgesAndNodes(DialogueContainerSO dialogueContainerSO)
        {
            RefreshNodesEdges();

            SaveEdges(dialogueContainerSO);
            SaveNodes(dialogueContainerSO);

            // Set dirty when all the changes involving ContainerSO is done.
            EditorUtility.SetDirty(dialogueContainerSO);
        }
        #endregion

        #region Save Edges.
        void SaveEdges(DialogueContainerSO dialogueContainerSO)
        {
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dialogueContainerSO.edgeSavables.Clear();
            }

            void CreateSavables()
            {
                // Get edges that are at least connected to one node. 
                Edge[] connectedEdges = edges.Where(edge => edge.input.node != null).ToArray();

                for (int i = 0; i < connectedEdges.Length; i++)
                {
                    Port connectedOutputPort = connectedEdges[i].output;
                    Port connectedInputPort = connectedEdges[i].input;

                    EdgeData edgeData = new EdgeData
                    {
                        outputNodeGuid = ((BaseNode)connectedOutputPort.node).nodeGuid,
                        inputNodeGuid = ((BaseNode)connectedInputPort.node).nodeGuid,

                        outputPortGuid = connectedOutputPort.name,
                        inputPortGuid = connectedInputPort.name
                    };

                    dialogueContainerSO.edgeSavables.Add(edgeData);
                }
            }
        }
        #endregion

        #region Save Nodes.
        void SaveNodes(DialogueContainerSO dialogueContainerSO)
        {
            ClearSavables();

            CreateSavables();

            void ClearSavables()
            {
                dialogueContainerSO.startNodeSavables.Clear();
                dialogueContainerSO.dialogueNodeSavables.Clear();
                dialogueContainerSO.choiceNodeSavables.Clear();
                dialogueContainerSO.eventNodeSavables.Clear();
                dialogueContainerSO.branchNodeSavables.Clear();
                dialogueContainerSO.endNodeSavables.Clear();
            }

            void CreateSavables()
            {
                int baseNodesCount = nodes.Count;
                for (int i = 0; i < baseNodesCount; i++)
                {
                    switch (nodes[i])
                    {
                        case StartNode node:
                            dialogueContainerSO.startNodeSavables.Add(SaveStartNode(node));
                            break;
                        case DialogueNode node:
                            dialogueContainerSO.dialogueNodeSavables.Add(SaveDialogueNode(node));
                            break;
                        case ChoiceNode node:
                            dialogueContainerSO.choiceNodeSavables.Add(SaveChoiceNode(node));
                            break;
                        case EventNode node:
                            dialogueContainerSO.eventNodeSavables.Add(SaveEventNode(node));
                            break;
                        case BranchNode node:
                            dialogueContainerSO.branchNodeSavables.Add(SaveBranchNode(node));
                            break;
                        case EndNode node:
                            dialogueContainerSO.endNodeSavables.Add(SaveEndNode(node));
                            break;
                    }
                }
            }
        }

        StartNodeData SaveStartNode(StartNode source)
        {
            StartNodeData newNodeData;

            CreateNewStartNodeData();

            SaveBaseData();

            SavePortData();

            return newNodeData;

            void CreateNewStartNodeData()
            {
                newNodeData = new StartNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.outputPortGuid = source.outputPort.name;
            }
        }

        DialogueNodeData SaveDialogueNode(DialogueNode source)
        {
            DialogueNodeData newNodeData;

            CreateNewDialogueNodeData();

            SaveBaseData();

            SavePortData();

            SetDataOrderID();

            SaveImagesSubData();

            SaveNamesSubData();

            SaveTextlineSubData();

            SaveChoicePortsData();

            return newNodeData;

            void CreateNewDialogueNodeData()
            {
                newNodeData = new DialogueNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.inputPortGuid = source.inputPort.name;
                newNodeData.continueOutputPortGuid = source.continueOutputPort.name;
            }

            void SetDataOrderID()
            {
                List<DSSegmentBase> allSegments = source.nodeData.all;
                for (int i = 0; i < allSegments.Count; i++)
                {
                    allSegments[i].orderID_IntContainer.Value = i;
                }
            }

            void SaveImagesSubData()
            {
                List<ImagesPreviewSegment> sourceImagesPreviewSegments = source.nodeData.imagesPreviewSegments;
                for (int i = 0; i < sourceImagesPreviewSegments.Count; i++)
                {
                    ImagesPreviewSegment newImagesPreviewSegment = new ImagesPreviewSegment();

                    // Save Order ID
                    sourceImagesPreviewSegments[i].orderID_IntContainer.SaveContainerValue(newImagesPreviewSegment.orderID_IntContainer);

                    // Save Avatar Sprite
                    sourceImagesPreviewSegments[i].l_avatar_SpriteContainer.SaveContainerValue(newImagesPreviewSegment.l_avatar_SpriteContainer);
                    sourceImagesPreviewSegments[i].r_avatar_SpriteContainer.SaveContainerValue(newImagesPreviewSegment.r_avatar_SpriteContainer);

                    // Add the new segment to the new dialogue node data.
                    newNodeData.imagesPreviewSegments.Add(newImagesPreviewSegment);
                }
            }

            void SaveNamesSubData()
            {
                List<SpeakerNameSegment> sourceSpeakerNameSegments = source.nodeData.speakerNameSegments;
                for (int i = 0; i < sourceSpeakerNameSegments.Count; i++)
                {
                    SpeakerNameSegment newSpeakerNameSegment = new SpeakerNameSegment();

                    // Save Order ID
                    sourceSpeakerNameSegments[i].orderID_IntContainer.SaveContainerValue(newSpeakerNameSegment.orderID_IntContainer);

                    // Save Name
                    sourceSpeakerNameSegments[i].name_TextsContainer.SaveContainerValue(newSpeakerNameSegment.name_TextsContainer);

                    // Add the new segment to the new dialogue node data.
                    newNodeData.speakerNameSegments.Add(newSpeakerNameSegment);
                }
            }

            void SaveTextlineSubData()
            {
                List<TextlineSegment> sourceTextlineSegments = source.nodeData.textlineSegments;
                for (int i = 0; i < sourceTextlineSegments.Count; i++)
                {
                    TextlineSegment newTextlineSegment = new TextlineSegment();

                    // Save Order ID
                    sourceTextlineSegments[i].orderID_IntContainer.SaveContainerValue(newTextlineSegment.orderID_IntContainer);

                    // Save Textline LGs
                    sourceTextlineSegments[i].LG_Texts_Container.SaveContainerValue(newTextlineSegment.LG_Texts_Container);
                    sourceTextlineSegments[i].LG_AudioClips_Container.SaveContainerValue(newTextlineSegment.LG_AudioClips_Container);

                    // Save CSV Guid
                    newTextlineSegment.csvGuid = sourceTextlineSegments[i].csvGuid;

                    // Add the new segment to the new dialogue node data.
                    newNodeData.textlineSegments.Add(newTextlineSegment);
                }
            }

            void SaveChoicePortsData()
            {
                List<ChoiceEntry> sourceChoiceEntries = source.nodeData.choiceEntries;
                for (int i = 0; i < sourceChoiceEntries.Count; i++)
                {
                    ChoiceEntry newChoiceEntries = new ChoiceEntry();

                    // Save the Port Guid
                    newChoiceEntries.portGuid = sourceChoiceEntries[i].portGuid;

                    // Set Both outputNodeGuid and inputNodeGuid as empty for now
                    newChoiceEntries.outputNodeGuid = "";
                    newChoiceEntries.inputNodeGuid = "";

                    // Foreach every edges we can find in the graph
                    for (int j = 0; j < edges.Count; j++)
                    {
                        // If this edge is currently connecting nodes togther, and the output port's it's node connecting from
                        // share the same name as the port that we are trying to save,
                        // means that we can find the node Guid of the two nodes that this edge is connecting.
                        if (edges[j].output.name == sourceChoiceEntries[i].portGuid)
                        {
                            // Save the two nodes' Guid in the data and break out from the loop.
                            newChoiceEntries.outputNodeGuid = ((BaseNode)edges[j].output.node).nodeGuid;
                            newChoiceEntries.inputNodeGuid = ((BaseNode)edges[j].input.node).nodeGuid;
                            break;
                        }
                    }

                    newNodeData.choiceEntries.Add(newChoiceEntries);
                }
            }
        }

        ChoiceNodeData SaveChoiceNode(ChoiceNode source)
        {
            ChoiceNodeData newNodeData;

            CreateNewChoiceNodeData();

            SaveBaseData();

            SavePortData();

            Save_LG_Containers();

            SaveUnmetCondHandleType();

            SaveConditionModifiers();

            return newNodeData;

            void CreateNewChoiceNodeData()
            {
                newNodeData = new ChoiceNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.inputPortGuid = source.inputPort.name;
                newNodeData.outputPortGuid = source.outputPort.name;
            }

            void Save_LG_Containers()
            {
                source.nodeData.LG_Texts_Container.SaveContainerValue(newNodeData.LG_Texts_Container);
                source.nodeData.LG_AudioClips_Container.SaveContainerValue(newNodeData.LG_AudioClips_Container);
            }

            void SaveUnmetCondHandleType()
            {
                newNodeData.unmetConditionDisplayType_EnumContainer = source.nodeData.unmetConditionDisplayType_EnumContainer;
            }

            void SaveConditionModifiers()
            {
                List<ConditionModifier> sourceConditionModifiers = source.nodeData.conditionModifiers;
                for (int i = 0; i < sourceConditionModifiers.Count; i++)
                {
                    ConditionModifier newConditionModifier = new ConditionModifier();
                    
                    // Save Modifier's Data
                    newConditionModifier.conditionName_TextsContainer = sourceConditionModifiers[i].conditionName_TextsContainer;
                    newConditionModifier.compareNumber_FloatContainer = sourceConditionModifiers[i].compareNumber_FloatContainer;
                    newConditionModifier.compareMethType_EnumContainer = sourceConditionModifiers[i].compareMethType_EnumContainer;

                    // Add the new modifier to the new condition node data.
                    newNodeData.conditionModifiers.Add(newConditionModifier);
                }
            }
        }

        BranchNodeData SaveBranchNode(BranchNode source)
        {
            BranchNodeData newNodeData;

            CreateNewBranchNodeData();

            SaveBaseData();

            SavePortData();

            SaveBranchingNodesGuid();

            SaveConditionModifiers();

            return newNodeData;

            void CreateNewBranchNodeData()
            {
                newNodeData = new BranchNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.inputPortGuid = source.inputPort.name;
                newNodeData.trueOutputPortGuid = source.trueOutputPort.name;
                newNodeData.falseOutputPortGuid = source.falseOutputPort.name;
            }

            void SaveBranchingNodesGuid()
            {
                // Find the edges that are connecting to this branch node's output ports.
                // Two edges for either True or False
                Edge trueOutputEdge = edges.FirstOrDefault(edge => edge.output.node == source && edge.output.portName == "True");
                Edge falseOutputEdge = edges.FirstOrDefault(edge => edge.output.node == source && edge.output.portName == "False");

                // Save their connecting input node's guid if edges were found.
                if (trueOutputEdge != null)
                {
                    newNodeData.trueInputNodeGuid = ((BaseNode)trueOutputEdge.input.node).nodeGuid;
                }
                else
                {
                    newNodeData.trueInputNodeGuid = "";
                }
                
                if (falseOutputEdge != null)
                {
                    newNodeData.falseInputNodeGuid = ((BaseNode)falseOutputEdge.input.node).nodeGuid;
                }
                else
                {
                    newNodeData.falseInputNodeGuid = "";
                }
            }

            void SaveConditionModifiers()
            {
                List<ConditionModifier> sourceConditionModifiers = source.nodeData.conditionModifiers;
                for (int i = 0; i < sourceConditionModifiers.Count; i++)
                {
                    ConditionModifier newConditionModifier = new ConditionModifier();

                    // Save Modifier's Data
                    sourceConditionModifiers[i].conditionName_TextsContainer.SaveContainerValue(newConditionModifier.conditionName_TextsContainer);
                    sourceConditionModifiers[i].compareNumber_FloatContainer.SaveContainerValue(newConditionModifier.compareNumber_FloatContainer);
                    sourceConditionModifiers[i].compareMethType_EnumContainer.SaveContainerValue(newConditionModifier.compareMethType_EnumContainer);

                    // Add the new modifier to the new condition node data.
                    newNodeData.conditionModifiers.Add(newConditionModifier);
                }
            }
        }
        
        EventNodeData SaveEventNode(EventNode source)
        {
            EventNodeData newNodeData;

            CreateNewEventNodeData();

            SaveBaseData();

            SavePortData();

            SetDataOrderID();

            SaveBasicEventModifiers();

            SaveScriptableEventModifiers();

            return newNodeData;

            void CreateNewEventNodeData()
            {
                newNodeData = new EventNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.inputPortGuid = source.inputPort.name;
                newNodeData.outputPortGuid = source.outputPort.name;
            }

            void SetDataOrderID()
            {
                List<DSModifierBase> allModifiers = source.nodeData.all;
                for (int i = 0; i < allModifiers.Count; i++)
                {
                    allModifiers[i].orderID_IntContainer.Value = i;
                }
            }

            void SaveBasicEventModifiers()
            {
                List<BasicEventModifier> sourceBasicEventModifiers = source.nodeData.basicEventModifiers;
                for (int i = 0; i < sourceBasicEventModifiers.Count; i++)
                {
                    BasicEventModifier newBasicEventModifier = new BasicEventModifier();

                    // Save Order ID
                    sourceBasicEventModifiers[i].orderID_IntContainer.SaveContainerValue(newBasicEventModifier.orderID_IntContainer);

                    // Save Modifier's Data
                    sourceBasicEventModifiers[i].eventName_TextsContainer.SaveContainerValue(newBasicEventModifier.eventName_TextsContainer);
                    sourceBasicEventModifiers[i].desireNumber_FloatContainer.SaveContainerValue(newBasicEventModifier.desireNumber_FloatContainer);
                    sourceBasicEventModifiers[i].basicEventType_EnumContainer.SaveContainerValue(newBasicEventModifier.basicEventType_EnumContainer);

                    // Add the new modifier to the new event node data.
                    newNodeData.basicEventModifiers.Add(newBasicEventModifier);
                }
            }

            void SaveScriptableEventModifiers()
            {
                List<ScriptableEventModifier> sourceScriptableEventModifiers = source.nodeData.scriptableEventModifiers;
                for (int i = 0; i < sourceScriptableEventModifiers.Count; i++)
                {
                    ScriptableEventModifier newScriptableEventModifier = new ScriptableEventModifier();

                    // Save Order ID
                    sourceScriptableEventModifiers[i].orderID_IntContainer.SaveContainerValue(newScriptableEventModifier.orderID_IntContainer);

                    // Save Modifier's Data
                    sourceScriptableEventModifiers[i].dialEventSO_Container.SaveContainerValue(newScriptableEventModifier.dialEventSO_Container);

                    // Add the new modifier to the new event node data.
                    newNodeData.scriptableEventModifiers.Add(newScriptableEventModifier);
                }
            }
        }

        EndNodeData SaveEndNode(EndNode source)
        {
            EndNodeData newNodeData;

            CreateNewEndNodeData();

            SaveBaseData();

            SavePortData();

            SaveGraphEndHandleType();

            return newNodeData;

            void CreateNewEndNodeData()
            {
                newNodeData = new EndNodeData();
            }

            void SaveBaseData()
            {
                newNodeData.nodeGuid = source.nodeGuid;
                newNodeData.position = source.GetPosition().position;
            }

            void SavePortData()
            {
                newNodeData.inputPortGuid = source.inputPort.name;
            }

            void SaveGraphEndHandleType()
            {
                source.nodeData.graphEndHandleType_EnumContainer.SaveContainerValue(newNodeData.graphEndHandleType_EnumContainer);
            }
        }
        #endregion

        #region Load.
        public void LoadEdgesAndNodes(DialogueContainerSO dialogueContainerSO)
        {
            RefreshNodesEdges();

            ClearGraph();

            LoadNodes(dialogueContainerSO);

            RefreshNodes();

            LoadEdges(dialogueContainerSO);

            // Set dirty when all the changes involving ContainerSO is done.
            EditorUtility.SetDirty(dialogueContainerSO);
        }
        #endregion

        #region Load Nodes.
        void LoadNodes(DialogueContainerSO dialogueContainerSO)
        {
            // Temp variable that cache the count number of each list.
            int dataCount;

            LoadStartNodes();

            LoadDialogueNodes();

            LoadChoiceNodes();

            LoadBranchNodes();

            LoadEventNodes();

            LoadEndNodes();

            void LoadStartNodes()
            {
                List<StartNodeData> startNodeData = dialogueContainerSO.startNodeSavables;
                dataCount = startNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadStartNode(startNodeData[i]);
                }
            }

            void LoadDialogueNodes()
            {
                List<DialogueNodeData> dialogueNodeData = dialogueContainerSO.dialogueNodeSavables;
                dataCount = dialogueNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadDialogueNode(dialogueNodeData[i]);
                }
            }

            void LoadChoiceNodes()
            {
                List<ChoiceNodeData> choiceNodeData = dialogueContainerSO.choiceNodeSavables;
                dataCount = choiceNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadChoiceNode(choiceNodeData[i]);
                }
            }

            void LoadBranchNodes()
            {
                List<BranchNodeData> branchNodeData = dialogueContainerSO.branchNodeSavables;
                dataCount = branchNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadBranchNode(branchNodeData[i]);
                }
            }

            void LoadEventNodes()
            {
                List<EventNodeData> eventNodeData = dialogueContainerSO.eventNodeSavables;
                dataCount = eventNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadEventNode(eventNodeData[i]);
                }
            }

            void LoadEndNodes()
            {
                List<EndNodeData> endNodeData = dialogueContainerSO.endNodeSavables;
                dataCount = endNodeData.Count;

                for (int i = 0; i < dataCount; i++)
                {
                    LoadEndNode(endNodeData[i]);
                }
            }
        }

        void LoadStartNode(StartNodeData source)
        {
            StartNode newStartNode;

            CreateNewStartNode();

            LoadBaseData();

            LoadPortData();

            void CreateNewStartNode()
            {
                newStartNode = graphView.CreateStartNode(source.position);
            }

            void LoadBaseData()
            {
                newStartNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newStartNode.outputPort.name = source.outputPortGuid;
            }
        }

        void LoadDialogueNode(DialogueNodeData source)
        {
            DialogueNode newDialogueNode;

            List<DSSegmentBase> savableSegments = new List<DSSegmentBase>();

            CreateNewDialogueNode();

            LoadBaseData();

            LoadPortData();

            SortSegmentsOrderByID();

            LoadSegmentsInOrder();

            LoadChoicePorts();

            void CreateNewDialogueNode()
            {
                newDialogueNode = graphView.CreateDialogueNode(source.position);
            }

            void LoadBaseData()
            {
                newDialogueNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newDialogueNode.inputPort.name = source.inputPortGuid;
                newDialogueNode.continueOutputPort.name = source.continueOutputPortGuid;
            }

            void SortSegmentsOrderByID()
            {
                savableSegments.AddRange(source.imagesPreviewSegments);
                savableSegments.AddRange(source.speakerNameSegments);
                savableSegments.AddRange(source.textlineSegments);

                savableSegments.Sort(delegate (DSSegmentBase x, DSSegmentBase y)
                {
                    return x.orderID_IntContainer.Value.CompareTo(y.orderID_IntContainer.Value);
                });
            }

            void LoadSegmentsInOrder()
            {
                // Load segments by sorted order.

                int segmentsCount = savableSegments.Count;
                for (int i = 0; i < segmentsCount; i++)
                {
                    switch (savableSegments[i])
                    {
                        case ImagesPreviewSegment imagePreviewSegment:
                            DSSegmentMaker.GetNewSegment_ImagesPreview(newDialogueNode, newDialogueNode.nodeData.imagesPreviewSegments, newDialogueNode.nodeData.all, imagePreviewSegment);
                            break;
                        case SpeakerNameSegment speakerNameSegment:
                            DSSegmentMaker.GetNewSegment_SpeakerName(newDialogueNode, newDialogueNode.nodeData.speakerNameSegments, newDialogueNode.nodeData.all, speakerNameSegment);
                            break;
                        case TextlineSegment textlineSegment:
                            DSSegmentMaker.GetNewSegment_Textline(newDialogueNode, newDialogueNode.nodeData.textlineSegments, newDialogueNode.nodeData.all, textlineSegment);
                            break;
                    }
                }
            }

            void LoadChoicePorts()
            {
                // Foreach choice ports' data saved in dialogue node data.
                for (int i = 0; i < source.choiceEntries.Count; i++)
                {
                    // Create a new choice port on the new dialogue node,
                    // and overwrite the port's data from the loaded node data.

                    newDialogueNode.AddChoiceEntry(source.choiceEntries[i]);
                }
            }
        }

        void LoadChoiceNode(ChoiceNodeData source)
        {
            ChoiceNode newChoiceNode;

            CreateNewChoiceNode();

            LoadBaseData();

            LoadPortData();

            Load_LG_Containers();

            LoadUnmetConditionDisplayOption();

            LoadConditionModifiers();

            void CreateNewChoiceNode()
            {
                newChoiceNode = graphView.CreateChoiceNode(source.position);
            }

            void LoadBaseData()
            {
                newChoiceNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newChoiceNode.inputPort.name = source.inputPortGuid;
                newChoiceNode.outputPort.name = source.outputPortGuid;
            }

            void Load_LG_Containers()
            {
                newChoiceNode.nodeData.LG_Texts_Container.LoadContainerValue(source.LG_Texts_Container);
                newChoiceNode.nodeData.LG_AudioClips_Container.LoadContainerValue(source.LG_AudioClips_Container);
            }

            void LoadUnmetConditionDisplayOption()
            {
                newChoiceNode.nodeData.unmetConditionDisplayType_EnumContainer.LoadContainerValue(source.unmetConditionDisplayType_EnumContainer);
            }

            void LoadConditionModifiers()
            {
                // Foreach modifiers that saved in node data
                for (int i = 0; i < source.conditionModifiers.Count; i++)
                {
                    // Create a new modifier within the newly created node(Branch node),
                    // and match its data to the one that is in node data.

                    DSModifiersMaker.GetNewModifier_Condition(newChoiceNode, source.conditionModifiers[i]);
                }

                newChoiceNode.ToggleUnmetConditionDisplayOptionVisible();
            }
        }

        void LoadBranchNode(BranchNodeData source)
        {
            BranchNode newBranchNode;

            CreateNewBranchNode();

            LoadBaseData();

            LoadPortData();

            LoadConditionModifiers();

            void CreateNewBranchNode()
            {
                newBranchNode = graphView.CreateBranchNode(source.position);
            }

            void LoadBaseData()
            {
                newBranchNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newBranchNode.inputPort.name = source.inputPortGuid;
                newBranchNode.trueOutputPort.name = source.trueOutputPortGuid;
                newBranchNode.falseOutputPort.name = source.falseOutputPortGuid;
            }

            void LoadConditionModifiers()
            {
                // Foreach modifiers that saved in node data
                for (int i = 0; i < source.conditionModifiers.Count; i++)
                {
                    // Create a new modifier within the newly created node(Branch node),
                    // and match its data to the one that is in node data.

                    DSModifiersMaker.GetNewModifier_Condition(newBranchNode, newBranchNode.nodeData.conditionModifiers, source.conditionModifiers[i]);
                }
            }
        }

        void LoadEventNode(EventNodeData source)
        {
            EventNode newEventNode;

            List<DSModifierBase> savableModifiers = new List<DSModifierBase>();

            CreateNewEventNode();

            LoadBaseData();

            LoadPortData();

            SortModifiersOrderByID();

            LoadModifiersInOrder();

            void CreateNewEventNode()
            {
                newEventNode = graphView.CreateEventNode(source.position);
            }

            void LoadBaseData()
            {
                newEventNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newEventNode.inputPort.name = source.inputPortGuid;
                newEventNode.outputPort.name = source.outputPortGuid;
            }

            void SortModifiersOrderByID()
            {
                savableModifiers.AddRange(source.basicEventModifiers);
                savableModifiers.AddRange(source.scriptableEventModifiers);

                savableModifiers.Sort(delegate (DSModifierBase x, DSModifierBase y)
                {
                    return x.orderID_IntContainer.Value.CompareTo(y.orderID_IntContainer.Value);
                });
            }

            void LoadModifiersInOrder()
            {
                // Load modifiers by sorted order.

                int modifiersCount = savableModifiers.Count;
                for (int i = 0; i < modifiersCount; i++)
                {
                    switch (savableModifiers[i])
                    {
                        case BasicEventModifier imagePreviewSegment:
                            DSModifiersMaker.GetNewModifier_BasicEvent(newEventNode, imagePreviewSegment);
                            break;
                        case ScriptableEventModifier speakerNameSegment:
                            DSModifiersMaker.GetNewModifier_ScriptableEvent(newEventNode, speakerNameSegment);
                            break;
                    }
                }
            }
        }

        void LoadEndNode(EndNodeData source)
        {
            EndNode newEndNode;

            CreateNewEndNode();

            LoadBaseData();

            LoadPortData();

            LoadGraphEndHandleType();

            void CreateNewEndNode()
            {
                newEndNode = graphView.CreateEndNode(source.position);
            }

            void LoadBaseData()
            {
                newEndNode.nodeGuid = source.nodeGuid;
            }

            void LoadPortData()
            {
                newEndNode.inputPort.name = source.inputPortGuid;
            }

            void LoadGraphEndHandleType()
            {
                newEndNode.nodeData.graphEndHandleType_EnumContainer.LoadContainerValue(source.graphEndHandleType_EnumContainer);
            }
        }
        #endregion

        #region Load Edges / Linking.
        void LoadEdges(DialogueContainerSO dialogueContainerSO)
        {
            // Foreach node that we found in the graph
            int nodesCount = nodes.Count;
            for (int i = 0; i < nodesCount; i++)
            {
                // Search through the saved edge data list,
                // to find a edge data that has the same outputNodeGuid as the node[i]'s output port's name.
                List<EdgeData> matchedEdgeData = dialogueContainerSO.edgeSavables.Where(edgeData => edgeData.outputNodeGuid == nodes[i].nodeGuid).ToList();

                // Search through all the visual elements inside the output container of the node[i],
                // and only get the ones that are Ports, and group them into a list.
                List<Port> allOutputPorts = nodes[i].outputContainer.Children().Where(visualElement => visualElement is Port).Cast<Port>().ToList();

                // Foreach matched output port name's edge data that we found
                for (int j = 0; j < matchedEdgeData.Count; j++)
                {
                    // Find its corresponding input node by searching through all the nodes again,
                    // and if we do found one, we cab start the nodes linking process.
                    BaseNode connectingInputNode = nodes.First(inputNode => inputNode.nodeGuid == matchedEdgeData[j].inputNodeGuid);
                    if (connectingInputNode != null)
                    {
                        // From all the output ports that we have found
                        for (int k = 0; k < allOutputPorts.Count; k++)
                        {
                            // Find the correct output port that the edge data matches
                            if (allOutputPorts[k].name == matchedEdgeData[j].outputPortGuid)
                            {
                                // Make an new edge to connect two ports together
                                LinkNodesTogether(allOutputPorts[k], (Port)connectingInputNode.inputContainer[0]);
                            }
                        }
                    }
                }
            }
        }

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
        #endregion

        #region Refresh.
        void RefreshNodesEdges()
        {
            RefreshNodes();
            RefreshEdges();
        }

        void RefreshNodes()
        {
            nodes = graphView.nodes.ToList().Where(node => node is BaseNode).Cast<BaseNode>().ToList();
        }

        void RefreshEdges()
        {
            edges = graphView.edges.ToList();
        }

        void ClearGraph()
        {
            // Find all the edges and nodes in the graph and delete them all.

            int edgesCount = edges.Count;
            for (int i = 0; i < edgesCount; i++)
            {
                graphView.RemoveElement(edges[i]);
            }

            int nodesCount = nodes.Count;
            for (int i = 0; i < nodesCount; i++)
            {
                graphView.RemoveElement(nodes[i]);
            }
        }
        #endregion
    }
}