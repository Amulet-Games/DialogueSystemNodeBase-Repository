using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system's channel edge connector listener.
    /// </summary>
    public class DSChannelEdgeConnectorListener : EdgeConnectorListenerBase
    {
        /// <summary>
        /// The dialogue system option port that owns the listener.
        /// </summary>
        DSOptionPort owner;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system channel edge connector listener.
        /// </summary>
        /// <param name="owner">The dialogue system option port owner to set for the listener.</param>
        /// <param name="nodeCreationConnectorWindow">Dialogue system's node creation connector window module.</param>
        public DSChannelEdgeConnectorListener(DSOptionPort owner, DSNodeCreationConnectorWindow nodeCreationConnectorWindow)
            : base(nodeCreationConnectorWindow)
        {
            this.owner = owner;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void EdgeConnectedAction(Edge edge)
        {
            DSChannelEdgeCallbacks.Register(edge);
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override void OnDrop(GraphView graphView, Edge edge)
        {
            // Execute the base onDrop method.
            base.OnDrop(graphView, edge);

            // Check both the owner and the owner's opponent port in which,
            // if their previous opponent port is disconnected after this event, if so hide their connected style.
            HidePreviousOpponentConnectedStyle();

            // Assign connected style to both option entry's and track's port.
            ShowCurrentBothConnectedStyle();

            void HidePreviousOpponentConnectedStyle()
            {
                DSOptionPort opponentPort;

                if (owner.IsInput())
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.HideOpponentConnectedStyle(true);

                    // Update temporay opponent port reference.
                    opponentPort = (DSOptionPort)edge.output;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.HideOpponentConnectedStyle(false);
                }
                else
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.HideOpponentConnectedStyle(false);

                    // Update temporay opponent port reference.
                    opponentPort = (DSOptionPort)edge.input;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.HideOpponentConnectedStyle(true);
                }

                owner.PreviousOpponentPort = opponentPort;
                opponentPort.PreviousOpponentPort = owner;
            }

            void ShowCurrentBothConnectedStyle()
            {
                DSOptionChannelUtility.ShowBothConnectedStyle(edge);
            }
        }


        /// <inheritdoc />
        public override void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the left side.
                    C_Alignment_HorizontalType.Left,

                    // Option channel connector type.
                    P_ConnectorType.OptionChannel,

                    // Connector port.
                    owner,

                    // Option channel's track search entries.
                    DSNodeCreationEntriesProvider.OptionChannelTrackEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    C_Alignment_HorizontalType.Right,

                    // Option channel connector type.
                    P_ConnectorType.OptionChannel,

                    // Connector port.
                    owner,

                    // Option channel's track search entries.
                    DSNodeCreationEntriesProvider.OptionChannelEntryEntries
                );
            }

            // Open window.
            NodeCreationConnectorWindow.Open(DSGraphView.GetCurrentEventMousePosition());
        }
    }
}