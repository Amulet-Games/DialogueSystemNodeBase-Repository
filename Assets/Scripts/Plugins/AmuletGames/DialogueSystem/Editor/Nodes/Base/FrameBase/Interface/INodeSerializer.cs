namespace AG.DS
{
    public interface INodeSerializer
    {
        /// <summary>
        /// Read more:
        /// <see cref="NodeSerializerFrameBase{TNode, TNodeView, TNodeModel}.Save(DialogueSystemModel)"/>
        /// </summary>
        void Save(DialogueSystemModel dsModel);


        /// <summary>
        /// Read more:
        /// <see cref="NodeSerializerFrameBase{TNode, TNodeView, TNodeModel}.Load(TNodeModel)"/>
        /// </summary>
        void Load();
    }
}