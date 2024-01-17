namespace AG.DS
{
    public class NodeCreationRequestSearchWindowPresenter
    {
        /// <summary>
        /// Create a new node creation request search window.
        /// </summary>
        /// <returns>A new node creation request search window.</returns>
        public static SearchWindowBase CreateWindow()
        {
            return SearchWindowPresenter.CreateWindow<SearchWindowBase>(
                SearchTreeEntryProvider.NodeCreationRequestSearchTreeEntries);
        }
    }
}