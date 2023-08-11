namespace AG.DS
{
    public class NodeCreateRequestWindowObserver
    {
        /// <summary>
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// Constructor of the node create request window observer class.
        /// </summary>
        /// <param name="nodeCreateRequestWindow">The node create request window to set for.</param>
        public NodeCreateRequestWindowObserver(NodeCreateRequestWindow nodeCreateRequestWindow)
        {
            this.nodeCreateRequestWindow = nodeCreateRequestWindow;
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
            WindowChangedEvent.Invoke();

            nodeCreateRequestWindow.UpdateNodeCreateDetails();
        }
    }
}