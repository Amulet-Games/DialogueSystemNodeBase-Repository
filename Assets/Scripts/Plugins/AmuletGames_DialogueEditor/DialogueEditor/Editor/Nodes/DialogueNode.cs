using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DialogueNode : BaseNode
    {
        [Header("Data")]
        public DialogueNodeData nodeData = new DialogueNodeData();

        [Header("Ports")]
        public Port inputPort;
        public Port continueOutputPort;

        public DialogueNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public DialogueNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView, DialogueNodeData loadedNodeData = null)
        {
            SetupRefs();

            SetupNodeDetails();

            SetupToolbarMenu();

            SetupButton_AddChoice();

            AddStyleSheet();

            AddPorts();

            NodeRefreshAll();

            void SetupRefs()
            {
                this.dsWindow = dsWindow;
                this.graphView = graphView;
            }

            void SetupNodeDetails()
            {
                title = "Dialogue";
                SetPosition(new Rect(position, defaultNodeSize));
            }

            void SetupToolbarMenu()
            {
                ToolbarMenu dropdownMenu;

                SetupMenu();

                RegisterMenuDropdownAction();

                AddMenuToContainer();

                void SetupMenu()
                {
                    dropdownMenu = DSBuiltInFieldsMaker.GetNewToolbarMenu("Add Content");
                }

                void RegisterMenuDropdownAction()
                {
                    void AddEmptyImagePreviewSegment() => DSSegmentMaker.GetNewSegment_ImagesPreview(this, nodeData.imagesPreviewSegments, nodeData.all, null);
                    void AddEmptySpeakerNameSegment() => DSSegmentMaker.GetNewSegment_SpeakerName(this, nodeData.speakerNameSegments, nodeData.all, null);
                    void AddEmptyTextlineSegment() => DSSegmentMaker.GetNewSegment_Textline(this, nodeData.textlineSegments, nodeData.all, null);

                    dropdownMenu.menu.AppendAction("Image", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddEmptyImagePreviewSegment));
                    dropdownMenu.menu.AppendAction("Name", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddEmptySpeakerNameSegment));
                    dropdownMenu.menu.AppendAction("Text Line", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddEmptyTextlineSegment));
                }

                void AddMenuToContainer()
                {
                    titleContainer.Add(dropdownMenu);
                }
            }

            void SetupButton_AddChoice()
            {
                void ButtonClickedAction() => AddChoiceEntry(null);

                Button addChoiceButton = DSBuiltInFieldsMaker.GetNewButton("Add Choice", ButtonClickedAction, DSStylesConfig.dialogueNode_AddChoiceButton);

                titleButtonContainer.Add(addChoiceButton);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.dialogueNodeStyle);
                styleSheets.Add(DSStylesConfig.dsSegmentsStyle);
            }

            void AddPorts()
            {
                inputPort = AddInputPort("Input", Port.Capacity.Multi, N_NodeType.Dialogue);
                continueOutputPort = AddOutputPort("Continue", Port.Capacity.Single, N_NodeType.Dialogue);
            }
        }

        #region Override.
        public override void ReloadLanguage()
        {
            int textlinesCount = nodeData.textlineSegments.Count;
            for (int i = 0; i < textlinesCount; i++)
            {
                TextlineSegment textline = nodeData.textlineSegments[i];

                textline.LG_Texts_Container.ReloadLanguage();
                textline.LG_AudioClips_Container.ReloadLanguage();
            }
        }
        #endregion

        #region Button Action.
        public void AddChoiceEntry(ChoiceEntry loadedChoiceEntry = null)
        {
            Port choiceEntryPort;
            ChoiceEntry newChoiceEntry;

            string port_Guid = Guid.NewGuid().ToString();

            CreateChoiceEntry();

            GetNewChoiceEntryPort();

            SetupButton_DeleteEntry();

            CheckLoadedChoiceEntry();

            NodeRefreshAll();

            void CreateChoiceEntry()
            {
                newChoiceEntry = new ChoiceEntry();
                newChoiceEntry.portGuid = port_Guid;

                nodeData.choiceEntries.Add(newChoiceEntry);
            }

            void GetNewChoiceEntryPort()
            {
                choiceEntryPort = AddEntryPort(port_Guid, Port.Capacity.Single, N_NodeType.Choice);
            }

            void SetupButton_DeleteEntry()
            {
                void ButtonClickedAction() => DeleteChoiceEntryPort(choiceEntryPort);

                Button deleteButton = DSBuiltInFieldsMaker.GetNewButton("X", ButtonClickedAction);
                
                choiceEntryPort.contentContainer.Add(deleteButton);
            }

            void CheckLoadedChoiceEntry()
            {
                if (loadedChoiceEntry != null)
                {
                    newChoiceEntry.LoadEntryValue(loadedChoiceEntry);

                    choiceEntryPort.name = loadedChoiceEntry.portGuid;
                }
            }
        }

        void DeleteChoiceEntryPort(Port port)
        {
            // Find and remove the choice port data that assoicated with the Ouput Port that we are going to delete.
            ChoiceEntry portData = nodeData.choiceEntries.Find(portData => portData.portGuid == port.name);
            nodeData.choiceEntries.Remove(portData);

            // Find the edge that were come from this Output Port and put them in a list.
            IEnumerable<Edge> portEdges = graphView.edges.ToList().Where(edge => edge.output == port);
        
            // If there is an edge inside the list, meaning we need to delete it,
            if (portEdges.Any())
            {
                // Get the edge from the list.
                Edge firstEdge = portEdges.First();

                // Disconnect itself from the input node that it's connecting.
                firstEdge.input.Disconnect(firstEdge);

                // Disconnect itself from the output node which this edge was originate from.
                firstEdge.output.Disconnect(firstEdge);

                // Finally we remove this edge from the graph.
                graphView.RemoveElement(firstEdge);
            }

            // Remove the Output Port from the node.
            DeletePortElement(port, N_PortContainerType.Output);
        }
        #endregion
    }
}