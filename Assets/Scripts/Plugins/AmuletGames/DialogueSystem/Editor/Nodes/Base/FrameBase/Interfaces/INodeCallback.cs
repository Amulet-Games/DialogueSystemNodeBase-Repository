namespace AG.DS
{
    public interface INodeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPreManualRemove"/>
        /// </summary>
        void OnPreManualRemove();


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPostManualRemove"/>
        /// </summary>
        void OnPostManualRemove();


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeObserver}.OnPostCreate"/>
        /// </summary>
        void OnPostCreate();
    }
}