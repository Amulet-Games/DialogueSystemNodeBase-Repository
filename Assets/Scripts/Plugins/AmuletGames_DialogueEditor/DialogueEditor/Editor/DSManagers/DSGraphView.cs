using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSGraphView : GraphView
    {
        [Header("Refs")]
        private DialogueEditorWindow dsWindow;
        public DSInputHint inputHint;

        #region Setup.
        public DSGraphView(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;

            PreSetup();
        }

        void PreSetup()
        {
            inputHint = new DSInputHint(this);
        }

        public void PostSetup()
        {
            SetupGraphView();

            SetupInputHint();

            void SetupGraphView()
            {
                SetupGridBackground();

                SetupGraphSize();

                SetupGraphManipulator();

                SetupGraphZoom();

                SetupNodeCreationRequest();

                AddStyleSheets();

                AddGraphToWindowRoot();

                void SetupGridBackground()
                {
                    // GOAL: Add a visible grid to the background.

                    GridBackground grid = new GridBackground();
                    Insert(0, grid);
                    grid.StretchToParentSize();
                }

                void SetupGraphSize()
                {
                    this.StretchToParentSize();
                }

                void SetupGraphManipulator()
                {
                    this.AddManipulator(new ContentDragger());          // The ability to drag nodes around.
                    this.AddManipulator(new SelectionDragger());        // The ability to drag all selected nodes around.
                    this.AddManipulator(new RectangleSelector());       // The ability to drag select a rectangle area.
                    this.AddManipulator(new FreehandSelector());        // The ability to select a single node.
                }

                void SetupGraphZoom()
                {
                    // Default Min Scale = 0.25f;
                    // Default Max Scale = 1f;
                    SetupZoom(ContentZoomer.DefaultMinScale, 1.15f);
                }

                void SetupNodeCreationRequest()
                {
                    nodeCreationRequest = context => SearchWindow.Open
                    (
                        new SearchWindowContext(context.screenMousePosition), dsWindow.searchWindow
                    );
                }

                void AddStyleSheets()
                {
                    styleSheets.Add(DSStylesConfig.dsGraphViewStyle);
                }

                void AddGraphToWindowRoot()
                {
                    dsWindow.rootVisualElement.Add(this);
                }
            }

            void SetupInputHint()
            {
                inputHint.PostSetup();
            }
        }

        public void ClearEvents()
        {
            graphViewChanged = null;
        }

        public void RegisterEvents()
        {
            graphViewChanged += OnGraphViewChanged;
        }
        #endregion

        #region Callbacks.
        /// GraphViewChangeEvent - GraphView
        private GraphViewChange OnGraphViewChanged(GraphViewChange change)
        {
            // GOAL: If users created new edges, removed any visual elements or moved any visual elements,
            // set there are unsaved changes to be true.

            if (!dsWindow.hasUnsavedChanges)
            {
                if (change.edgesToCreate != null || change.elementsToRemove != null || change.movedElements != null)
                {
                    DSGraphViewChangedEvent.Invoke();
                }
            }

            return change;
        }

        /// LanguageChangedEvent - DSHeadBar - Language Dropdown
        public void ReloadLanguage()
        {
            // GOAL: Reload all the input fields that are language dependent to the current selected language.

            List<BaseNode> allBaseNodes = nodes.ToList().Where(node => node is BaseNode).Cast<BaseNode>().ToList();

            int allNodesCount = allBaseNodes.Count;
            for (int i = 0; i < allNodesCount; i++)
            {
                allBaseNodes[i].ReloadLanguage();
            }
        }
        #endregion

        #region Overrides.
        public override List<Port> GetCompatiblePorts(Port connectFromPort, NodeAdapter nodeAdapter)
        {
            // INHERIT: Graph View Class
            // GOAL: Overrides to limit which nodes can connect to each other.

            List<Port> compatiblePorts = new List<Port>();

            ports.ForEach((port) =>
            {
                Port connectToPort = port;

                // Same port cannot connect to itself.
                if (connectFromPort != connectToPort && connectFromPort.node != connectToPort.node && connectFromPort.direction != port.direction)
                {
                    // Start node cannot connect to start node
                    if (connectFromPort.node != connectToPort.node)
                    {
                        // Port cannot connect to another port that is in the same direction.
                        // *Input Port(A) -> Input Port(B) / Output Port(A) -> Output Port(B)
                        if (connectFromPort.direction != port.direction)
                        {
                            // If we going to connect to choice node,
                            // this port can only be dialogue node's choice port.
                            if (connectToPort.node is ChoiceNode)
                            {
                                if (connectFromPort.node is DialogueNode)
                                {
                                    if (connectFromPort.portColor == BaseNode.GetPortColorByNodeType(N_NodeType.Choice))
                                    {
                                        compatiblePorts.Add(port);
                                    }
                                }
                            }
                            // If we're connecting from choice node and this port a input port,
                            // this port can only connect to dialogue node's choice port.
                            else if (connectFromPort.node is ChoiceNode && connectFromPort.direction == Direction.Input)
                            {
                                if (connectToPort.node is DialogueNode)
                                {
                                    if (connectToPort.portColor == BaseNode.GetPortColorByNodeType(N_NodeType.Choice))
                                    {
                                        compatiblePorts.Add(port);
                                    }
                                }
                            }
                            else
                            {
                                compatiblePorts.Add(port);
                            }
                        }
                    }
                }
            });

            // return all the acceptable ports.
            return compatiblePorts;
        }
        #endregion

        #region Create Nodes.
        public StartNode CreateStartNode(Vector2 position)
        {
            StartNode newNode = new StartNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }

        public DialogueNode CreateDialogueNode(Vector2 position)
        {
            DialogueNode newNode = new DialogueNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }

        public ChoiceNode CreateChoiceNode(Vector2 position)
        {
            ChoiceNode newNode = new ChoiceNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }

        public EventNode CreateEventNode(Vector2 position)
        {
            EventNode newNode = new EventNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }

        public BranchNode CreateBranchNode(Vector2 position)
        {
            BranchNode newNode = new BranchNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }

        public EndNode CreateEndNode(Vector2 position)
        {
            EndNode newNode = new EndNode(position, dsWindow, this);
            AddElement(newNode);

            return newNode;
        }
        #endregion
    }
}