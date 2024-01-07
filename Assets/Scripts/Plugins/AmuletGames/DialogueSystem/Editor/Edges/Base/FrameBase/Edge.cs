using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class Edge<TPort>
        : EdgeBase
        where TPort : Port<TPort>
    {
        /// <summary>
        /// Reference of the output port.
        /// </summary>
        public TPort Output;


        /// <summary>
        /// Reference of the input port.
        /// </summary>
        public TPort Input;


        /// <summary>
        /// Setup for the edge class.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="callback">The edge callback to set for.</param>
        /// <param name="styleSheet">The style sheet to set for.</param>
        public Edge<TPort> Setup
        (
            TPort output,
            TPort input,
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