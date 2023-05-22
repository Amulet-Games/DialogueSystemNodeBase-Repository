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
        /// Constructor of the end node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public EndNodeCallback
        (
            EndNode node,
            EndNodeModel model
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