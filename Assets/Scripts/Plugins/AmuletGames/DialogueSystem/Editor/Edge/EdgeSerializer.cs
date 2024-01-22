namespace AG.DS
{
    /// <summary>
    /// Holds the methods for saving and loading the edge view's value.
    /// </summary>
    public class EdgeSerializer
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        Edge edge;


        /// <summary>
        /// Reference of the edge data.
        /// </summary>
        EdgeData data;


        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="data">The edge data to set for.</param>
        public void Save(Edge edge, EdgeData data)
        {
            this.edge = edge;
            this.data = data;
        }


        /// <summary>
        /// Save the edge base values.
        /// </summary>
        protected void SaveEdgeBaseValues()
        {
            data.InputPortGUID = edge.Input.Guid;
            data.OutputPortGUID = edge.Output.Guid;
            data.Focusable = edge.focusable;
            data.StyleSheet = edge.StyleSheet;
        }
    }
}
