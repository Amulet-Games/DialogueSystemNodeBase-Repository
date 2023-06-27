namespace AG.DS
{
    public abstract class EdgePresenterFrameBase
    <
        TEdge,
        TPort
    >
        : EdgePresenterBase
        where TEdge : EdgeBase
        where TPort : PortBase
    {
        /// <summary>
        /// Method for creating a new type edge element.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new type edge element.</returns>
        public abstract TEdge CreateElement(TPort output, TPort input);
    }
}