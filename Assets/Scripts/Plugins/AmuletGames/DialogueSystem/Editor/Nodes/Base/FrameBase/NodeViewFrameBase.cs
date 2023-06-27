namespace AG.DS
{
    public abstract class NodeViewFrameBase : NodeViewBase
    {
        // ----------------------------- Remove Ports -----------------------------
        /// <summary>
        /// Remove any ports that are in the node from the serialize handler cache.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void RemovePorts(GraphViewer graphViewer);
    }
}