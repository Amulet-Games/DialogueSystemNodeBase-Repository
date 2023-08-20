using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public partial class OptionPort : PortFrameBase
    <
        OptionEdge,
        OptionEdgeView,
        OptionEdgeConnectorCallback,
        OptionPort
    >
    {
        /// <summary>
        /// The current connecting opponent option port.
        /// </summary>
        public OptionPort OpponentPort;


        /// <summary>
        /// Constructor of the option port element class.
        /// </summary>
        /// <param name="edgeConnectorCallback">The option edge connector callback to set for.</param>
        /// <param name="orientation">The orientation to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        public OptionPort
        (
            OptionEdgeConnectorCallback edgeConnectorCallback,
            Orientation orientation,
            Direction direction,
            Capacity capacity
        )
            : base(edgeConnectorCallback, orientation, direction, capacity)
        {
            OpponentPort = null;
        }


        // ----------------------------- Serialization -----------------------------
        ///// <inheritdoc />
        //public override void Save(OptionPortModel model)
        //{
        //    model.Guid = name;
        //    model.LabelText = portName;
        //}


        ///// <inheritdoc />
        //public override void Load(OptionPortModel model)
        //{
        //    name = model.Guid;
        //    portName = model.LabelText;
        //}


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(Edge edge)
        {
            base.Disconnect(edge);

            this.HideConnectStyle();
            
            OpponentPort = null;
        }


        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                // get connecting edge
                var edge = (OptionEdge)connections.First();

                // Disconnect ports.
                {
                    if (direction == Direction.Output)
                    {
                        edge.View.Input.Disconnect(edge);
                    }
                    else
                    {
                        edge.View.Output.Disconnect(edge);
                    }

                    base.Disconnect(edge);
                }
                
                // Remove edge from graph viewer.
                graphViewer.Remove(edge);
            }
        }


        /// <summary>
        /// Hide the opponent port's connect style if it's not connecting to other option port. 
        /// </summary>
        public void HideOpponentConnectStyle()
        {
            if (OpponentPort?.connected == false)
            {
                // If the opponent port is no longer connecting remove it from connect style class.
                OpponentPort.HideConnectStyle();
            }
        }
    }
}