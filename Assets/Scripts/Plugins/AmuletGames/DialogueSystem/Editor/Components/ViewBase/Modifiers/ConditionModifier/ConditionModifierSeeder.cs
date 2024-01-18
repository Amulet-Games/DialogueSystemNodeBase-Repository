namespace AG.DS
{
    public class ConditionModifierSeeder
    {
        /// <summary>
        /// Generate a new condition modifier.
        /// </summary>
        /// <param name="group">The condition modifier group element to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <param name="data">The condition modifier data to set for.</param>
        /// <returns>A new condition modifier view.</returns>
        public ConditionModifierView Generate
        (
            ConditionModifierGroup group,
            GraphViewer graphViewer,
            ConditionModifierData data = null
        )
        {
            var view = new ConditionModifierView();

            ConditionModifierPresenter.CreateElement(view, index: group.NextIndex, graphViewer);

            new ConditionModifierObserver(view, group).RegisterEvents();

            if (data != null)
            {
                new ConditionModifierSerializer().Load(view, data);
            }

            new ConditionModifierCallback().OnCreate(view, data == null);

            return view;
        }
    }
}