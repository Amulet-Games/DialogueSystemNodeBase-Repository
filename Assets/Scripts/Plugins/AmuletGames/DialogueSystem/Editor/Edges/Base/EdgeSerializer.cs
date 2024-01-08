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
        EdgeBase edge;


        /// <summary>
        /// Reference of the edge data.
        /// </summary>
        EdgeData data;


        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="data">The edge data to set for.</param>
        public void Save(EdgeBase edge, EdgeData data)
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

            // save style sheets
            var styleSheetsCount = edge.styleSheets.count;
            for (int i = 0; i < styleSheetsCount; i++)
            {
                data.styleSheets.Add(edge.styleSheets[i]);
            }
        }
    }
}