namespace AG.DS
{
    public class ConditionModifierFactory
    {
        /// <summary>
        /// Create a new condition modifier view class.
        /// </summary>
        /// <param name="groupView">The condition modifier group view to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <param name="data">The condition modifier data to set for.</param>
        /// <returns>A new condition modifier view.</returns>
        public static ConditionModifierView Create
        (
            ConditionModifierGroupView groupView,
            GraphViewer graphViewer,
            ConditionModifierData data = null
        )
        {
            var view = new ConditionModifierView();

            ConditionModifierPresenter.CreateElement(view, index: groupView.NextIndex, graphViewer);

            new ConditionModifierObserver(view, groupView).RegisterEvents();

            if (data != null)
            {
                new ConditionModifierSerializer().Load(view, data);
            }

            ConditionModifierCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}