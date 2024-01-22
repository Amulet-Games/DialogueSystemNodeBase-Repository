namespace AG.DS
{
    public class EdgeConnectorSearchWindowPresenter
    {
        /// <summary>
        /// Create a new edge connector search window.
        /// </summary>
        /// <returns>A new edge connector search window.</returns>
        public static SearchWindow CreateWindow()
        {
            return SearchWindowPresenter.CreateWindow<SearchWindow>(new());
        }
    }
}