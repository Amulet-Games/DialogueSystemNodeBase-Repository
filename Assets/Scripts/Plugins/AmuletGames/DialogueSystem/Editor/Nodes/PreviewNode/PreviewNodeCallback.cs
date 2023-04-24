namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeCallback : NodeCallbackFrameBase
    <
        PreviewNode,
        PreviewNodeModel
    >
    {
        /// <summary>
        /// Constructor of the preview node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public PreviewNodeCallback
        (
            PreviewNode node,
            PreviewNodeModel model
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