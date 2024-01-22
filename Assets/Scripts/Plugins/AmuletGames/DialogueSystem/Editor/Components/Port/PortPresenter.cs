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
        public static Port CreateElement(PortModel model)
        {
            Port port;

            CreatePort();

            AddStyleClass();

            AddStyleSheet();

            return port;

            void CreatePort()
            {
                port = new(model);
            }

            void AddStyleClass()
            {
                port.name = "";
                port.ClearClassList();
                port.AddToClassList(port.IsInput() ? StyleConfig.Input_Port : StyleConfig.Output_Port);
            }

            void AddStyleSheet()
            {
                port.styleSheets.Clear();
                port.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.PortStyle);
            }
        }
    }
}