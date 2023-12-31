namespace AG.DS
{
    public class ConditionModifierSeeder
    {
        /// <summary>
        /// Generate a new condition modifier.
        /// </summary>
        /// <param name="groupView">The condition modifier group view to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <param name="data">The condition modifier data to set for.</param>
        /// <returns>A new condition modifier view.</returns>
        public ConditionModifierView Generate
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

            new ConditionModifierCallback().OnCreate(view, data == null);

            return view;
        }
    }
}