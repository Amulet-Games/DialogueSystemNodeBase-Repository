namespace AG.DS
{
    public class EdgeConnectorSearchWindowPresenter
    {
        /// <summary>
        /// Create a new edge connector search window.
        /// </summary>
        /// <returns>A new edge connector search window.</returns>
        public static SearchWindowBase CreateWindow()
        {
            return SearchWindowPresenter.CreateWindow<SearchWindowBase>(new());
        }
    }
}