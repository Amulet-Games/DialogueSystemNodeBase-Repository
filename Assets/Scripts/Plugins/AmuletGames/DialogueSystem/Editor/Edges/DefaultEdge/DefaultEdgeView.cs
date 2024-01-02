namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeView : EdgeViewFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultEdgeView Setup(DefaultPort output, DefaultPort input)
        {
            Output = output;
            Input = input;

            return this;
        }
    }
}
