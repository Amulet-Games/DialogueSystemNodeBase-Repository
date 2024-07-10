namespace AG.DS
{
    public class InputHintFactory
    {
        /// <summary>
        /// Generate a new input hint element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new input hint element.</returns>
        public static InputHint Generate(GraphViewer graphViewer)
        {
            return InputHintPresenter.CreateElement(graphViewer);
        }
    }
}