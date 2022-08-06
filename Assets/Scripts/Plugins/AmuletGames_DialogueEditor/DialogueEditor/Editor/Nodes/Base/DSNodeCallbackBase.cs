namespace AG
{
    /// <summary>
    /// Dialogue system node callback base class.
    /// </summary>
    public abstract class DSNodeCallbackBase
    {
        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// </summary>
        public abstract void NodeAddedAction();


        /// <summary>
        /// Callback action when the connecting node is removed from the graph.
        /// </summary>
        public abstract void NodeRemovedAction();


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// </summary>
        public virtual void LanguageChangedAction() { }
    }
}