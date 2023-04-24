namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeCallback : NodeCallbackFrameBase
    <
        StoryNode,
        StoryNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public StoryNodeCallback
        (
            StoryNode node,
            StoryNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events Service -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();
        }
    }
}