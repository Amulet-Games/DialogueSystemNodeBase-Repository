namespace AG.DS
{
    public class OptionPortCellObserver
    {
        /// <summary>
        /// The targeting option port cell element.
        /// </summary>
        OptionPortCell portCell;


        /// <summary>
        /// Constructor of the option port cell observer class.
        /// </summary>
        /// <param name="portCell">The option port cell element to set for.</param>
        public OptionPortCellObserver(OptionPortCell portCell)
        {
            this.portCell = portCell;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the port cell.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterPortConnectEvent();

            RegisterPortDisconnectEvent();
        }


        /// <summary>
        /// Register PostConnectEvent to the cell's port.
        /// </summary>
        void RegisterPortConnectEvent() => portCell.Port.PostConnectEvent += OptionPortPostConnectEvent;


        /// <summary>
        /// Register PreDisconnectEvent to the cell's port.
        /// </summary>
        void RegisterPortDisconnectEvent() => portCell.Port.PreDisconnectEvent += OptionPortPreDisconnectEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke after the cell's port is connected to another cell's port.
        /// </summary>
        /// <param name="edge">The edge that connects the two ports.</param>
        void OptionPortPostConnectEvent(EdgeBase edge)
        {
            portCell.OpponentCell = (OptionPortCell)(portCell.Port.IsInput() ? edge.output : edge.input).parent;
            portCell.OpponentCell.Index = portCell.Index;
        }


        /// <summary>
        /// The event to invoke when the cell's port is about to be disconnected from another cell's port.
        /// </summary>
        /// <param name="edge">The edge that the ports disconnected from.</param>
        void OptionPortPreDisconnectEvent(EdgeBase edge)
        {
            portCell.OpponentCell = null;
        }
    }
}