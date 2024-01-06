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
        /// Register events to the port cell.
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
        void OptionPortPostConnectEvent(EdgeBase edge)
        {
            portCell.OpponentCell = (OptionPortCell)(portCell.Port.IsInput() ? edge.output : edge.input).parent;
            portCell.OpponentCell.Index = portCell.Index;

            edge.RegisterCallback<MouseMoveEvent>(
                evt =>
                {
                    var m_edge = (Edge<OptionPort, OptionPortModel, OptionEdgeView>)edge;
                    var m_edgeView = m_edge.View;

                    if (m_edge.output == null && m_edgeView.Output != null)
                    {
                        (portCell.Port.IsInput() ? portCell.OpponentCell : portCell).OpponentCell = null;

                        m_edgeView.Output = null;
                    }
                    else if (m_edge.input == null && m_edgeView.Input != null)
                    {
                        (portCell.Port.IsInput() ? portCell : portCell.OpponentCell).OpponentCell = null;

                        m_edgeView.Input = null;
                    }
                }
            );
        }


        /// <summary>
        /// The event to invoke when the cell's port is about to be disconnected from another cell's port.
        /// </summary>
        /// <param name="edge">The edge that the ports disconnected from.</param>
        void OptionPortPreDisconnectEvent(EdgeBase edge)
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