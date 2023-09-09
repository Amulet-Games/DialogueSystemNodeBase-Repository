namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeView : EdgeViewFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionEdgeView Setup(OptionPort output, OptionPort input)
        {
            Output = output;
            Input = input;

            Output.OpponentPort = input;
            Input.OpponentPort = output;

            return this;
        }
    }
}