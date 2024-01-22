using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view edge element.
    /// </summary>
    public class Edge : UnityEditor.Experimental.GraphView.Edge
    {
        /// <summary>
        /// Reference of the output port.
        /// </summary>
        public Port Output;


        /// <summary>
        /// Reference of the input port.
        /// </summary>
        public Port Input;


        /// <summary>
        /// Reference of the edge callback.
        /// </summary>
        public IEdgeCallback Callback { get; private set; }


        /// <summary>
        /// Reference of the style sheet.
        /// </summary>
        public StyleSheet StyleSheet { get; private set; }


        /// <summary>
        /// Setup for the edge base class.
        /// </summary>
        /// <param name="callback">The edge callback to set for.</param>
        /// <returns>The edge base element.</returns>
        public Edge Setup
        (
            IEdgeCallback callback,
            StyleSheet styleSheet
        )
        {
            Callback = callback;
            StyleSheet = styleSheet;
            return this;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Connect with the given two port base element.
        /// </summary>
        /// <param name="input">The input port to set for.</param>
        /// <param name="output">The output port to set for.</param>
        /// <returns>The edge base element.</returns>
        public Edge Connect
        (
            Port input,
            Port output
        )
        {
            this.input = input;
            this.output = output;

            Input = input;
            Output = output;

            Input.Connect(this);
            Output.Connect(this);

            return this;
        }
    }
}