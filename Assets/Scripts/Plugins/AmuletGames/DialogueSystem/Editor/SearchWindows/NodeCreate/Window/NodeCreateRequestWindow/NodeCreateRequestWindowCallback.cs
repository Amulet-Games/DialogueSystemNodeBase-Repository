namespace AG.DS
{
    public class NodeCreateRequestWindowCallback
    {
        /// <summary>
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create request window callback class.
        /// </summary>
        /// <param name="nodeCreateRequestWindow">The node create request window to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public NodeCreateRequestWindowCallback
        (
            NodeCreateRequestWindow nodeCreateRequestWindow,
            DialogueEditorWindow dsWindow
        )
        {
            this.nodeCreateRequestWindow = nodeCreateRequestWindow;
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node create request window.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterSearchTreeEntrySelected();
        }


        /// <summary>
        /// Register SearchTreeEntrySelectedEvent to the node create request window.
        /// </summary>
        void RegisterSearchTreeEntrySelected()
        {
            nodeCreateRequestWindow.SearchTreeEntrySelectedEvent += SearchTreeEntrySelectedEvent;
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user selected a search entry in the node create request window.
        /// </summary>
        void SearchTreeEntrySelectedEvent()
        {
            dsWindow.SetHasUnsavedChanges(value: true);

            nodeCreateRequestWindow.UpdateNodeCreateDetails();
        }
    }
}