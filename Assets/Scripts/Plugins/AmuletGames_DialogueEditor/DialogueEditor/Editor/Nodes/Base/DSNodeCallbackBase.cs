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
        /// Callback action when any of the nodes is deleted by users from the graph manually.
        /// </summary>
        public abstract void NodeRemovedByManualAction();


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// </summary>
        protected virtual void LanguageChangedAction() { }


        /// <summary>
        /// Callback action when the elements on the nodes has some logic to execute after the edges loading phrase is finished.
        /// </summary>
        protected virtual void PostLoadingSetupAction() { }
    }
}