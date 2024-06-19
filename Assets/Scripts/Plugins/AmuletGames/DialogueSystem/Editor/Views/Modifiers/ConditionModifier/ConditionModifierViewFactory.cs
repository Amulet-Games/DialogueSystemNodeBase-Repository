namespace AG.DS
{
    public class ConditionModifierViewFactory
    {
        /// <summary>
        /// Generate a new condition modifier view class.
        /// </summary>
        /// <param name="groupView">The condition modifier view group view to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <param name="data">The condition modifier view data to set for.</param>
        /// <returns>A new condition modifier view.</returns>
        public static ConditionModifierView Generate
        (
            ConditionModifierViewGroupView groupView,
            GraphViewer graphViewer,
            ConditionModifierViewData data = null
        )
        {
            var view = new ConditionModifierView();
            var searchTreeEntryProvider = new ConditionModifierViewSearchTreeEntryProvider(view);

            ConditionModifierViewPresenter.CreateElement(view, index: groupView.NextIndex, graphViewer);

            new ConditionModifierViewObserver(view, searchTreeEntryProvider, groupView).RegisterEvents();

            if (data != null)
            {
                ConditionModifierViewSerializer.Load(view, data);
            }

            ConditionModifierViewCallback.OnCreate(view, searchTreeEntryProvider, byUser: data == null);

            return view;
        }
    }
}