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
                                        BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeModel>(graphViewer, headBar),

                NodeType.Dialogue => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter,
                                        DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeModel>(graphViewer, headBar),

                NodeType.End => Spawn<EndNode, EndNodeView, EndNodePresenter,
                                    EndNodeCallback, EndNodeSerializer, EndNodeModel>(graphViewer, headBar),

                NodeType.Event => Spawn<EventNode, EventNodeView, EventNodePresenter,
                                    EventNodeCallback, EventNodeSerializer, EventNodeModel>(graphViewer, headBar),

                NodeType.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter,
                                            OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeModel>(graphViewer, headBar),

                NodeType.OptionRoot => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter,
                                        OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeModel>(graphViewer, headBar),

                NodeType.Preview => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter,
                                        PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeModel>(graphViewer, headBar),

                NodeType.Start => Spawn<StartNode, StartNodeView, StartNodePresenter,
                                    StartNodeCallback, StartNodeSerializer, StartNodeModel>(graphViewer, headBar),

                NodeType.Story => Spawn<StoryNode, StoryNodeView, StoryNodePresenter,
                                        StoryNodeCallback, StoryNodeSerializer, StoryNodeModel>(graphViewer, headBar),

                _ => throw new ArgumentException("Invalid node type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node base element.
        /// </summary>
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        /// <returns>A new node base element.</returns>
        /// <exception cref="ArgumentException">Thrown when the given type node model is invalid to any of the current exist node's type.</exception>
        public NodeBase Spawn<TNodeModel>
        (
            GraphViewer graphViewer,
            HeadBar headBar,
            TNodeModel model
        )
            where TNodeModel : NodeModelBase
        {
            return model switch
            {
                BooleanNodeModel m_model => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter,
                                    BooleanNodeCallback, BooleanNodeSerializer, BooleanNodeModel>(graphViewer, headBar, m_model),

                DialogueNodeModel m_model => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter,
                                    DialogueNodeCallback, DialogueNodeSerializer, DialogueNodeModel>(graphViewer, headBar, m_model),

                EndNodeModel m_model => Spawn<EndNode, EndNodeView, EndNodePresenter,
                                EndNodeCallback, EndNodeSerializer, EndNodeModel>(graphViewer, headBar, m_model),

                EventNodeModel m_model => Spawn<EventNode, EventNodeView, EventNodePresenter,
                                EventNodeCallback, EventNodeSerializer, EventNodeModel>(graphViewer, headBar, m_model),

                OptionBranchNodeModel m_model => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter,
                                        OptionBranchNodeCallback, OptionBranchNodeSerializer, OptionBranchNodeModel>(graphViewer, headBar, m_model),

                OptionRootNodeModel m_model => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter,
                                    OptionRootNodeCallback, OptionRootNodeSerializer, OptionRootNodeModel>(graphViewer, headBar, m_model),

                PreviewNodeModel m_model => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter,
                                    PreviewNodeCallback, PreviewNodeSerializer, PreviewNodeModel>(graphViewer, headBar, m_model),

                StartNodeModel m_model => Spawn<StartNode, StartNodeView, StartNodePresenter,
                                StartNodeCallback, StartNodeSerializer, StartNodeModel>(graphViewer, headBar, m_model),

                StoryNodeModel m_model => Spawn<StoryNode, StoryNodeView, StoryNodePresenter,
                                StoryNodeCallback, StoryNodeSerializer, StoryNodeModel>(graphViewer, headBar, m_model),

                _ => throw new ArgumentException("Invalid node model type: " + model.GetType().Name)
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
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        /// <returns>A new type node element.</returns>
        TNode Spawn<TNode, TNodeView, TNodePresenter, TNodeCallback, TNodeSerializer, TNodeModel>
        (
            GraphViewer graphViewer,
            HeadBar headBar = null,
            TNodeModel model = null
        )
            where TNode : NodeFrameBase<TNode, TNodeView, TNodeSerializer, TNodeCallback, TNodeModel>
            where TNodeView : NodeViewFrameBase, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeView>, new()
            where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView>
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeModel>
            where TNodeModel : NodeModelBase
        {
            // Create view
            var nodeView = new TNodeView();

            // Create node
            var node = new TNodePresenter().CreateElements(nodeView, graphViewer, headBar);

            // Register events
            node.Callback.RegisterEvents();
            
            if (model != null)
            {
                // Load saved values
                node.Serializer.Load(model);
            }

            return node;
        }
    }
}