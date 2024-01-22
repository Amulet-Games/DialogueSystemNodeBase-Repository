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
        public override void RegisterEvents(StoryNode node)
        {
            base.RegisterEvents(node);

            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();
        }
    }
}