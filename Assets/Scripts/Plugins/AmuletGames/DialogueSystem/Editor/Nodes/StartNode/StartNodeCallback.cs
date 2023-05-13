namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public StartNodeCallback
        (
            StartNode node,
            StartNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();
        }
    }
}