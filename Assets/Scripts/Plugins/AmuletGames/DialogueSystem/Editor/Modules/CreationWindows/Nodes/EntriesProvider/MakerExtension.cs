using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public static partial class NodeCreationEntriesProvider
    {
        /// <summary>
        /// Invisible icon that used to create space on each node creation entry besides their name tag.
        /// </summary>
        static Texture2D entryIcon = null;


        /// <summary>
        /// Returns a new ancestor group entry.
        /// <br>This entry'll be placed on the first layer(0) within the whole node creation tree.</br>
        /// </summary>
        /// <returns>A new ancestor group entry.</returns>
        public static SearchTreeGroupEntry GetNewAncestorEntry()
        {
            return new SearchTreeGroupEntry
            (
                content: new GUIContent(text: StringsConfig.AncestorEntryLabelText),
                level: 0
            );
        }


        /// <summary>
        /// Returns a new nodes family entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new nodes family entry to set for.</param>
        /// <returns>A new nodes family group entry.</returns>
        public static SearchTreeGroupEntry GetNewNodesFamilyEntry(int entryLevel)
        {
            return new SearchTreeGroupEntry
            (
                content: new GUIContent(text: StringsConfig.NodesFamilyEntryLabelText),
                level: entryLevel
            );
        }


        /// <summary>
        /// Returns a new boolean node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new boolean node child entry to set for.</param>
        /// <returns>A new boolean node child entry.</returns>
        public static NodeCreationEntry GetNewBooleanNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.BooleanNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Boolean
            );
        }


        /// <summary>
        /// Returns a new dialogue node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new dialogue node child entry to set for.</param>
        /// <returns>A new dialogue node child entry.</returns>
        public static NodeCreationEntry GetNewDialogueNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.DialogueNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Dialogue
            );
        }


        /// <summary>
        /// Returns a new end node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new end node child entry to set for.</param>
        /// <returns>A new end node child entry.</returns>
        public static NodeCreationEntry GetNewEndNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.EndNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.End
            );
        }


        /// <summary>
        /// Returns a new event node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new event node child entry to set for.</param>
        /// <returns>A new event node child entry.</returns>
        public static NodeCreationEntry GetNewEventNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.EventNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Event
            );
        }


        /// <summary>
        /// Returns a new option track node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new option track node child entry to set for.</param>
        /// <returns>A new option track node child entry.</returns>
        public static NodeCreationEntry GetNewOptionTrackNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.OptionTrackNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.OptionTrack
            );
        }


        /// <summary>
        /// Returns a new option window node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new option window node child entry to set for.</param>
        /// <returns>A new option window node child entry.</returns>
        public static NodeCreationEntry GetNewOptionWindowNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.OptionWindowNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.OptionWindow
            );
        }


        /// <summary>
        /// Returns a new preview node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new preview node child entry to set for.</param>
        /// <returns>A new preview node child entry.</returns>
        public static NodeCreationEntry GetNewPreviewNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.PreviewWindowNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Preview
            );
        }


        /// <summary>
        /// Returns a new start node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new start node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public static NodeCreationEntry GetNewStartNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.StartNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Start
            );
        }


        /// <summary>
        /// Returns a new story node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new story node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public static NodeCreationEntry GetNewStoryNodeChildEntry(int entryLevel)
        {
            return GetNewNodeEntry
            (
                entryName: StringsConfig.StoryNodeChildEntryLabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Story
            );
        }


        /// <summary>
        /// Create a new node child entry.
        /// </summary>
        /// <param name="entryName">The entry name to set for.</param>
        /// <param name="entryLevel">The level of the new node child entry to set for.</param>
        /// <param name="entryNodeType">The type of node that the child entry is representing.</param>
        /// <returns>A new node creation child entry.</returns>
        static NodeCreationEntry GetNewNodeEntry(string entryName, int entryLevel, N_NodeType entryNodeType)
        {
            // If entry icon is not yet setup.
            if (entryIcon == null)
            {
                entryIcon = new Texture2D(1, 1);
                entryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
                entryIcon.Apply();
            }

            return new NodeCreationEntry
            (
                content: new GUIContent(text: entryName, image: entryIcon),
                level: entryLevel,
                entryId: (int)entryNodeType
            );
        }
    }
}