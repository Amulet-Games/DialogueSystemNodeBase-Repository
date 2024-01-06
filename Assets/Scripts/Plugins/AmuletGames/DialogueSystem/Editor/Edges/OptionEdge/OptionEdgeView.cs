namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeView : EdgeViewFrameBase
    <
        OptionPort,
        OptionPortModel,
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