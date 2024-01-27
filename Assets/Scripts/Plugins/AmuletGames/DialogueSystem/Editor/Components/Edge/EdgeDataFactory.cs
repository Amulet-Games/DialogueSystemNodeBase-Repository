namespace AG.DS
{
    public class EdgeDataFactory
    {
        /// <summary>
        /// Create a new edge data.
        /// </summary>
        /// <param name="edge">The edge element to set for</param>
        /// <returns>A new edge data.</returns>
        public static EdgeData Generate(Edge edge)
        {
            var data = new EdgeData();
            EdgeSerializer.Save(edge, data);

            return data;
        }
    }
}