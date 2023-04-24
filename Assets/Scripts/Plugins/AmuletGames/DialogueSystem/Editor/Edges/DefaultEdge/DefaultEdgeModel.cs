namespace AG.DS
{
    public class DefaultEdgeModel : EdgeModelFrameBase<DefaultPort>
    {
        // ----------------------------- Setup -----------------------------
        /// <inheritdoc />
        public override void Setup(DefaultPort output, DefaultPort input)
        {
            Output = output;
            Input = input;
        }
    }
}