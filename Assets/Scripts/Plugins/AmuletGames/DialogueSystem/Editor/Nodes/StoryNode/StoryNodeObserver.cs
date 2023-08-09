namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeObserver : NodeObserverFrameBase
    <
        StoryNode,
        StoryNodeView
    >
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(StoryNode node, StoryNodeView view)
        {
            base.RegisterEvents(node, view);
        }
    }
}