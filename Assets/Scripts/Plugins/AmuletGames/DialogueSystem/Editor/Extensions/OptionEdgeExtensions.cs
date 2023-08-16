namespace AG.DS
{
    public static class OptionEdgeExtensions
    {
        /// <summary>
        /// Add the ports that are connecting with the option edge to the connect style class.
        /// </summary>
        /// <param name="edge">Extensions option channel edge.</param>
        public static void ShowConnectStyle(this OptionEdge edge)
        {
            var output = edge.View.Output;
            var input = edge.View.Input;

            var siblingIndex = output.GetSiblingIndex(additionNumber: 1);

            output.ShowConnectStyle(siblingIndex);
            input.ShowConnectStyle(siblingIndex);

            output.OpponentPort = input;
            input.OpponentPort = output;
        }
    }
}