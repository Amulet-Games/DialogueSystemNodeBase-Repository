namespace AG
{
    /// <summary>
    /// Extension class of dialogue system node base class,
    /// which provides low level methods for other classes, for a specific use case.
    /// </summary>
    public abstract partial class DSNodeBase
    {
        // ----------------------------- Node Refresh Services -----------------------------
        /// <summary>
        /// Same function as Node.RefreshExpandedState.
        /// <para>After adding custom elements to the extension container, call this method in order for them to become visible.</para>
        /// </summary>
        public void RefreshExtensionContainer() => RefreshExpandedState();


        /// <summary>
        /// Same function as Node.RefreshPorts.
        /// <para>Refresh the layout of the ports.</para>
        /// </summary>
        public void RefreshPortsLayout() => RefreshPorts();


        /// <summary>
        /// Refresh node's extension container and ports layout at the sametime.
        /// </summary>
        public void NodeRefreshAll()
        {
            RefreshPorts();
            RefreshExpandedState();
        }
    }
}