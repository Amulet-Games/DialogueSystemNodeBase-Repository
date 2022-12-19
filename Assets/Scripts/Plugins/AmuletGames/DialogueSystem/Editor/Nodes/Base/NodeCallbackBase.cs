namespace AG.DS
{
    /// <summary>
    /// Holds all the different callbacks' method of the connecting node module.
    /// </summary>
    public abstract class NodeCallbackBase
    {
        /// <summary>
        /// Reference of the dialogue system's node creation details.
        /// </summary>
        public NodeCreationDetails Details;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the user start adding the node to the graph manually (by contextual menu or search window).
        /// </summary>
        public abstract void ManualCreatedAction();


        /// <summary>
        /// Callback action when the node is added to the graph manually and also its geometryChangedEvent is invoked.
        /// <br>This action happens a few frames after the <see cref="ManualCreatedAction"/> is called.</br>
        /// </summary>
        public abstract void DelayedManualCreatedAction();


        /// <summary>
        /// Callback action when the previous saved data is loaded and adding the node to the graph (by serialize handler).
        /// </summary>
        public abstract void LoadCreatedAction();


        /// <summary>
        /// Callback action when the node is added to the graph by saved data and also its geometryChangedEvent is invoked.
        /// <br>This action happens a few frames after LoadCreatedAction is called.</br>
        /// </summary>
        public virtual void DelayedLoadCreatedAction() { }


        /// <summary>
        /// Callback action when the node has finished its creation process and added on the graph fully.
        /// </summary>
        public abstract void PostCreatedAction();


        /// <summary>
        /// Callback action when the nodes is going to be deleted by users from the graph manually.
        /// <br>This action happens before the node is being removed from the graph.</br>
        /// </summary>
        public abstract void PreManualRemovedAction();


        /// <summary>
        /// Callback action when the nodes is deleted by users from the graph manually.
        /// <br>This action happens after the <see cref="PreManualRemovedAction"/> is called.</br>
        /// </summary>
        public abstract void PostManualRemovedAction();


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// </summary>
        protected virtual void LanguageChangedAction() { }


        /// <summary>
        /// Callback action when the elements on the nodes has some logic to execute after the edges loading phrase is finished.
        /// </summary>
        protected virtual void EdgeLoadedSetupAction() { }


        // ----------------------------- Set Node Min Max Width Task -----------------------------
        /// <summary>
        /// Set the connecting node module's minimum and maximum width value.
        /// </summary>
        protected abstract void SetNodeMinMaxWidth();
    }
}