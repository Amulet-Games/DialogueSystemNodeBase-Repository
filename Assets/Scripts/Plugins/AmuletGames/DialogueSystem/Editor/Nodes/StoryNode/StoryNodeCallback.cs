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
        /// Constructor of the story node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StoryNodeCallback
        (
            StoryNode node,
            StoryNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            base.RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
    }
}