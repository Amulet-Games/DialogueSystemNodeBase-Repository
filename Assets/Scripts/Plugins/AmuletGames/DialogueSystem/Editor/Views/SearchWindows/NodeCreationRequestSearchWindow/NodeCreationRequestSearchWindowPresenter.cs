namespace AG.DS
{
    public class NodeCreationRequestSearchWindowPresenter
    {
        /// <summary>
        /// Create a new node creation request search window.
        /// </summary>
        /// <returns>A new node creation request search window.</returns>
        public static SearchWindow CreateWindow()
        {
            return SearchWindowPresenter.CreateWindow<SearchWindow>(
                SearchTreeEntryProvider.NodeCreationRequestSearchTreeEntries);
        }
    }
}