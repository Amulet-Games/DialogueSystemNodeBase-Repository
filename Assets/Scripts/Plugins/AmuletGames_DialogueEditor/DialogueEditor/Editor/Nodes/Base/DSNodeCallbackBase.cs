using UnityEngine.UIElements;

namespace AG
{
    /// <summary>
    /// Dialogue system node callback base class.
    /// </summary>
    public abstract class DSNodeCallbackBase
    {
        /// <summary>
        /// Reference of the dialogue system's node creation details.
        /// </summary>
        public DSNodeCreationDetails Details;


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
        /// Callback action when the node is added on the graph by users manually.
        /// <br>This action happens a few frames after ManualCreatedAction is called.</br>
        /// </summary>
        public abstract void DelayedManualCreatedAction();

        
        /// <summary>
        /// Callback action when the node is added on the graph by loading the previous saved data.
        /// <br>This action happens a few frames after LoadCreatedAction is called.</br>
        /// </summary>
        public abstract void DelayedLoadCreatedAction();


        /// <summary>
        /// Contains the logic that will be executed from both DelayedManualCreatedAction and DelayedLoadCreatedAction.
        /// </summary>
        public abstract void CommonDelayedCreatedAction();


        /// <summary>
        /// Callback action when the nodes is going to be deleted by users from the graph manually.
        /// <br>This action happens before the node is being removed from the graph.</br>
        /// </summary>
        public abstract void PreManualRemovedAction();


        /// <summary>
        /// Callback action when the nodes is deleted by users from the graph manually.
        /// <br>This action happens after the node is removed from the graph.</br>
        /// </summary>
        public abstract void PostManualRemovedAction();


        /// <summary>
        /// Callback action when the nodes is selected by users on the graph.
        /// </summary>
        public abstract void SelectedAction();


        /// <summary>
        /// Callback action when the nodes is unselected by users on the graph.
        /// </summary>
        public abstract void UnselectedAction();


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// </summary>
        protected virtual void LanguageChangedAction() { }


        /// <summary>
        /// Callback action when the elements on the nodes has some logic to execute after the edges loading phrase is finished.
        /// </summary>
        protected virtual void EdgeLoadedSetupAction() { }
    }
}