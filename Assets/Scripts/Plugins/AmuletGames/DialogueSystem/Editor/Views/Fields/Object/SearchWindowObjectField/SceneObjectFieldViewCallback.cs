namespace AG.DS
{
    public static class SceneObjectFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the scene object field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The scene object field view to set for.</param>
        public static void OnCreateByUser(SceneObjectFieldView view)
        {
            view.Value = null;
        }
    }
}