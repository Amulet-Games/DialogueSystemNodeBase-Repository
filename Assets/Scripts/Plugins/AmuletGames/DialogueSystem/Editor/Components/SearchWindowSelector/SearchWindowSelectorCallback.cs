using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class SearchWindowSelectorCallback
    {
        /// <summary>
        /// The callback to invoke when the search window selector is created on the graph by the user.
        /// </summary>
        /// <param name="selector">The search window selector element to set for.</param>
        /// <param name="nullValueEntry">The null value entry to set for.</param>
        public static void OnCreateByUser
        (
            SearchWindowSelector selector,
            SearchTreeEntry nullValueEntry
        )
        {
            selector.SelectedEntry = nullValueEntry;
        }
    }
}