namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeCallback : NodeCallbackFrameBase
    <
        EndNode,
        EndNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public EndNodeCallback
        (
            EndNode node,
            EndNodeModel model
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