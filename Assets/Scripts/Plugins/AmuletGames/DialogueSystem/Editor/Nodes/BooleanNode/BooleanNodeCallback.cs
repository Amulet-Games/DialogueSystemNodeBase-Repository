namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public BooleanNodeCallback
        (
            BooleanNode node,
            BooleanNodeModel model
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

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();
        }
    }
}