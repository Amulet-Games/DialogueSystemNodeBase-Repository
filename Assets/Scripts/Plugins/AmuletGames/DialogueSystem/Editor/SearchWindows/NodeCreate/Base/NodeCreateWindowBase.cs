using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class NodeCreateWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        protected GraphViewer GraphViewer;


        /// <summary>
        /// The property of the node create entries of the window.
        /// </summary>
        protected virtual List<SearchTreeEntry> ToShowEntries { get; }


        // ----------------------------- Services -----------------------------
        /// <summary>
        /// The callback to invoke when an entry in the node create window's search tree list is selected.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</para>
        /// </summary>
        /// 
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        /// 
        /// <returns>Returns true if succeeded, false otherwise.</returns>
        public abstract bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context);


        /// <summary>
        /// Generates data to populate the search window.
        /// <br>This method is invoked when the SearchWindow first opens and when it is reloaded.</br>
        /// <para></para>
        /// <br>Read More:</br>
        /// <br>https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html</br>
        /// </summary>
        /// 
        /// <param name="context">Contextual data initially passed the window when first created.</param>
        /// 
        /// <returns>Returns the list of SearchTreeEntry objects displayed in the search window.</returns>
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => ToShowEntries;
    }
}

/*
    /// <summary>
    /// Executed when user selects an entry in the search tree list.
    /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</para>
    /// </summary>
    /// <param name="searchTreeEntry">The selected entry.</param>
    /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
    public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
    {
        // Invoke search tree entry clicked event.
        SearchTreeEntrySelectedEvent.Invoke();

        // Get create position.
        {
            // 2D direction from mouse screen position to window center position.
            Vector2 preWindowCenterDir;
            if (IsUpdateScreenMousePosition)
            {
                // Update the mouse position again.
                preWindowCenterDir = graphViewer.MouseScreenPosition - dsWindow.position.position;
            }
            else
            {
                // Use the mouse position that was cached earlier.
                preWindowCenterDir = context.screenMousePosition - dsWindow.position.position;
            }

            // Convert the direction from screen space to window space(?)
            Vector2 postWindowCenterDir = dsWindow.rootVisualElement.ChangeCoordinatesTo
            (
                dest: dsWindow.rootVisualElement.parent,
                point: preWindowCenterDir
            );

            // And calculate its position in the graph viewer.
            createPosition = graphViewer.contentViewContainer.WorldToLocal(p: postWindowCenterDir);
        }

        // Create node.
        var node = NodeManager.Instance.Spawn
        (
            graphViewer,
            nodeType: ((NodeCreateEntry)searchTreeEntry).NodeType,
            languageHandler
        );

        node.ExecuteOnceOnGeometryChanged(SetPosition);


        // Set spawn position.
        switch (node)
        {
            case BooleanNode booleanNode:
                SetNodePosition
                (
                    booleanNode,
                    leftSideAlignmentReferencePort: booleanNode.View.TrueOutputDefaultPort,
                    rightSideAlignmentReferencePort: booleanNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: booleanNode.View.InputDefaultPort
                );
                break;

            case DialogueNode dialogueNode:
                SetNodePosition
                (
                    dialogueNode,
                    leftSideAlignmentReferencePort: dialogueNode.View.OutputDefaultPort,
                    rightSideAlignmentReferencePort: dialogueNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: dialogueNode.View.InputDefaultPort
                );
                break;

            case EndNode endNode:
                SetNodePosition
                (
                    endNode,
                    rightSideAlignmentReferencePort: endNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: endNode.View.InputDefaultPort
                );
                break;

            case EventNode eventNode:
                SetNodePosition
                (
                    eventNode,
                    leftSideAlignmentReferencePort: eventNode.View.OutputDefaultPort,
                    rightSideAlignmentReferencePort: eventNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: eventNode.View.InputDefaultPort
                );
                break;

            case OptionBranchNode optionBranchNode:
                SetNodePosition
                (
                    optionBranchNode,
                    leftSideAlignmentReferencePort: optionBranchNode.View.OutputDefaultPort,
                    rightSideAlignmentReferencePort: optionBranchNode.View.InputOptionPort,
                    middleAlignmentReferencePort: optionBranchNode.View.InputOptionPort
                );
                break;

            case OptionRootNode optionRootNode:
                SetNodePosition
                (
                    optionRootNode,
                    leftSideAlignmentReferencePort: optionRootNode.View.OutputOptionPort,
                    rightSideAlignmentReferencePort: optionRootNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: optionRootNode.View.InputDefaultPort
                );
                break;

            case PreviewNode previewNode:
                SetNodePosition
                    (
                        previewNode,
                        leftSideAlignmentReferencePort: previewNode.View.OutputDefaultPort,
                        rightSideAlignmentReferencePort: previewNode.View.InputDefaultPort,
                        middleAlignmentReferencePort: previewNode.View.InputDefaultPort
                    );
                break;

            case StartNode startNode:
                SetNodePosition
                (
                    startNode,
                    leftSideAlignmentReferencePort: startNode.View.OutputDefaultPort,
                    middleAlignmentReferencePort: startNode.View.OutputDefaultPort
                );
                break;

            case StoryNode storyNode:
                StoryNodeSetPosition
                (
                    storyNode,
                    leftSideAlignmentReferencePort: storyNode.View.OutputDefaultPort,
                    rightSideAlignmentReferencePort: storyNode.View.InputDefaultPort,
                    middleAlignmentReferencePort: storyNode.View.InputDefaultPort
                );
                break;
        }

        // Add to graph viewer.
        graphViewer.Add(node);

        return true;
    }
 */