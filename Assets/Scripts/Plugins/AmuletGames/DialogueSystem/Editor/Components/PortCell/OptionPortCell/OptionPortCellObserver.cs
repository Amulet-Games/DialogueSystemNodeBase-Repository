using UnityEngine;
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
            RegisterPostConnectEvent();

            RegisterPreDisconnectEvent();

            RegisterPostConnectingEdgeDropOutsideEvent();
        }


        /// <summary>
        /// Register PostConnectEvent to the port cell's port.
        /// </summary>
        void RegisterPostConnectEvent() => portCell.Port.PostConnectEvent += PostConnectEvent;


        /// <summary>
        /// Register PreDisconnectEvent to the port cell's port.
        /// </summary>
        void RegisterPreDisconnectEvent() => portCell.Port.PreDisconnectEvent += PreDisconnectEvent;


        /// <summary>
        /// Register PostConnectingEdgeDropOutsideEvent to the port cell's port.
        /// </summary>
        void RegisterPostConnectingEdgeDropOutsideEvent() =>
            portCell.Port.PostConnectingEdgeDropOutsideEvent += PostConnectingEdgeDropOutsideEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke after the cell's port is connected to another cell's port.
        /// </summary>
        /// <param name="edge">The edge that connects the two ports.</param>
        void PostConnectEvent(Edge edge)
        {
            portCell.OpponentCell = (OptionPortCell)(portCell.Port.IsInput() ? edge.output : edge.input).parent;

            if (portCell.IsIndexDominant)
            {
                portCell.OpponentCell.Index = portCell.Index;
                portCell.OpponentCell.UpdatePortName();
            }

            // Register MouseMoveEvent to the cell's port connecting edge.
            // Only register the event once for the edge.
            if (portCell.Port.IsInput())
            {
                edge.RegisterCallback<MouseMoveEvent>(
                    evt =>
                    {
                        if (edge.output == null && edge.Output != null)
                        {
                            Debug.Log(portCell.Port.portName);
                            portCell.OpponentCell.OpponentCell = null;

                            edge.Output = null;
                        }
                        else if (edge.input == null && edge.Input != null)
                        {
                            Debug.Log(portCell.Port.portName);
                            Debug.Log(portCell.Port.IsInput());
                            Debug.Log(portCell.OpponentCell.Port.portName);
                            portCell.OpponentCell = null;

                            edge.Input = null;
                        }
                    }
                );
            }
        }


        /// <summary>
        /// The event to invoke when the cell's port is about to be disconnected from another cell's port.
        /// </summary>
        /// <param name="edge">The edge that the ports disconnected from.</param>
        void PreDisconnectEvent(Edge edge)
        {
            portCell.OpponentCell = null;
        }


        /// <summary>
        /// The event to invoke after the cell's port previous connecting edge has been dropped in a empty space.
        /// </summary>
        void PostConnectingEdgeDropOutsideEvent()
        {
            portCell.OpponentCell = null;
        }
    }
}