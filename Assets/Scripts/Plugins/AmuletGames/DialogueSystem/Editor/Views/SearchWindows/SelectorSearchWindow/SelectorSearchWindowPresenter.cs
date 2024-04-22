namespace AG.DS
{
    public class SelectorSearchWindowPresenter
    {
        /// <summary>
        /// Create a new selector search window.
        /// </summary>
        /// <returns>A new selector search window.</returns>
        public static SearchWindow CreateWindow()
        {
            return SearchWindowPresenter.CreateWindow<SearchWindow>(new());
        }
    }
}