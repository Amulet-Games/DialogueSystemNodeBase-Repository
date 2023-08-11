using UnityEngine.UIElements;

namespace AG.DS
{
    public interface INodeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnPreManualRemove"/>
        /// </summary>
        void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnPostManualRemove"/>
        /// </summary>
        void OnPostManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnPostCreate"/>
        /// </summary>
        void OnPostCreate(GeometryChangedEvent evt);
    }
}