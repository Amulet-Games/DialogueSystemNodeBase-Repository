namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeViewFrameBase<TNodeView>
        : NodeViewBase
        where TNodeView : NodeViewBase
    {
        /// <summary>
        /// Setup for the node view base class.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <returns>The after setup node view base class.</returns>
        public abstract TNodeView Setup(LanguageHandler languageHandler);
    }
}