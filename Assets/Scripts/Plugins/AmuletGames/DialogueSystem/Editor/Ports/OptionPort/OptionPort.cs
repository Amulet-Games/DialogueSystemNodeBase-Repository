using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public partial class OptionPort : PortFrameBase<OptionPortModel>
    {
        /// <summary>
        /// The current connecting opponent option port.
        /// </summary>
        public OptionPort OpponentPort;


        /// <summary>
        /// Constructor of the option port element class.
        /// </summary>
        /// <param name="orientation">Vertical or horizontal.</param>
        /// <param name="direction">Input or output.</param>
        /// <param name="capacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected OptionPort
        (
            Orientation orientation,
            Direction direction,
            Capacity capacity,
            Type type
        )
            : base(orientation, direction, capacity, type)
        {
            OpponentPort = null;
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(OptionPortModel model)
        {
            model.GUID = name;
            model.LabelText = portName;
        }


        /// <inheritdoc />
        public override void Load(OptionPortModel model)
        {
            name = model.GUID;
            portName = model.LabelText;
        }


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