using System;

namespace AG.DS
{
    public class NodeManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static NodeManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Spawn -----------------------------
        /// <summary>
        /// Method for creating a new node base element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="nodeType">The node type to set for.</param>
        /// <returns>A new node base element.</returns>
        /// <exception cref="ArgumentException">Thrown when the given node type is invalid to any of the current exist node's type.</exception>
        public NodeBase Spawn
        (
            GraphViewer graphViewer,
            HeadBar headBar,
            NodeType nodeType
        )
        {
            return nodeType switch
            {
                NodeType.Boolean => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter,
                                        BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeData>(graphViewer, headBar),

                NodeType.Dialogue => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter,
                                        DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeData>(graphViewer, headBar),

                NodeType.End => Spawn<EndNode, EndNodeView, EndNodePresenter,
                                    EndNodeCallback, EndNodeSerializer, EndNodeData>(graphViewer, headBar),

                NodeType.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter,
                                            OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeData>(graphViewer, headBar),

                NodeType.OptionRoot => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter,
                                        OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeData>(graphViewer, headBar),

                NodeType.Preview => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter,
                                        PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeData>(graphViewer, headBar),

                NodeType.Start => Spawn<StartNode, StartNodeView, StartNodePresenter,
                                    StartNodeCallback, StartNodeSerializer, StartNodeData>(graphViewer, headBar),

                NodeType.Story => Spawn<StoryNode, StoryNodeView, StoryNodePresenter,
                                        StoryNodeCallback, StoryNodeSerializer, StoryNodeData>(graphViewer, headBar),

                _ => throw new ArgumentException("Invalid node data type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node base element.
        /// </summary>
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="data">The type node data to set for.</param>
        /// <returns>A new node base element.</returns>
        /// <exception cref="ArgumentException">Thrown when the given type node data is invalid to any of the current exist node's type.</exception>
        public NodeBase Spawn<TNodeData>
        (
            GraphViewer graphViewer,
            HeadBar headBar,
            TNodeData data
        )
            where TNodeData : NodeDataBase
        {
            return data switch
            {
                BooleanNodeData m_data => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter,
                                    BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeData>(graphViewer, headBar, m_data),

                DialogueNodeData m_data => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter,
                                    DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeData>(graphViewer, headBar, m_data),

                EndNodeData m_data => Spawn<EndNode, EndNodeView, EndNodePresenter,
                                EndNodeCallback, EndNodeSerializer, EndNodeData>(graphViewer, headBar, m_data),

                EventNodeData m_data => Spawn<EventNode, EventNodeView, EventNodePresenter,
                                EventNodeCallback, EventNodeSerializer, EventNodeData>(graphViewer, headBar, m_data),

                OptionBranchNodeData m_data => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter,
                                        OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeData>(graphViewer, headBar, m_data),

                OptionRootNodeData m_data => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter,
                                    OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeData>(graphViewer, headBar, m_data),

                PreviewNodeData m_data => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter,
                                    PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeData>(graphViewer, headBar, m_data),

                StartNodeData m_data => Spawn<StartNode, StartNodeView, StartNodePresenter,
                                StartNodeCallback, StartNodeSerializer, StartNodeData>(graphViewer, headBar, m_data),

                StoryNodeData m_data => Spawn<StoryNode, StoryNodeView, StoryNodePresenter,
                                StoryNodeCallback, StoryNodeSerializer, StoryNodeData>(graphViewer, headBar, m_data),

                _ => throw new ArgumentException("Invalid node data type: " + data.GetType().Name)
            };
        }


        /// <summary>
        /// Method for creating a new type node element.
        /// </summary>
        /// <typeparam name="TNode">Type node</typeparam>
        /// <typeparam name="TNodeView">Type node view</typeparam>
        /// <typeparam name="TNodePresenter">Type node presenter</typeparam>
        /// <typeparam name="TNodeCallback">Type node callback</typeparam>
        /// <typeparam name="TNodeSerializer">Type node serializer</typeparam>
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="data">The type node data to set for.</param>
        /// <returns>A new type node element.</returns>
        TNode Spawn<TNode, TNodeView, TNodePresenter, TNodeCallback, TNodeSerializer, TNodeData>
        (
            GraphViewer graphViewer,
            HeadBar headBar = null,
            TNodeData data = null
        )
            where TNode : NodeFrameBase<TNode, TNodeView, TNodeSerializer, TNodeCallback, TNodeData>
            where TNodeView : NodeViewFrameBase, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeView>, new()
            where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView>
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeData>
            where TNodeData : NodeDataBase
        {
            // Create view
            var nodeView = new TNodeView();

            // Create node
            var node = new TNodePresenter().CreateElements(nodeView, graphViewer, headBar);

            // Register events
            node.Callback.RegisterEvents();
            
            if (data != null)
            {
                // Load data
                node.Serializer.Load(data);
            }

            return node;
        }
    }
}