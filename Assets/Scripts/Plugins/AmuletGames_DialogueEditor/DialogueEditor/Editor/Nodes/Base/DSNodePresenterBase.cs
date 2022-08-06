namespace AG
{
    /// <summary>
    /// Dialogue system node presenter base class.
    /// </summary>
    public abstract class DSNodePresenterBase
    {
        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <summary>
        /// Is the node's input ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if input ports are connected and vice versa.</returns>
        public virtual bool IsInputPortConnected() { return false; }


        /// <summary>
        /// Is the node's output ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if output ports are connected and vice versa.</returns>
        public virtual bool IsOutputPortConnected() { return false; }
    }
}