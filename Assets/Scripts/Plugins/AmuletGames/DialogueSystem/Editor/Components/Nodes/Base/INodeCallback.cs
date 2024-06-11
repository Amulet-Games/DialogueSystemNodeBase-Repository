namespace AG.DS
{
    public interface INodeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnPreRemoveByUser"/>
        /// </summary>
        void OnPreRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnPostRemoveByUser"/>
        /// </summary>
        void OnPostRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="NodeCallbackFrameBase{TNode, TNodeView, TNodeCallback}.OnCreate"/>
        /// </summary>
        void OnCreate(bool byUser);
    }
}