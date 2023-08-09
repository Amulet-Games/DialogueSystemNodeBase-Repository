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
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="nodeType">The node type to set for.</param>
        /// 
        /// <returns>A new node base element.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given node type is invalid to any of the current exist node's type.
        /// </exception>
        public NodeBase Spawn
        (
            GraphViewer graphViewer,
            HeadBar headBar,
            NodeType nodeType
        )
        {
            return nodeType switch
            {
                NodeType.Boolean => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                      BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeModel>(graphViewer, headBar),

                NodeType.Dialogue => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                       DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeModel>(graphViewer, headBar),

                NodeType.End => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                                  EndNodeSerializer, EndNodeCallback, EndNodeModel>(graphViewer, headBar),

                NodeType.Event => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                    EventNodeSerializer, EventNodeCallback, EventNodeModel>(graphViewer, headBar),

                NodeType.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                           OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeModel>(graphViewer, headBar),

                NodeType.OptionRoot => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                         OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeModel>(graphViewer, headBar),

                NodeType.Preview => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                      PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeModel>(graphViewer, headBar),

                NodeType.Start => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                    StartNodeSerializer, StartNodeCallback, StartNodeModel>(graphViewer, headBar),

                NodeType.Story => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                    StoryNodeSerializer, StoryNodeCallback, StoryNodeModel>(graphViewer, headBar),

                _ => throw new ArgumentException("Invalid node type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node base element.
        /// </summary>
        /// 
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        /// 
        /// <returns>A new node base element.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given type node model is invalid to any of the current exist node's type.
        /// </exception>
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
                BooleanNodeModel m_model => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                  BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeModel>(graphViewer, headBar, m_model),

                DialogueNodeModel m_model => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                   DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeModel>(graphViewer, headBar, m_model),

                EndNodeModel m_model => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                              EndNodeSerializer, EndNodeCallback, EndNodeModel>(graphViewer, headBar, m_model),

                EventNodeModel m_model => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                EventNodeSerializer, EventNodeCallback, EventNodeModel>(graphViewer, headBar, m_model),

                OptionBranchNodeModel m_model => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                       OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeModel>(graphViewer, headBar, m_model),

                OptionRootNodeModel m_model => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                     OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeModel>(graphViewer, headBar, m_model),

                PreviewNodeModel m_model => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                  PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeModel>(graphViewer, headBar, m_model),

                StartNodeModel m_model => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                StartNodeSerializer, StartNodeCallback, StartNodeModel>(graphViewer, headBar, m_model),

                StoryNodeModel m_model => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                StoryNodeSerializer, StoryNodeCallback, StoryNodeModel>(graphViewer, headBar, m_model),

                _ => throw new ArgumentException("Invalid node model type: " + model.GetType().Name)
            };
        }


        /// <summary>
        /// Method for creating a new type node element.
        /// </summary>
        /// 
        /// <typeparam name="TNode">Type node</typeparam>
        /// <typeparam name="TNodeView">Type node view</typeparam>
        /// <typeparam name="TNodePresenter">Type node presenter</typeparam>
        /// <typeparam name="TNodeObserver">Type node observer</typeparam>
        /// <typeparam name="TNodeSerializer">Type node serializer</typeparam>
        /// <typeparam name="TNodeCallback">Type node callback</typeparam>
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        /// 
        /// <returns>A new type node element.</returns>
        TNode Spawn<TNode, TNodeView, TNodePresenter, TNodeObserver, TNodeSerializer, TNodeCallback, TNodeModel>
        (
            GraphViewer graphViewer,
            HeadBar headBar = null,
            TNodeModel model = null
        )
            where TNode : NodeFrameBase<TNode, TNodeView, TNodeObserver, TNodeSerializer, TNodeCallback, TNodeModel>
            where TNodeView : NodeViewBase, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeView, TNodeObserver>, new()
            where TNodeObserver : NodeObserverFrameBase<TNode, TNodeView>, new()
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeModel>
            where TNodeCallback: NodeCallbackFrameBase<TNode, TNodeView> 
            where TNodeModel : NodeModelBase
        {
            var view = new TNodeView();
            var observer = new TNodeObserver();
            var node = new TNodePresenter().CreateElements(view, observer, graphViewer, headBar);

            observer.RegisterEvents(node, view);
            
            if (model != null)
            {
                node.Serializer.Load(model);
            }

            return node;
        }
    }
}