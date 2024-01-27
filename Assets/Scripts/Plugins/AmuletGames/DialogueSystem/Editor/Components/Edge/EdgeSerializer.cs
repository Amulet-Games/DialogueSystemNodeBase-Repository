namespace AG.DS
{
    /// <summary>
    /// Holds the methods for saving and loading the edge view's value.
    /// </summary>
    public class EdgeSerializer
    {
        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="data">The edge data to set for.</param>
        public static void Save(Edge edge, EdgeData data)
        {
            data.InputPortGUID = edge.Input.Guid;
            data.OutputPortGUID = edge.Output.Guid;
            data.Focusable = edge.focusable;
            data.StyleSheet = edge.StyleSheet;
        }
    }
}
