using UnityEngine.UIElements;

namespace AG.DS
{
    public interface INodeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView}.OnPreManualRemove"/>
        /// </summary>
        void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView}.OnPostManualRemove"/>
        /// </summary>
        void OnPostManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView}.OnPostCreate"/>
        /// </summary>
        void OnPostCreate(GeometryChangedEvent evt);
    }
}