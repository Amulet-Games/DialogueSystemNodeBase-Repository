namespace AG
{
    /// <summary>
    /// Dialogue system node presenter base class.
    /// </summary>
    public abstract class DSNodePresenterBase
    {
        /// <summary>
        /// Reference of the dialogue system's node creation details.
        /// </summary>
        public DSNodeCreationDetails CreationDetails;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called when a node is added on the graph by users manually.
        /// <para></para>
        /// <br>Since any UI / graph element's references about the node may not be fully setup yet,</br>
        /// <br>Any methods that uses those references are better to be called in "NodeManualCreationSetupAction".</br>
        /// </summary>
        public virtual void NodeManualCreationPreSetupAction() { }


        /// <summary>
        /// Action that called when a node is added on the graph by users manually and a few frames after
        /// <br>the "NodeManualCreationPreSetupAction".</br>
        /// <para></para>
        /// </summary>
        public abstract void NodeManualCreationSetupAction();


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