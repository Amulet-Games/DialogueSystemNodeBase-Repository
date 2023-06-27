namespace AG.DS
{
    public class NodeCreateConnectorWindowCallback
    {
        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        NodeCreateConnectorWindow nodeCreateConnectorWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create connector window callback class.
        /// </summary>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        public NodeCreateConnectorWindowCallback(NodeCreateConnectorWindow nodeCreateConnectorWindow)
        {
            this.nodeCreateConnectorWindow = nodeCreateConnectorWindow;
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
            WindowChangedEvent.Invoke();
        }
    }
}