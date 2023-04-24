namespace AG.DS
{
    public class OptionEdgeModel : EdgeModelFrameBase<OptionPort>
    {
        // ----------------------------- Setup -----------------------------
        /// <inheritdoc />
        public override void Setup(OptionPort output, OptionPort input)
        {
            Output = output;
            Input = input;
        }
    }
}