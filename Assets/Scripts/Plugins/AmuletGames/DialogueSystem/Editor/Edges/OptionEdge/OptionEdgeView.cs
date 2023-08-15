namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeView : EdgeViewFrameBase
    <
        OptionPort,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionEdgeView Setup(OptionPort output, OptionPort input)
        {
            Output = output;
            Input = input;

            return this;
        }
    }
}