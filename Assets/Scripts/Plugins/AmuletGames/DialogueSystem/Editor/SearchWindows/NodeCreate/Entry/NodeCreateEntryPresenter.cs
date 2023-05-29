using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreateEntryPresenter
    {
        /// <summary>
        /// Invisible icon that used to create space on each node create entry besides their name tag.
        /// </summary>
        static Texture2D entryIcon = null;


        /// <summary>
        /// Method for creating a new ancestor entry.
        /// <br>This entry will be placed on the first layer(0) within the whole node create tree.</br>
        /// </summary>
        /// <returns>A new ancestor entry.</returns>
        public SearchTreeGroupEntry CreateAncestorEntry()
        {
            return new SearchTreeGroupEntry
            (
                content: new GUIContent(text: StringConfig.SearchEntry_AncestorEntry_LabelText),
                level: 0
            );
        }


        /// <summary>
        /// Method for creating a new node family entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new node family entry to set for.</param>
        /// <returns>A new node family entry.</returns>
        public SearchTreeGroupEntry CreateNodeFamilyEntry(int entryLevel)
        {
            return new SearchTreeGroupEntry
            (
                content: new GUIContent(text: StringConfig.SearchEntry_FamilyEntry_Nodes_LabelText),
                level: entryLevel
            );
        }


        /// <summary>
        /// Method for creating a new boolean node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new boolean node child entry to set for.</param>
        /// <returns>A new boolean node child entry.</returns>
        public NodeCreateEntry CreateBooleanNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_BooleanNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Boolean
            );
        }


        /// <summary>
        /// Method for creating a new dialogue node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new dialogue node child entry to set for.</param>
        /// <returns>A new dialogue node child entry.</returns>
        public NodeCreateEntry CreateDialogueNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_DialogueNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Dialogue
            );
        }


        /// <summary>
        /// Method for creating a new end node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new end node child entry to set for.</param>
        /// <returns>A new end node child entry.</returns>
        public NodeCreateEntry CreateEndNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_EndNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.End
            );
        }


        /// <summary>
        /// Method for creating a new event node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new event node child entry to set for.</param>
        /// <returns>A new event node child entry.</returns>
        public NodeCreateEntry CreateEventNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_EventNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Event
            );
        }


        /// <summary>
        /// Method for creating a new option branch node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new option branch node child entry to set for.</param>
        /// <returns>A new option branch node child entry.</returns>
        public NodeCreateEntry CreateOptionBranchNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_OptionBranchNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.OptionBranch
            );
        }


        /// <summary>
        /// Method for creating a new option root node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new option root node child entry to set for.</param>
        /// <returns>A new option root node child entry.</returns>
        public NodeCreateEntry CreateOptionRootNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_OptionRootNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.OptionRoot
            );
        }


        /// <summary>
        /// Method for creating a new preview node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new preview node child entry to set for.</param>
        /// <returns>A new preview node child entry.</returns>
        public NodeCreateEntry CreatePreviewNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_PreviewNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Preview
            );
        }


        /// <summary>
        /// Method for creating a new start node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new start node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public NodeCreateEntry CreateStartNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_StartNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Start
            );
        }


        /// <summary>
        /// Method for creating a new story node child entry.
        /// </summary>
        /// <param name="entryLevel">The entry level of the new story node child entry to set for.</param>
        /// <returns>A new start node child entry.</returns>
        public NodeCreateEntry CreateStoryNodeChildEntry(int entryLevel)
        {
            return CreateNodeEntry
            (
                entryName: StringConfig.SearchEntry_ChildEntry_StoryNode_LabelText,
                entryLevel: entryLevel,
                entryNodeType: N_NodeType.Story
            );
        }


        /// <summary>
        /// Method for creating a new node child entry.
        /// </summary>
        /// <param name="entryName">The entry name to set for.</param>
        /// <param name="entryLevel">The level of the new node child entry to set for.</param>
        /// <param name="entryNodeType">The type of node that the child entry is representing.</param>
        /// <returns>A new node child entry.</returns>
        NodeCreateEntry CreateNodeEntry(string entryName, int entryLevel, N_NodeType entryNodeType)
        {
            // If entry icon is not yet setup.
            if (entryIcon == null)
            {
                entryIcon = new Texture2D(1, 1);
                entryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
                entryIcon.Apply();
            }

            return new NodeCreateEntry
            (
                content: new GUIContent(text: entryName, image: entryIcon),
                level: entryLevel,
                entryId: (int)entryNodeType
            );
        }
    }
}