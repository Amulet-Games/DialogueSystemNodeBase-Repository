using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Dialogue system's channel edge connector listener.
    /// </summary>
    public class ChannelEdgeConnectorListener : EdgeConnectorListenerBase
    {
        /// <summary>
        /// The option port that owns this listener.
        /// </summary>
        OptionPort owner;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the channel edge connector listener class.
        /// </summary>
        /// <param name="owner">The dialogue system option port owner to set for the listener.</param>
        /// <param name="connectorWindow">Dialogue system's node creation connector window module.</param>
        public ChannelEdgeConnectorListener
        (
            OptionPort owner,
            NodeCreationConnectorWindow connectorWindow
        )
            : base(connectorWindow)
        {
            this.owner = owner;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void EdgeConnectedAction(Edge edge)
        {
            ChannelEdgeCallbacks.Register(edge);
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

            // Assign connected USS style class to both option output's and input's port.
            ShowCurrentBothConnectedStyle();

            void HidePreviousOpponentConnectedStyle()
            {
                OptionPort opponentPort;

                if (owner.IsInput())
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.HideConnectedStyleOpponent(isOutput: true);

                    // Update temporay opponent port reference.
                    opponentPort = (OptionPort)edge.output;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.HideConnectedStyleOpponent(isOutput: false);
                }
                else
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.HideConnectedStyleOpponent(isOutput: false);

                    // Update temporay opponent port reference.
                    opponentPort = (OptionPort)edge.input;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.HideConnectedStyleOpponent(isOutput: true);
                }

                owner.OpponentPort = opponentPort;
                opponentPort.OpponentPort = owner;
            }

            void ShowCurrentBothConnectedStyle()
            {
                OptionChannelHelper.ShowConnectedStyleBoth(targetEdge: edge);
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
                    horizontalAlignType: C_Alignment_HorizontalType.Left,

                    // Option channel connector type.
                    creationConnectorType: P_ConnectorType.OptionChannel,

                    // Connector port.
                    connectorPort: owner,

                    // Option channel's input search entries.
                    toShowSearchEntries: NodeCreationEntriesProvider.OptionChannelInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    horizontalAlignType: C_Alignment_HorizontalType.Right,

                    // Option channel connector type.
                    creationConnectorType: P_ConnectorType.OptionChannel,

                    // Connector port.
                    connectorPort: owner,

                    // Option channel's output search entries.
                    toShowSearchEntries: NodeCreationEntriesProvider.OptionChannelOutputEntries
                );
            }

            // Open window.
            NodeCreationConnectorWindow.Open
            (
                screenPositionToShow: GraphViewer.GetCurrentEventMousePosition()
            );
        }
    }
}