using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public partial class OptionPort : PortFrameBase<OptionPortData>
    {
        /// <summary>
        /// The current connecting opponent option port.
        /// </summary>
        public OptionPort OpponentPort;


        // ----------------------------- Constructor -----------------------------
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
        public override void Save(OptionPortData data)
        {
            data.GUID = name;
            data.LabelText = portName;
        }


        /// <inheritdoc />
        public override void Load(OptionPortData data)
        {
            name = data.GUID;
            portName = data.LabelText;
        }


        // ----------------------------- Disconnect -----------------------------
        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                var edge = (OptionEdge)connections.First();

                edge.Disconnect();

                graphViewer.Remove(edge);
            }
        }


        // ----------------------------- Hide Opponent Connect Style -----------------------------
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