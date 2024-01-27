using UnityEngine.UIElements;

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
        /// Register events to the port cell element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterPortPostConnectEvent();

            RegisterPortPreDisconnectEvent();

            RegisterPortPostConnectingEdgeDropOutsideEvent();
        }


        /// <summary>
        /// Register PostConnectEvent to the cell's port.
        /// </summary>
        void RegisterPortPostConnectEvent() => portCell.Port.PostConnectEvent += OptionPortPostConnectEvent;


        /// <summary>
        /// Register MouseMoveEvent to the cell's port connecting edge.
        /// </summary>
        /// <param name="edge">The edge that connects the two ports.</param>
        void RegisterConnectingEdgeMouseMoveEvent(Edge edge)
        {
            edge.RegisterCallback<MouseMoveEvent>(
                evt =>
                {
                    if (edge.output == null && edge.Output != null)
                    {
                        (portCell.Port.IsInput() ? portCell.OpponentCell : portCell).OpponentCell = null;

                        edge.Output = null;
                    }
                    else if (edge.input == null && edge.Input != null)
                    {
                        (portCell.Port.IsInput() ? portCell : portCell.OpponentCell).OpponentCell = null;

                        edge.Input = null;
                    }
                }
            );
        }


        /// <summary>
        /// Register PreDisconnectEvent to the cell's port.
        /// </summary>
        void RegisterPortPreDisconnectEvent() => portCell.Port.PreDisconnectEvent += OptionPortPreDisconnectEvent;


        /// <summary>
        /// Register PostConnectingEdgeDropOutsideEvent to the cell's port.
        /// </summary>
        void RegisterPortPostConnectingEdgeDropOutsideEvent() =>
            portCell.Port.PostConnectingEdgeDropOutsideEvent += OptionPortPostConnectingEdgeDropOutsideEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke after the cell's port is connected to another cell's port.
        /// </summary>
        /// <param name="edge">The edge that connects the two ports.</param>
        void OptionPortPostConnectEvent(Edge edge)
        {
            portCell.OpponentCell = (OptionPortCell)(portCell.Port.IsInput() ? edge.output : edge.input).parent;

            if (portCell.IsIndexDominant)
            {
                portCell.OpponentCell.Index = portCell.Index;
                portCell.OpponentCell.UpdatePortName();
            }

            RegisterConnectingEdgeMouseMoveEvent(edge);
        }


        /// <summary>
        /// The event to invoke when the cell's port is about to be disconnected from another cell's port.
        /// </summary>
        /// <param name="edge">The edge that the ports disconnected from.</param>
        void OptionPortPreDisconnectEvent(Edge edge)
        {
            portCell.OpponentCell = null;
        }


        /// <summary>
        /// The event to invoke after the cell's port previous connecting edge has been dropped in a empty space.
        /// </summary>
        void OptionPortPostConnectingEdgeDropOutsideEvent()
        {
            portCell.OpponentCell = null;
        }
    }
}