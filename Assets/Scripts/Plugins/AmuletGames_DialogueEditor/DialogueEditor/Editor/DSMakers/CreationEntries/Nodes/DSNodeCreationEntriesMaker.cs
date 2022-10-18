using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSNodeCreationEntriesMaker : MonoBehaviour
    {
        /// <summary>
        /// Invisible icon that used to create space on each node creation entry besides their name tag.
        /// </summary>
        static Texture2D entryIcon = null!;


        /// <summary>
        /// Returns a new ancestor group entry.
        /// <br>This entry'll be placed on the first layer(0) within the whole node creation tree.</br>
        /// </summary>
        /// <returns>A new ancestor group entry.</returns>
        public static SearchTreeGroupEntry GetNewAncestorEntry()
        {
            return new SearchTreeGroupEntry(new GUIContent(DSStringsConfig.AncestorEntryLabelText), 0);
        }


        /// <summary>
        /// Returns a new nodes family entry.
        /// </summary>
        /// <param name="level">The level of the new nodes family entry to set for.</param>
        /// <returns>A new nodes family group entry.</returns>
        public static SearchTreeGroupEntry GetNewNodesFamilyEntry(int level)
        {
            return new SearchTreeGroupEntry(new GUIContent(DSStringsConfig.NodesFamilyEntryLabelText), level);
        }


        /// <summary>
        /// Returns a new boolean node child entry.
        /// </summary>
        /// <param name="level">The level of the new boolean node child entry to set for.</param>
        /// <returns>A new boolean node child entry.</returns>
        public static DSNodeCreationEntry GetNewBooleanNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.BooleanNodeChildEntryLabelText, level, N_NodeType.Boolean);
        }


        /// <summary>
        /// Returns a new end node child entry.
        /// </summary>
        /// <param name="level">The level of the new end node child entry to set for.</param>
        /// <returns>A new end node child entry.</returns>
        public static DSNodeCreationEntry GetNewEndNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.EndNodeChildEntryLabelText, level, N_NodeType.End);
        }


        /// <summary>
        /// Returns a new event node child entry.
        /// </summary>
        /// <param name="level">The level of the new event node child entry to set for.</param>
        /// <returns>A new event node child entry.</returns>
        public static DSNodeCreationEntry GetNewEventNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.EventNodeChildEntryLabelText, level, N_NodeType.Event);
        }


        /// <summary>
        /// Returns a new option node child entry.
        /// </summary>
        /// <param name="level">The level of the new option node child entry to set for.</param>
        /// <returns>A new option node child entry.</returns>
        public static DSNodeCreationEntry GetNewOptionNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.OptionNodeChildEntryLabelText, level, N_NodeType.Option);
        }


        /// <summary>
        /// Returns a new dialogue node child entry.
        /// </summary>
        /// <param name="level">The level of the new dialogue node child entry to set for.</param>
        /// <returns>A new dialogue node child entry.</returns>
        public static DSNodeCreationEntry GetNewPathNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.PathNodeChildEntryLabelText, level, N_NodeType.Path);
        }


        /// <summary>
        /// Returns a new start node child entry.
        /// </summary>
        /// <param name="level">The level of the new start node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public static DSNodeCreationEntry GetNewStartNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.StartNodeChildEntryLabelText, level, N_NodeType.Start);
        }


        /// <summary>
        /// Returns a new story node child entry.
        /// </summary>
        /// <param name="level">The level of the new story node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public static DSNodeCreationEntry GetNewStoryNodeChildEntry(int level)
        {
            return GetNewNodeEntry(DSStringsConfig.StoryNodeChildEntryLabelText, level, N_NodeType.Story);
        }


        /// <summary>
        /// Create a new node child entry.
        /// </summary>
        /// <param name="entryName">The entry name to set for.</param>
        /// <param name="level">The level of the new node child entry to set for.</param>
        /// <param name="entryNodeType">The type of node that the child entry is representing.</param>
        /// <returns>A new node creation child entry.</returns>
        static DSNodeCreationEntry GetNewNodeEntry(string entryName, int level, N_NodeType entryNodeType)
        {
            // If entry icon is not yet setup.
            if (entryIcon == null!)
            {
                entryIcon = new Texture2D(1, 1);
                entryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
                entryIcon.Apply();
            }

            return new DSNodeCreationEntry(new GUIContent(entryName, entryIcon), level, (int)entryNodeType);
        }
    }
}