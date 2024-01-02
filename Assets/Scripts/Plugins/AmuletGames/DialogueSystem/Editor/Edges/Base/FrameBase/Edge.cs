using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view edge element.
    /// </summary>
    public class Edge
    <
        TPort,
        TPortModel,
        TEdgeView
    >
        : EdgeBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
    {
        /// <summary>
        /// Reference of the edge view;
        /// </summary>
        public TEdgeView View;


        /// <summary>
        /// Setup for the edge class.
        /// </summary>
        /// <param name="view">The edge view to set for.</param>
        /// <param name="callback">The edge callback to set for.</param>
        /// <param name="styleSheet">The style sheet to set for.</param>
        public Edge<TPort, TPortModel, TEdgeView> Setup
        (
            TEdgeView view,
            IEdgeCallback callback,
            StyleSheet styleSheet
        )
        {
            View = view;
            Callback = callback;

            output = view.Output;
            input = view.Input;

            output.Connect(this);
            input.Connect(this);

            focusable = true;

            AddToClassList(StyleConfig.Edge);
            styleSheets.Add(styleSheet);

            return this;
        }
    }
}