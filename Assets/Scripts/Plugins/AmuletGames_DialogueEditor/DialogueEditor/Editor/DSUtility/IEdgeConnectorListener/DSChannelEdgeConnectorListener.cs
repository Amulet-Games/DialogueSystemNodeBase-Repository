using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Listener that detects whenever an option channel's edge was dragged and released within the custom editor graph.
    /// <para></para>
    /// <br>Used by EdgeConnector manipulator to finish the actual edge creation.</br>
    /// <br>Its an interface the user can override and create edges in a different way.</br>
    /// </summary>
    public class DSChannelEdgeConnectorListener : IEdgeConnectorListener
    {
        /// <summary>
        /// The dialogue system option port that owns the listener.
        /// </summary>
        DSOptionPort owner;


        /// <summary>
        /// Reference of the dialogue system's node creation connector window module.
        /// </summary>
        DSNodeCreationConnectorWindow nodeCreationConnectorWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system channel edge connector listener.
        /// </summary>
        /// <param name="owner">The dialogue system option port owner to set for the listener.</param>
        /// <param name="nodeCreationConnectorWindow">Dialogue system's node creation connector window module.</param>
        public DSChannelEdgeConnectorListener
        (
            DSOptionPort owner, 
            DSNodeCreationConnectorWindow nodeCreationConnectorWindow
        )
        {
            this.owner = owner;
            this.nodeCreationConnectorWindow = nodeCreationConnectorWindow;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the GraphView.</param>
        /// <param name="edge">The edge being created.</param>
        public void OnDrop(GraphView graphView, Edge edge)
        {
            // Check both the owner and the owner's opponent port in which,
            // if their previous opponent port is disconnected after this event, if so hide their connected style.
            HidePreviousOpponentsConnectedStyle();

            // Assign connected style to both option entry's and track's port.
            DSOptionChannelUtility.ShowBothConnectedStyle(edge);

            // Register MouseMoveEvent to the edge that is connecting the two. 
            DSChannelEdgeEventRegister.RegisterMouseEvents(edge.output.connections.First());

            void HidePreviousOpponentsConnectedStyle()
            {
                DSOptionPort opponentPort;

                if (owner.IsInput())
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.CheckOpponentConnectedStyle(true);

                    // Update temporay opponent port reference.
                    opponentPort = (DSOptionPort)edge.output;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.CheckOpponentConnectedStyle(false);
                }
                else
                {
                    // Check owner previous connected port is connecting anymore, if not hide it's connected style.
                    owner.CheckOpponentConnectedStyle(false);

                    // Update temporay opponent port reference.
                    opponentPort = (DSOptionPort)edge.input;

                    // Check the temporay opponent port's previous connected port is connecting anymore, if not hide it's connected style.
                    opponentPort.CheckOpponentConnectedStyle(true);
                }

                owner.PreviousOpponentPort = opponentPort;
                opponentPort.PreviousOpponentPort = owner;
            }
        }

        
        /// <summary>
        /// Called when a new edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                nodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the left side.
                    C_Alignment_HorizontalType.Left,

                    // Option channel connector type.
                    N_NodeCreationConnectorType.OptionChannel,

                    // Connector port.
                    owner,

                    // Option channel's track search entries.
                    DSNodeCreationEntriesProvider.OptionChannelTrackEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                nodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    C_Alignment_HorizontalType.Right,

                    // Option channel connector type.
                    N_NodeCreationConnectorType.OptionChannel,

                    // Connector port.
                    owner,

                    // Option channel's track search entries.
                    DSNodeCreationEntriesProvider.OptionChannelEntryEntries
                );
            }

            // Open window.
            nodeCreationConnectorWindow.Open(DSGraphView.GetCurrentEventMousePosition());
        }
    }
}