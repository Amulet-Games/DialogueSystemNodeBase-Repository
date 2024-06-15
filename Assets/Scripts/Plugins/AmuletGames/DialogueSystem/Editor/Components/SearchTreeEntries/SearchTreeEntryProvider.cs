using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// A class that stores all the static search tree entries that will be used in the dialogue system window.
    /// </summary>
    public static class SearchTreeEntryProvider
    {
        /// <summary>
        /// Is this class has already been setup?
        /// </summary>
        static bool isSetup;


        /// <summary>
        /// Reference of the empty search tree entry icon.
        /// <br>This will create a space on each search tree entry next to their name text.</br>
        /// </summary>
        public static Texture2D EmptySearchTreeEntryIcon;


        /// <summary>
        /// Reference of the node creation request search window's search tree entries.
        /// </summary>
        public static List<SearchTreeEntry> NodeCreationRequestSearchTreeEntries;


        /// <summary>
        /// Reference of the edge connector search window's input search tree entries.
        /// </summary>
        public static List<SearchTreeEntry> EdgeConnectorInputSearchTreeEntries;


        /// <summary>
        /// Reference of the edge connector search window's output search tree entries.
        /// </summary>
        public static List<SearchTreeEntry> EdgeConnectorOutputSearchTreeEntries;


        /// <summary>
        /// Reference of the option edge connector search window's input search tree entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionEdgeConnectorInputSearchTreeEntries;


        /// <summary>
        /// Reference of the edge connector search window's output search tree entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionEdgeConnectorOutputSearchTreeEntries;


        /// <summary>
        /// Reference of the condition modifier second variable none search tree entry.
        /// </summary>
        public static SearchTreeEntry ConditionModifierSecondVariableNoneSearchTreeEntry;


        /// <summary>
        /// Reference of the condition modifier second value none search tree entry.
        /// </summary>
        public static SearchTreeEntry ConditionModifierSecondValueNoneSearchTreeEntry;


        /// <summary>
        /// The title search tree entry index.
        /// </summary>
        public const int TITLE_ENTRY_LEVEL_INDEX = 0;


        /// <summary>
        /// Setup for the search tree entry provider class.
        /// </summary>
        public static void Setup()
        {
            if (isSetup)
                return;

            CreateEmptySearchTreeEntryIcon();

            CreateNodeCreationRequestSearchTreeEntries();

            CreateEdgeConnectorSearchTreeEntries();

            isSetup = true;
        }


        /// <summary>
        /// Create the empty search tree entry icon.
        /// </summary>
        static void CreateEmptySearchTreeEntryIcon()
        {
            EmptySearchTreeEntryIcon = new Texture2D(1, 1);
            EmptySearchTreeEntryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
            EmptySearchTreeEntryIcon.Apply();
        }


        /// <summary>
        /// Create the search tree entries that are related to the node creation request search window.
        /// </summary>
        static void CreateNodeCreationRequestSearchTreeEntries()
        {
            var creationRequestEntry = SearchTreeGroupEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeGroupEntry_NodeCreationRequest_CreationRequest_LabelText,
                level: TITLE_ENTRY_LEVEL_INDEX
            );
            var newNodeEntry = SearchTreeGroupEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeGroupEntry_NodeCreationRequest_NewNode_LabelText,
                level: creationRequestEntry.NextLevel()
            );

            NodeCreationRequestSearchTreeEntries = new()
            {
                creationRequestEntry,
                newNodeEntry,
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_BooleanNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Boolean)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_DialogueNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Dialogue)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_EndNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.End)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_EventNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Event)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_OptionBranchNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.OptionBranch)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_OptionRootNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.OptionRoot)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_PreviewNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Preview)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_StartNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Start)
                ),
                SearchTreeEntryPresenter.CreateEntry
                (
                    text: StringConfig.SearchTreeEntry_Common_StoryNode_LabelText,
                    icon: EmptySearchTreeEntryIcon,
                    level: newNodeEntry.NextLevel(),
                    userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Story)
                ),
            };
        }


        /// <summary>
        /// Create the search tree entries that are related to the edge connector search window.
        /// </summary>
        static void CreateEdgeConnectorSearchTreeEntries()
        {
            var edgeConnectorEntry = SearchTreeGroupEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeGroupEntry_EdgeConnector_EdgeConnector_LabelText,
                level: TITLE_ENTRY_LEVEL_INDEX
            );
            var booleanNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_BooleanNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Boolean)
            );
            var dialogueNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_DialogueNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Dialogue)
            );
            var endNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_EndNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.End)
            );
            var eventNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_EventNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Event)
            );
            var optionBranchNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_OptionBranchNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.OptionBranch)
            );// 
            var optionRootNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_OptionRootNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.OptionRoot)
            );
            var previewNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_PreviewNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Preview)
            );
            var startNodeSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.SearchTreeEntry_Common_StartNode_LabelText,
                icon: EmptySearchTreeEntryIcon,
                level: edgeConnectorEntry.NextLevel(),
                userData: new NodeTypeSearchTreeEntryUserData(nodeType: Node.Start)
            );

            EdgeConnectorInputSearchTreeEntries = new()
            {
                edgeConnectorEntry,

                booleanNodeSearchTreeEntry,
                dialogueNodeSearchTreeEntry,
                eventNodeSearchTreeEntry,
                optionBranchNodeSearchTreeEntry,
                previewNodeSearchTreeEntry,
                startNodeSearchTreeEntry
            };
            EdgeConnectorOutputSearchTreeEntries = new()
            {
                edgeConnectorEntry,

                booleanNodeSearchTreeEntry,
                dialogueNodeSearchTreeEntry,
                endNodeSearchTreeEntry,
                eventNodeSearchTreeEntry,
                optionRootNodeSearchTreeEntry,
                previewNodeSearchTreeEntry,
            };

            OptionEdgeConnectorInputSearchTreeEntries = new()
            {
                edgeConnectorEntry,
                optionRootNodeSearchTreeEntry
            };
            OptionEdgeConnectorOutputSearchTreeEntries = new()
            {
                edgeConnectorEntry,
                optionBranchNodeSearchTreeEntry
            };
        }
    }
}