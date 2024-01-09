namespace AG.DS
{
    public class PortManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static PortManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the port manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Create -----------------------------
        /// <summary>
        /// Method for creating a new port element.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        /// <returns>A port element.</returns>
        public PortBase Create(PortModel model)
        {
            var callback = new PortCallback();
            var port = PortPresenter.CreateElement(model);

            port.Setup(callback);
            callback.Setup(port);

            return port;
        }
    }
}