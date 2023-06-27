using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeCreateWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the node create details.
        /// </summary>
        protected NodeCreateDetails Details;


        /// <summary>
        /// When calculating the node create position, should the window use the cached screen mouse position as one of the variable
        /// <br>or get a new screen mouse position from the graph viewer element?</br>
        /// </summary>
        public bool IsUpdateScreenMousePosition;


        /// <summary>
        /// The vector2 position of where the node is created on the graph.
        /// </summary>
        Vector2 createPosition;


        /// <summary>
        /// The event to invoke when the user selected a search entry in the search tree window.
        /// </summary>
        public event Action SearchTreeEntrySelectedEvent;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public void Setup
        (
            GraphViewer graphViewer,
            HeadBar headBar,
            NodeCreateDetails details,
            DialogueEditorWindow dsWindow
        )
        {
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.dsWindow = dsWindow;
            Details = details;
        }


        // ----------------------------- Callbacks -----------------------------
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
                headBar,
                nodeType: ((NodeCreateEntry)searchTreeEntry).NodeType
            );

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


        /// <summary>
        /// Register GeometryChangeEvent to the given node to set its position according to the calculated created position.
        /// </summary>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="leftSideAlignmentReferencePort">The output port of the node to set for, leave this empty if the node doesn't have one.</param>
        /// <param name="rightSideAlignmentReferencePort">The input port of the node to set for, leave this empty if the node doesn't have one.</param>
        /// <param name="middleAlignmentReferencePort">Can be set by either input port or output port.</param>
        void SetNodePosition
        (
           NodeBase node,
           PortBase leftSideAlignmentReferencePort = null,
           PortBase rightSideAlignmentReferencePort = null,
           PortBase middleAlignmentReferencePort = null
        )
        {
            node.ExecuteOnceOnGeometryChanged(SetPosition);

            void SetPosition(GeometryChangedEvent evt)
            {
                // Set position
                {
                    Vector2 targetPos = createPosition;
                    switch (Details.HorizontalAlignmentType)
                    {
                        case HorizontalAlignmentType.LEFT:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + leftSideAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            targetPos.x -= node.localBound.width;

                            break;
                        case HorizontalAlignmentType.MIDDLE:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + middleAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            targetPos.x -= node.localBound.width / 2;

                            break;
                        case HorizontalAlignmentType.RIGHT:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + rightSideAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            break;
                    }

                    node.SetPosition(newPos: new Rect(targetPos, Vector2Utility.Zero));
                }

                // Connect connector port
                {
                    // If connector port is null then return.
                    if (Details.ConnectorPort == null)
                        return;

                    var port = Details.ConnectorPort;
                    var isInput = port.IsInput();

                    if (port.connected)
                    {
                        port.Disconnect(graphViewer);
                    }

                    var edge = EdgeManager.Instance.Connect
                    (
                        output: !isInput ? port : leftSideAlignmentReferencePort,
                        input: isInput ? port : rightSideAlignmentReferencePort
                    );

                    graphViewer.Add(edge);
                }
            }
        }


        // TODO: Delete this after apply design is over.
        void StoryNodeSetPosition
        (
           StoryNode node,
           PortBase leftSideAlignmentReferencePort = null,
           PortBase rightSideAlignmentReferencePort = null,
           PortBase middleAlignmentReferencePort = null
        )
        {
            node.ExecuteOnceOnGeometryChanged(SetPosition);

            void SetPosition(GeometryChangedEvent evt)
            {
                // Set position
                {
                    Vector2 targetPos = createPosition;
                    switch (Details.HorizontalAlignmentType)
                    {
                        case HorizontalAlignmentType.LEFT:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + leftSideAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            targetPos.x -= node.localBound.width;

                            break;
                        case HorizontalAlignmentType.MIDDLE:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + middleAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            targetPos.x -= node.localBound.width / 2;

                            break;
                        case HorizontalAlignmentType.RIGHT:

                            targetPos.y -= (node.titleContainer.worldBound.height
                                      + rightSideAlignmentReferencePort.localBound.position.y
                                      + NodeConfig.ManualCreateYOffset)
                                      / graphViewer.scale;

                            break;
                    }

                    node.SetPosition(newPos: new Rect(targetPos, Vector2Utility.Zero));
                }

                node.ExecuteOnceOnGeometryChanged(node.Callback.GeometryChangedEvent);
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Generates data to populate the search window.
        /// <br>This method is invoked when the SearchWindow first opens and when it is reloaded.</br>
        /// <para>Read More https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html</para>
        /// </summary>
        /// <param name="context">Contextual data initially passed the window when first created.</param>
        /// <returns>Returns the list of SearchTreeEntry objects displayed in the search window.</returns>
        public abstract List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context);


        // ----------------------------- Services -----------------------------
        /// <summary>
        /// Open the node create request search window.
        /// </summary>
        /// <param name="openScreenPosition">The position of opening the search tree window to set for.</param>
        public void Open(Vector2 openScreenPosition = default)
        {
            SearchWindow.Open
            (
                context: new SearchWindowContext
                (
                    openScreenPosition == default
                        ? graphViewer.MouseScreenPosition
                        : openScreenPosition
                ),
                provider: this
            );
        }
    }
}