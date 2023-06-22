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
        /// <param name="nodeType">The node type to set for.</param>
        /// <returns>A new node base element.</returns>
        /// <exception cref="ArgumentException">Thrown when the given node type is invalid to any of the current exist node's type.</exception>
        public NodeBase Spawn(GraphViewer graphViewer, NodeType nodeType)
        {
            return nodeType switch
            {
                NodeType.Boolean => Spawn<BooleanNode, BooleanNodeModel, BooleanNodePresenter,
                                        BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeData>(graphViewer),

                NodeType.Dialogue => Spawn<DialogueNode, DialogueNodeModel, DialogueNodePresenter,
                                        DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeData>(graphViewer),

                NodeType.End => Spawn<EndNode, EndNodeModel, EndNodePresenter,
                                    EndNodeCallback, EndNodeSerializer, EndNodeData>(graphViewer),

                NodeType.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeModel, OptionBranchNodePresenter,
                                            OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeData>(graphViewer),

                NodeType.OptionRoot => Spawn<OptionRootNode, OptionRootNodeModel, OptionRootNodePresenter,
                                        OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeData>(graphViewer),

                NodeType.Preview => Spawn<PreviewNode, PreviewNodeModel, PreviewNodePresenter,
                                        PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeData>(graphViewer),

                NodeType.Start => Spawn<StartNode, StartNodeModel, StartNodePresenter,
                                    StartNodeCallback, StartNodeSerializer, StartNodeData>(graphViewer),

                NodeType.Story => Spawn<StoryNode, StoryNodeModel, StoryNodePresenter,
                                        StoryNodeCallback, StoryNodeSerializer, StoryNodeData>(graphViewer),

                _ => throw new ArgumentException("Invalid node data type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node base element.
        /// </summary>
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="data">The type node data to set for.</param>
        /// <returns>A new node base element.</returns>
        /// <exception cref="ArgumentException">Thrown when the given type node data is invalid to any of the current exist node's type.</exception>
        public NodeBase Spawn<TNodeData>(GraphViewer graphViewer, TNodeData data)
            where TNodeData : NodeDataBase
        {
            return data switch
            {
                BooleanNodeData m_data => Spawn<BooleanNode, BooleanNodeModel, BooleanNodePresenter,
                                    BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeData>(graphViewer, m_data),

                DialogueNodeData m_data => Spawn<DialogueNode, DialogueNodeModel, DialogueNodePresenter,
                                    DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeData>(graphViewer, m_data),

                EndNodeData m_data => Spawn<EndNode, EndNodeModel, EndNodePresenter,
                                EndNodeCallback, EndNodeSerializer, EndNodeData>(graphViewer, m_data),

                EventNodeData m_data => Spawn<EventNode, EventNodeModel, EventNodePresenter,
                                EventNodeCallback, EventNodeSerializer, EventNodeData>(graphViewer, m_data),

                OptionBranchNodeData m_data => Spawn<OptionBranchNode, OptionBranchNodeModel, OptionBranchNodePresenter,
                                        OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeData>(graphViewer, m_data),

                OptionRootNodeData m_data => Spawn<OptionRootNode, OptionRootNodeModel, OptionRootNodePresenter,
                                    OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeData>(graphViewer, m_data),

                PreviewNodeData m_data => Spawn<PreviewNode, PreviewNodeModel, PreviewNodePresenter,
                                    PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeData>(graphViewer, m_data),

                StartNodeData m_data => Spawn<StartNode, StartNodeModel, StartNodePresenter,
                                StartNodeCallback, StartNodeSerializer, StartNodeData>(graphViewer, m_data),

                StoryNodeData m_data => Spawn<StoryNode, StoryNodeModel, StoryNodePresenter,
                                StoryNodeCallback, StoryNodeSerializer, StoryNodeData>(graphViewer, m_data),

                _ => throw new ArgumentException("Invalid node data type: " + data.GetType().Name)
            };
        }


        /// <summary>
        /// Method for creating a new type node element.
        /// </summary>
        /// <typeparam name="TNode">Type node</typeparam>
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// <typeparam name="TNodePresenter">Type node presenter</typeparam>
        /// <typeparam name="TNodeCallback">Type node callback</typeparam>
        /// <typeparam name="TNodeSerializer">Type node serializer</typeparam>
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="data">The type node data to set for.</param>
        /// <returns>A new type node element.</returns>
        TNode Spawn<TNode, TNodeModel, TNodePresenter, TNodeCallback, TNodeSerializer, TNodeData>
        (
            GraphViewer graphViewer,
            TNodeData data = null
        )
            where TNode : NodeFrameBase<TNode, TNodeModel, TNodeSerializer, TNodeCallback, TNodeData>
            where TNodeModel : NodeModelFrameBase, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeModel>, new()
            where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeModel>
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeModel, TNodeData>
            where TNodeData : NodeDataBase
        {
            // Create model
            var nodeModel = new TNodeModel();

            // Create node
            var node = new TNodePresenter().CreateElements(nodeModel, graphViewer);

            // Register events
            node.Callback.RegisterEvents();
            
            // Load data
            if (data != null)
                node.Serializer.Load(data);

            return node;
        }
    }
}