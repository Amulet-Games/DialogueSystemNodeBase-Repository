namespace AG.DS
{
    public class PortFactory
    {
        /// <summary>
        /// Generate a new port element.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        /// <returns>A port element.</returns>
        public static Port Generate(PortModel model)
        {
            var callback = new PortCallback();
            var port = PortPresenter.CreateElement(model);

            port.Setup(callback);
            callback.Setup(port);

            return port;
        }
    }
}