using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    /// <summary>
    /// A class that has implemented different types of node creation entries as properties,
    /// <br>and allows other classes to retrieve them.</br>
    /// </summary>
    public static class DSNodeCreationEntriesProvider
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
        /// Option channel's entry connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelEntryEntries { get; private set; }


        /// <summary>
        /// Option channel's track connector creation entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelTrackEntries { get; private set; }


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, used to initialize internal fields.
        /// </summary>
        public static void Setup()
        {
            // Ancestor entry.
            SearchTreeGroupEntry ancestorEntry;

            // Child entry.
            SearchTreeEntry booleanNodeChildEntry;
            SearchTreeEntry endNodeChildEntry;
            SearchTreeEntry eventNodeChildEntry;
            SearchTreeEntry optionNodeChildEntry;
            SearchTreeEntry pathNodeChildEntry;
            SearchTreeEntry startNodeChildEntry;
            SearchTreeEntry storyNodeChildEntry;

            SetupLocalEntryRefs();

            SetupNodeCreationRequestEntries();

            SetupDefaultNodeEntries();

            SetupOptionChannelEntries();

            void SetupLocalEntryRefs()
            {
                ancestorEntry = DSNodeCreationEntriesMaker.GetNewAncestorEntry();
                booleanNodeChildEntry = DSNodeCreationEntriesMaker.GetNewBooleanNodeChildEntry(1);
                endNodeChildEntry = DSNodeCreationEntriesMaker.GetNewEndNodeChildEntry(1);
                eventNodeChildEntry = DSNodeCreationEntriesMaker.GetNewEventNodeChildEntry(1);
                optionNodeChildEntry = DSNodeCreationEntriesMaker.GetNewOptionNodeChildEntry(1);
                pathNodeChildEntry = DSNodeCreationEntriesMaker.GetNewPathNodeChildEntry(1);
                startNodeChildEntry = DSNodeCreationEntriesMaker.GetNewStartNodeChildEntry(1);
                storyNodeChildEntry = DSNodeCreationEntriesMaker.GetNewStoryNodeChildEntry(1);
            }

            void SetupNodeCreationRequestEntries()
            {
                NodeCreationRequestEntries = new List<SearchTreeEntry>
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Family entry.
                    DSNodeCreationEntriesMaker.GetNewNodesFamilyEntry(1),

                    // Child entry.
                    DSNodeCreationEntriesMaker.GetNewBooleanNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewEndNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewEventNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewOptionNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewPathNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewStartNodeChildEntry(2),
                    DSNodeCreationEntriesMaker.GetNewStoryNodeChildEntry(2),
                };
            }

            void SetupDefaultNodeEntries()
            {
                // Input
                DefaultNodeInputEntries = new List<SearchTreeEntry>()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    eventNodeChildEntry,
                    optionNodeChildEntry,
                    startNodeChildEntry,
                    storyNodeChildEntry
                };
                // Output
                DefaultNodeOutputEntries = new List<SearchTreeEntry>()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    endNodeChildEntry,
                    eventNodeChildEntry,
                    pathNodeChildEntry,
                    storyNodeChildEntry
                };
            }

            void SetupOptionChannelEntries()
            {
                // Track
                OptionChannelTrackEntries = new List<SearchTreeEntry>()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    pathNodeChildEntry
                };
                // Entry
                OptionChannelEntryEntries = new List<SearchTreeEntry>()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    optionNodeChildEntry
                };
            }
        }
    }
}