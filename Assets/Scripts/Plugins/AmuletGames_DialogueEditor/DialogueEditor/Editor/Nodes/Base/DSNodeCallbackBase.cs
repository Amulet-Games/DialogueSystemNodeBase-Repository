namespace AG
{
    /// <summary>
    /// Dialogue system node callback base class.
    /// </summary>
    public abstract class DSNodeCallbackBase
    {
        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the node is fully initialized but hasn't been created on the graph yet.
        /// <br>This action happens at the end of the node's class constructor.</br>
        /// </summary>
        public abstract void InitializedAction();


        /// <summary>
        /// Callback action when the node is added on the graph by users manually (by contextual menu or search window).
        /// <br>This action happens after InitalizedAction is called.</br>
        /// </summary>
        public abstract void ManualCreatedAction();


        /// <summary>
        /// Callback action when the nodes is deleted by users from the graph manually.
        /// <br>This action happens before the node is being removed from the graph.</br>
        /// </summary>
        public abstract void PreManualRemovedAction();


        /// <summary>
        /// Callback action when the nodes is deleted by users from the graph manually.
        /// <br>This action happens after the node is removed from the graph.</br>
        /// </summary>
        public abstract void PostManualRemovedAction();


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// </summary>
        protected virtual void LanguageChangedAction() { }


        /// <summary>
        /// Callback action when the elements on the nodes has some logic to execute after the edges loading phrase is finished.
        /// </summary>
        protected virtual void PostLoadingSetupElementsAction() { }
    }
}