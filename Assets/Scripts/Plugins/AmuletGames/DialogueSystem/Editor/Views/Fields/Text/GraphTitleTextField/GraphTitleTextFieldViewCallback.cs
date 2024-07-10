namespace AG.DS
{
    public class GraphTitleTextFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the graph title text field view is created on the graph.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        public static void OnCreate(GraphTitleTextFieldView view)
        {
            view.Value = "";
            view.BindingSO = null;
        }
    }
}