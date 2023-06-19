namespace AG.DS
{
    public class NodeCreateConnectorWindowCallback
    {
        /// <summary>
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        NodeCreateConnectorWindow nodeCreateConnectorWindow;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create connector window callback class.
        /// </summary>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public NodeCreateConnectorWindowCallback
        (
            NodeCreateConnectorWindow nodeCreateConnectorWindow,
            DialogueEditorWindow dsWindow
        )
        {
            this.nodeCreateConnectorWindow = nodeCreateConnectorWindow;
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node create connector window.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterSearchTreeEntrySelected();
        }


        /// <summary>
        /// Register SearchTreeEntrySelectedEvent to the node create connector window.
        /// </summary>
        void RegisterSearchTreeEntrySelected()
        {
            nodeCreateConnectorWindow.SearchTreeEntrySelectedEvent += SearchTreeEntrySelectedEvent;
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user selected a search entry in the node create connector window.
        /// </summary>
        void SearchTreeEntrySelectedEvent()
        {
            dsWindow.SetHasUnsavedChanges(value: true);
        }
    }
}