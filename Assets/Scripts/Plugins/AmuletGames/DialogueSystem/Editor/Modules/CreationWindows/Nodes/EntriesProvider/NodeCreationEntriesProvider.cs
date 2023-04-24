using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// A class that has implemented different types of node creation entries as properties,
    /// <br>and allows other classes to retrieve them.</br>
    /// </summary>
    public static partial class NodeCreationEntriesProvider
    {
        /// <summary>
        /// List of entries that have included every nodes that can be created on the graph,
        /// <br>no matter which elements are the nodes are belong to, by channels or default.</br>
        /// </summary>
        public static List<SearchTreeEntry> NodeCreationRequestEntries { get; private set; }


        /// <summary>
        /// Default node's input connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> DefaultNodeInputEntries { get; private set; }


        /// <summary>
        /// Default node's output connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> DefaultNodeOutputEntries { get; private set; }


        /// <summary>
        /// Option channel's output connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelOutputEntries { get; private set; }


        /// <summary>
        /// Option channel's input connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelInputEntries { get; private set; }


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            // Ancestor entry.
            SearchTreeGroupEntry ancestorEntry;

            // Child entry.
            SearchTreeEntry booleanNodeChildEntry;
            SearchTreeEntry dialogueNodeChildEntry;
            SearchTreeEntry endNodeChildEntry;
            SearchTreeEntry eventNodeChildEntry;
            SearchTreeEntry optionBranchNodeChildEntry;
            SearchTreeEntry optionRootNodeChildEntry;
            SearchTreeEntry previewNodeChildEntry;
            SearchTreeEntry startNodeChildEntry;
            SearchTreeEntry storyNodeChildEntry;

            SetupLocalEntryRefs();

            SetupNodeCreationRequestEntries();

            SetupDefaultNodeEntries();

            SetupOptionChannelEntries();

            void SetupLocalEntryRefs()
            {
                ancestorEntry = GetNewAncestorEntry();
                booleanNodeChildEntry = GetNewBooleanNodeChildEntry(entryLevel: 1);
                dialogueNodeChildEntry = GetNewDialogueNodeChildEntry(entryLevel: 1);
                endNodeChildEntry = GetNewEndNodeChildEntry(entryLevel: 1);
                eventNodeChildEntry = GetNewEventNodeChildEntry(entryLevel: 1);
                optionBranchNodeChildEntry = GetNewOptionBranchNodeChildEntry(entryLevel: 1);
                optionRootNodeChildEntry = GetNewOptionRootNodeChildEntry(entryLevel: 1);
                previewNodeChildEntry = GetNewPreviewNodeChildEntry(entryLevel: 1);
                startNodeChildEntry = GetNewStartNodeChildEntry(entryLevel: 1);
                storyNodeChildEntry = GetNewStoryNodeChildEntry(entryLevel: 1);
            }

            void SetupNodeCreationRequestEntries()
            {
                NodeCreationRequestEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Family entry.
                    GetNewNodesFamilyEntry(entryLevel: 1),

                    // Child entry.
                    GetNewBooleanNodeChildEntry(entryLevel:2),
                    GetNewDialogueNodeChildEntry(entryLevel: 2),
                    GetNewEndNodeChildEntry(entryLevel:2),
                    GetNewEventNodeChildEntry(entryLevel:2),
                    GetNewOptionBranchNodeChildEntry(entryLevel:2),
                    GetNewOptionRootNodeChildEntry(entryLevel:2),
                    GetNewPreviewNodeChildEntry(entryLevel: 2),
                    GetNewStartNodeChildEntry(entryLevel:2),
                    GetNewStoryNodeChildEntry(entryLevel:2),
                };
            }

            void SetupDefaultNodeEntries()
            {
                // Input
                DefaultNodeInputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    dialogueNodeChildEntry,
                    eventNodeChildEntry,
                    optionBranchNodeChildEntry,
                    previewNodeChildEntry,
                    startNodeChildEntry,
                    storyNodeChildEntry
                };
                // Output
                DefaultNodeOutputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    dialogueNodeChildEntry,
                    endNodeChildEntry,
                    eventNodeChildEntry,
                    optionRootNodeChildEntry,
                    previewNodeChildEntry,
                    storyNodeChildEntry
                };
            }

            void SetupOptionChannelEntries()
            {
                // Input
                OptionChannelInputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    optionRootNodeChildEntry
                };
                // Output
                OptionChannelOutputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    optionBranchNodeChildEntry
                };
            }
        }
    }
}