using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view edge element.
    /// </summary>
    public class EdgeBase : Edge
    {
        /// <summary>
        /// Reference of the output port.
        /// </summary>
        public PortBase Output;


        /// <summary>
        /// Reference of the input port.
        /// </summary>
        public PortBase Input;


        /// <summary>
        /// Reference of the edge callback.
        /// </summary>
        public IEdgeCallback Callback;


        /// <summary>
        /// Setup for the edge base class.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="callback">The edge callback to set for.</param>
        /// <param name="styleSheet">The style sheet to set for.</param>
        public EdgeBase Setup
        (
            PortBase output,
            PortBase input,
            IEdgeCallback callback,
            StyleSheet styleSheet
        )
        {
            Output = output;
            Input = input;
            Callback = callback;

            this.output = Output;
            this.input = Input;

            Output.Connect(this);
            Input.Connect(this);

            focusable = true;

            AddToClassList(StyleConfig.Edge);
            styleSheets.Add(styleSheet);

            return this;
        }
    }
}