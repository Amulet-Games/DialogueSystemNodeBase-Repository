using UnityEngine.UIElements;

namespace AG.DS
{
    public interface INodeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPreManualRemove"/>
        /// </summary>
        void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPostManualRemove"/>
        /// </summary>
        void OnPostManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPostCreate"/>
        /// </summary>
        void OnPostCreate(GeometryChangedEvent evt);
    }
}