namespace AG.DS
{
    public class EdgePresenter
    {
        /// <summary>
        /// Create a new edge base element.
        /// </summary>
        /// <param name="model">The edge model to set for.</param>
        /// <returns>A new edge base element.</returns>
        public static EdgeBase CreateElement(EdgeModel model)
        {
            EdgeBase edge;

            CreateEdge();

            SetupDetails();

            AddStyleClass();

            AddStyleSheet();

            return edge;

            void CreateEdge()
            {
                edge = new();
            }

            void SetupDetails()
            {
                edge.focusable = model.Focusable;
            }

            void AddStyleClass()
            {
                edge.AddToClassList(StyleConfig.Edge);
            }

            void AddStyleSheet()
            {
                edge.styleSheets.Add(model.StyleSheet);
            }
        }
    }
}