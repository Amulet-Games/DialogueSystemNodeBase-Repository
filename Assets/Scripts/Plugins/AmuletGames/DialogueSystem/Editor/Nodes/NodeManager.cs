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
        /// Setup for the node manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Spawn -----------------------------
        /// <summary>
        /// Method for creating a new node element.
        /// </summary>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="nodeType">The node type to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// 
        /// <returns>A new node element.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given node type is invalid to any of the current existing node's type.
        /// </exception>
        public NodeBase Spawn
        (
            GraphViewer graphViewer,
            NodeType nodeType,
            LanguageHandler languageHandler = null
        )
        {
            return nodeType switch
            {
                NodeType.Boolean => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                      BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeModel>(graphViewer),

                NodeType.Dialogue => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                       DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeModel>(graphViewer, languageHandler),

                NodeType.End => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                                  EndNodeSerializer, EndNodeCallback, EndNodeModel>(graphViewer),

                NodeType.Event => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                    EventNodeSerializer, EventNodeCallback, EventNodeModel>(graphViewer),

                NodeType.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                           OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeModel>(graphViewer, languageHandler),

                NodeType.OptionRoot => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                         OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeModel>(graphViewer, languageHandler),

                NodeType.Preview => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                      PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeModel>(graphViewer),

                NodeType.Start => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                    StartNodeSerializer, StartNodeCallback, StartNodeModel>(graphViewer),

                NodeType.Story => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                    StoryNodeSerializer, StoryNodeCallback, StoryNodeModel>(graphViewer),

                _ => throw new ArgumentException("Invalid node type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node element.
        /// </summary>
        /// 
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// 
        /// <returns>A new node element.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given type node model is invalid to any of the current existing node's type.
        /// </exception>
        public NodeBase Spawn<TNodeModel>
        (
            GraphViewer graphViewer,
            TNodeModel model,
            LanguageHandler languageHandler = null
        )
            where TNodeModel : NodeModelBase
        {
            return model switch
            {
                BooleanNodeModel m_model => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                  BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeModel>(graphViewer, null, m_model),

                DialogueNodeModel m_model => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                   DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeModel>(graphViewer, languageHandler, m_model),

                EndNodeModel m_model => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                              EndNodeSerializer, EndNodeCallback, EndNodeModel>(graphViewer, null, m_model),

                EventNodeModel m_model => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                EventNodeSerializer, EventNodeCallback, EventNodeModel>(graphViewer, null, m_model),

                OptionBranchNodeModel m_model => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                       OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeModel>(graphViewer, languageHandler, m_model),

                OptionRootNodeModel m_model => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                     OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeModel>(graphViewer, languageHandler, m_model),

                PreviewNodeModel m_model => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                  PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeModel>(graphViewer, null, m_model),

                StartNodeModel m_model => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                StartNodeSerializer, StartNodeCallback, StartNodeModel>(graphViewer, null, m_model),

                StoryNodeModel m_model => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                StoryNodeSerializer, StoryNodeCallback, StoryNodeModel>(graphViewer, null, m_model),

                _ => throw new ArgumentException("Invalid node model type: " + model.GetType().Name)
            };
        }


        /// <summary>
        /// Method for creating a new node element.
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
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="model">The node model to set for.</param>
        /// 
        /// <returns>A new node element.</returns>
        TNode Spawn<TNode, TNodeView, TNodePresenter, TNodeObserver, TNodeSerializer, TNodeCallback, TNodeModel>
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler = null,
            TNodeModel model = null
        )
            where TNode : NodeFrameBase<TNode, TNodeView>, new()
            where TNodeView : NodeViewFrameBase<TNodeView>, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeView>, new()
            where TNodeObserver : NodeObserverFrameBase<TNode, TNodeView>, new()
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeModel>, new()
            where TNodeCallback: NodeCallbackFrameBase<TNode, TNodeView, TNodeCallback>, new()
            where TNodeModel : NodeModelBase
        {
            var view = new TNodeView().Setup(languageHandler);
            var observer = new TNodeObserver();
            var presenter = new TNodePresenter();
            var callback = new TNodeCallback().Setup(view);
            var node = new TNode().Setup(view, callback, graphViewer, languageHandler);

            presenter.CreateElements(node);
            observer.RegisterEvents(node);
            
            if (model != null)
            {
                new TNodeSerializer().Load(node, model);
            }

            return node;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the node element values.
        /// </summary>
        /// 
        /// <param name="node">The node element to set for.</param>
        /// 
        /// <returns>A new node model.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given node element is invalid to any of the current existing node's type.
        /// </exception>
        public NodeModelBase Save(NodeBase node)
        {
            return node switch
            {
                BooleanNode m_node => Save<BooleanNode, BooleanNodeView,
                             BooleanNodeSerializer, BooleanNodeModel>(m_node),

                DialogueNode m_node => Save<DialogueNode, DialogueNodeView,
                              DialogueNodeSerializer, DialogueNodeModel>(m_node),

                EndNode m_node => Save<EndNode, EndNodeView,
                         EndNodeSerializer, EndNodeModel>(m_node),

                EventNode m_node => Save<EventNode, EventNodeView,
                           EventNodeSerializer, EventNodeModel>(m_node),

                OptionBranchNode m_node => Save<OptionBranchNode, OptionBranchNodeView,
                                  OptionBranchNodeSerializer, OptionBranchNodeModel>(m_node),

                OptionRootNode m_node => Save<OptionRootNode, OptionRootNodeView,
                                OptionRootNodeSerializer, OptionRootNodeModel>(m_node),

                PreviewNode m_node => Save<PreviewNode, PreviewNodeView,
                             PreviewNodeSerializer, PreviewNodeModel>(m_node),

                StartNode m_node => Save<StartNode, StartNodeView,
                           StartNodeSerializer, StartNodeModel>(m_node),

                StoryNode m_node => Save<StoryNode, StoryNodeView,
                           StoryNodeSerializer, StoryNodeModel>(m_node),

                _ => throw new ArgumentException("Invalid node element type: " + node.GetType().Name)
            };
        }


        /// <summary>
        /// Save the node element values.
        /// </summary>
        /// 
        /// <typeparam name="TNode">Type node</typeparam>
        /// <typeparam name="TNodeView">Type node view</typeparam>
        /// <typeparam name="TNodeSerializer">Type node serializer</typeparam>
        /// <typeparam name="TNodeModel">Type node model</typeparam>
        /// 
        /// <param name="node">The node element to set for.</param>
        /// 
        /// <returns>A new node model.</returns>
        TNodeModel Save<TNode, TNodeView, TNodeSerializer, TNodeModel>
        (
            TNode node
        )
            where TNode : NodeFrameBase<TNode, TNodeView>
            where TNodeView : NodeViewFrameBase<TNodeView>
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeModel>, new()
            where TNodeModel : NodeModelBase, new()
        {
            var model = new TNodeModel();
            var serializer = new TNodeSerializer();

            serializer.Save(node, model);

            return model;
        }
    }
}