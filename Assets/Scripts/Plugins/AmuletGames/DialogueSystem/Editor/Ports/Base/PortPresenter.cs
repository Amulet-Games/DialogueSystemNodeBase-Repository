namespace AG.DS
{
    /// <summary>
    /// Holds the methods for creating the port element.
    /// </summary>
    public class PortPresenter
    {
        /// <summary>
        /// Create a new port element.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        /// <returns>A new port element.</returns>
        public PortBase Create(PortModel model) => new(model);
    }
}