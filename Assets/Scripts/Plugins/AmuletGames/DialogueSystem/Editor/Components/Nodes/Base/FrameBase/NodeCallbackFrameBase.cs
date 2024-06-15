using System;

namespace AG.DS
{
    public abstract class NodeCallbackFrameBase
    <
        TNode,
        TNodeView,
        TNodeCallback
    >
        : NodeCallbackBase, INodeCallback
        where TNode: NodeBase
        where TNodeView : NodeViewFrameBase<TNodeView>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView, TNodeCallback>
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Setup for the node callback frame base class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <returns>The after setup node callback frame base class.</returns>
        public abstract TNodeCallback Setup(TNodeView view);


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the node is about to be removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPreRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the node is removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPostRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the node is created on the graph.
        /// Note that this is called after the node's save data is loaded.
        /// </summary>
        /// <param name="byUser">Is the node created by the user.</param>
        public void OnCreate(bool byUser)
        {
            _OnCreate(byUser);
            NodeCreatedEvent?.Invoke();
        }


        /// <summary>
        /// Read more:
        /// <see cref="OnCreate"/>
        /// </summary>
        protected abstract void _OnCreate(bool byUser);


        /// <summary>
        /// The event to invoke when the node is created on the graph.
        /// </summary>
        public event Action NodeCreatedEvent;
    }
}