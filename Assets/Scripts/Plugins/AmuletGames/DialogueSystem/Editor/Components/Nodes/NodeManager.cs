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
            Node nodeType,
            LanguageHandler languageHandler = null
        )
        {
            return nodeType switch
            {
                Node.Boolean => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                      BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeData>(graphViewer),

                Node.Dialogue => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                       DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeData>(graphViewer, languageHandler),

                Node.End => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                                  EndNodeSerializer, EndNodeCallback, EndNodeData>(graphViewer),

                Node.Event => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                    EventNodeSerializer, EventNodeCallback, EventNodeData>(graphViewer),

                Node.OptionBranch => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                           OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeData>(graphViewer, languageHandler),

                Node.OptionRoot => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                         OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeData>(graphViewer, languageHandler),

                Node.Preview => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                      PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeData>(graphViewer),

                Node.Start => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                    StartNodeSerializer, StartNodeCallback, StartNodeData>(graphViewer),

                Node.Story => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                    StoryNodeSerializer, StoryNodeCallback, StoryNodeData>(graphViewer, languageHandler),

                _ => throw new ArgumentException("Invalid GraphViewer type: " + nodeType)
            };
        }


        /// <summary>
        /// Method for creating a new node element.
        /// </summary>
        /// 
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="data">The node data to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// 
        /// <returns>A new node element.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given type node data is invalid to any of the current existing node's type.
        /// </exception>
        public NodeBase Spawn<TNodeData>
        (
            GraphViewer graphViewer,
            TNodeData data,
            LanguageHandler languageHandler = null
        )
            where TNodeData : NodeDataBase
        {
            return data switch
            {
                BooleanNodeData m_data => Spawn<BooleanNode, BooleanNodeView, BooleanNodePresenter, BooleanNodeObserver,
                                  BooleanNodeSerializer, BooleanNodeCallback, BooleanNodeData>(graphViewer, null, m_data),

                DialogueNodeData m_data => Spawn<DialogueNode, DialogueNodeView, DialogueNodePresenter, DialogueNodeObserver,
                                   DialogueNodeSerializer, DialogueNodeCallback, DialogueNodeData>(graphViewer, languageHandler, m_data),

                EndNodeData m_data => Spawn<EndNode, EndNodeView, EndNodePresenter, EndNodeObserver,
                              EndNodeSerializer, EndNodeCallback, EndNodeData>(graphViewer, null, m_data),

                EventNodeData m_data => Spawn<EventNode, EventNodeView, EventNodePresenter, EventNodeObserver,
                                EventNodeSerializer, EventNodeCallback, EventNodeData>(graphViewer, null, m_data),

                OptionBranchNodeData m_data => Spawn<OptionBranchNode, OptionBranchNodeView, OptionBranchNodePresenter, OptionBranchNodeObserver,
                                       OptionBranchNodeSerializer, OptionBranchNodeCallback, OptionBranchNodeData>(graphViewer, languageHandler, m_data),

                OptionRootNodeData m_data => Spawn<OptionRootNode, OptionRootNodeView, OptionRootNodePresenter, OptionRootNodeObserver,
                                     OptionRootNodeSerializer, OptionRootNodeCallback, OptionRootNodeData>(graphViewer, languageHandler, m_data),

                PreviewNodeData m_data => Spawn<PreviewNode, PreviewNodeView, PreviewNodePresenter, PreviewNodeObserver,
                                  PreviewNodeSerializer, PreviewNodeCallback, PreviewNodeData>(graphViewer, null, m_data),

                StartNodeData m_data => Spawn<StartNode, StartNodeView, StartNodePresenter, StartNodeObserver,
                                StartNodeSerializer, StartNodeCallback, StartNodeData>(graphViewer, null, m_data),

                StoryNodeData m_data => Spawn<StoryNode, StoryNodeView, StoryNodePresenter, StoryNodeObserver,
                                StoryNodeSerializer, StoryNodeCallback, StoryNodeData>(graphViewer, null, m_data),

                _ => throw new ArgumentException("Invalid GraphViewer data type: " + data.GetType().Name)
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
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The node data to set for.</param>
        /// 
        /// <returns>A new node element.</returns>
        TNode Spawn<TNode, TNodeView, TNodePresenter, TNodeObserver, TNodeSerializer, TNodeCallback, TNodeData>
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler = null,
            TNodeData data = null
        )
            where TNode : NodeFrameBase<TNode, TNodeView>, new()
            where TNodeView : NodeViewFrameBase<TNodeView>, new()
            where TNodePresenter : NodePresenterFrameBase<TNode, TNodeView>, new()
            where TNodeObserver : NodeObserverFrameBase<TNode, TNodeView>, new()
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeData>, new()
            where TNodeCallback: NodeCallbackFrameBase<TNode, TNodeView, TNodeCallback>, new()
            where TNodeData : NodeDataBase
        {
            var view = new TNodeView().Setup(languageHandler);
            var observer = new TNodeObserver();
            var presenter = new TNodePresenter();
            var callback = new TNodeCallback().Setup(view);
            var node = new TNode().Setup(view, callback, graphViewer, languageHandler);

            presenter.CreateElements(node);
            observer.RegisterEvents(node);
            
            if (data != null)
            {
                new TNodeSerializer().Load(node, data);
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
        /// <returns>A new node data.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given node element is invalid to any of the current existing node's type.
        /// </exception>
        public NodeDataBase Save(NodeBase node)
        {
            return node switch
            {
                BooleanNode m_node => Save<BooleanNode, BooleanNodeView,
                             BooleanNodeSerializer, BooleanNodeData>(m_node),

                DialogueNode m_node => Save<DialogueNode, DialogueNodeView,
                              DialogueNodeSerializer, DialogueNodeData>(m_node),

                EndNode m_node => Save<EndNode, EndNodeView,
                         EndNodeSerializer, EndNodeData>(m_node),

                EventNode m_node => Save<EventNode, EventNodeView,
                           EventNodeSerializer, EventNodeData>(m_node),

                OptionBranchNode m_node => Save<OptionBranchNode, OptionBranchNodeView,
                                  OptionBranchNodeSerializer, OptionBranchNodeData>(m_node),

                OptionRootNode m_node => Save<OptionRootNode, OptionRootNodeView,
                                OptionRootNodeSerializer, OptionRootNodeData>(m_node),

                PreviewNode m_node => Save<PreviewNode, PreviewNodeView,
                             PreviewNodeSerializer, PreviewNodeData>(m_node),

                StartNode m_node => Save<StartNode, StartNodeView,
                           StartNodeSerializer, StartNodeData>(m_node),

                StoryNode m_node => Save<StoryNode, StoryNodeView,
                           StoryNodeSerializer, StoryNodeData>(m_node),

                _ => throw new ArgumentException("Invalid GraphViewer element type: " + node.GetType().Name)
            };
        }


        /// <summary>
        /// Save the node element values.
        /// </summary>
        /// 
        /// <typeparam name="TNode">Type node</typeparam>
        /// <typeparam name="TNodeView">Type node view</typeparam>
        /// <typeparam name="TNodeSerializer">Type node serializer</typeparam>
        /// <typeparam name="TNodeData">Type node data</typeparam>
        /// 
        /// <param name="node">The node element to set for.</param>
        /// 
        /// <returns>A new node data.</returns>
        TNodeData Save<TNode, TNodeView, TNodeSerializer, TNodeData>
        (
            TNode node
        )
            where TNode : NodeFrameBase<TNode, TNodeView>
            where TNodeView : NodeViewFrameBase<TNodeView>
            where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeData>, new()
            where TNodeData : NodeDataBase, new()
        {
            var data = new TNodeData();
            var serializer = new TNodeSerializer();

            serializer.Save(node, data);

            return data;
        }
    }
}