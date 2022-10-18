using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSOptionPort : DSPortBase
    {
        /// <summary>
        /// The opponent option port that was previous connected to.
        /// <br>It'll be updated each time the port connects to a opponent.</br>
        /// </summary>
        public DSOptionPort PreviousOpponentPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system option port.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected DSOptionPort(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type)
            : base(portOrientation, portDirection, portCapacity, type)
        {
            PreviousOpponentPort = null;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <inheritdoc />
        public override void ConnectedEdgeLoadedAction(Edge edge)
        {
            // Get all the necessary references.
            DSOptionPort opponentTrackPort = (DSOptionPort)edge.input;

            // Add connected style to the internal port and opponent track port.
            DSOptionChannelUtility.AddToEntryConnectedClass(this);
            DSOptionChannelUtility.AddToTrackConnectedClass(opponentTrackPort);

            // Register MouseMoveEvent to the edge that the ports is connecting with.
            DSChannelEdgeCallbacks.Register(edge);

            // Register previous opponent port references to both the internal port and opponent track port.
            PreviousOpponentPort = opponentTrackPort;
            opponentTrackPort.PreviousOpponentPort = this;
        }


        // ----------------------------- Maker -----------------------------
        /// <summary>
        /// Factory method for creating a new option track port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="optionTrack">The dialogue system option channel track that the port is related to.</param>
        /// <returns>A track port that can connect to the same channel of entry from another node, or nodes if capacity is set to multiple.</returns>
        public static DSOptionPort GetNewTrackPort<TEdge>(DSOptionTrack optionTrack)
            where TEdge : Edge, new()
        {
            DSOptionPort newTrackPort;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newTrackPort;

            void CreateNewInstance()
            {
                newTrackPort = new DSOptionPort(Orientation.Horizontal, Direction.Input, Capacity.Single, typeof(float));
            }

            void SetupDetail()
            {
                newTrackPort.name = optionTrack.SavedPortGuid;
                newTrackPort.portName = optionTrack.SavedPortLabelText;
                newTrackPort.portColor = DSPortColorsConfig.OptionChannelPortColor;
            }

            void SetupEdgeConnector()
            {
                // Channel edge connector listener.
                newTrackPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DSChannelEdgeConnectorListener
                    (
                        newTrackPort,
                        optionTrack.Node.GraphView.NodeCreationConnectorWindow
                    )
                );

                newTrackPort.AddManipulator(newTrackPort.m_EdgeConnector);
            }

            void AddStyleSheet()
            {
                newTrackPort.styleSheets.Add(DSStylesConfig.DSOptionTracksStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override the cap's defualt picking mode.
                newTrackPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newTrackPort.m_ConnectorBox.name = "";
                newTrackPort.m_ConnectorText.name = "";
                newTrackPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                newTrackPort.AddToClassList(DSStylesConfig.Channel_Option_Track_Port);
                newTrackPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Channel_Option_Track_Connector);
                newTrackPort.m_ConnectorText.AddToClassList(DSStylesConfig.Channel_Option_Track_Label);
                newTrackPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Channel_Option_Track_Cap);
            }
        }


        /// <summary>
        /// Factory method for creating a new option entry port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="optionEntry">The dialogue system option channel entry that the port is related to.</param>
        /// <returns>A entry port that can connect to the same channel of track from another node, or nodes if capacity is set to multiple.</returns>
        public static DSOptionPort GetNewEntryPort<TEdge>(DSOptionEntry optionEntry)
            where TEdge : Edge, new()
        {
            DSOptionPort newEntryPort;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newEntryPort;

            void CreateNewInstance()
            {
                newEntryPort = new DSOptionPort(Orientation.Horizontal, Direction.Output, Capacity.Single, typeof(float));
            }

            void SetupDetail()
            {
                newEntryPort.name = optionEntry.SavedPortGuid;
                newEntryPort.portName = optionEntry.SavedPortLabelText;
                newEntryPort.portColor = DSPortColorsConfig.OptionChannelPortColor;
            }

            void SetupEdgeConnector()
            {
                // Channel edge connector listener.
                newEntryPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DSChannelEdgeConnectorListener
                    (
                        newEntryPort,
                        optionEntry.Node.GraphView.NodeCreationConnectorWindow
                    )
                );

                newEntryPort.AddManipulator(newEntryPort.m_EdgeConnector);
            }

            void AddStyleSheet()
            {
                newEntryPort.styleSheets.Add(DSStylesConfig.DSOptionEntriesStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override the cap's defualt picking mode.
                newEntryPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newEntryPort.m_ConnectorBox.name = "";
                newEntryPort.m_ConnectorText.name = "";
                newEntryPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                newEntryPort.AddToClassList(DSStylesConfig.Channel_Option_Entry_Port);
                newEntryPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Channel_Option_Entry_Connector);
                newEntryPort.m_ConnectorText.AddToClassList(DSStylesConfig.Channel_Option_Entry_Label);
                newEntryPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Channel_Option_Entry_Cap);
            }
        }


        /// <summary>
        /// Factory method for creating a new option window entry port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="optionWindowEntry">The dialogue system option channel window entry that the port is related to.</param>
        /// <param name="graphView">The dialogue system's graph view module to set for the listener.</param>
        /// <returns>A entry port that can connect to the same channel of track from another node, or nodes if capacity is set to multiple.</returns>
        public static DSOptionPort GetNewWindowEntryPort<TEdge>(DSOptionWindowEntry optionWindowEntry, DSGraphView graphView)
            where TEdge : Edge, new()
        {
            DSOptionPort newEntryPort;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newEntryPort;

            void CreateNewInstance()
            {
                newEntryPort = new DSOptionPort(Orientation.Horizontal, Direction.Output, Capacity.Single, typeof(float));
            }

            void SetupDetail()
            {
                newEntryPort.name = optionWindowEntry.SavedPortGuid;
                newEntryPort.portName = optionWindowEntry.SavedPortLabelText;
                newEntryPort.portColor = DSPortColorsConfig.OptionChannelPortColor;
            }

            void SetupEdgeConnector()
            {
                // Channel edge connector listener.
                newEntryPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DSChannelEdgeConnectorListener
                    (
                        newEntryPort,
                        graphView.NodeCreationConnectorWindow
                    )
                );

                newEntryPort.AddManipulator(newEntryPort.m_EdgeConnector);
            }

            void AddStyleSheet()
            {
                newEntryPort.styleSheets.Add(DSStylesConfig.DSOptionEntriesStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override the cap's defualt picking mode.
                newEntryPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newEntryPort.m_ConnectorBox.name = "";
                newEntryPort.m_ConnectorText.name = "";
                newEntryPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                newEntryPort.AddToClassList(DSStylesConfig.Channel_Option_Window_Entry_Port);
                newEntryPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Channel_Option_Entry_Connector);
                newEntryPort.m_ConnectorText.AddToClassList(DSStylesConfig.Channel_Option_Window_Entry_Label);
                newEntryPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Channel_Option_Entry_Cap);
            }
        }


        // ----------------------------- Hide Opponent Connected Style Services -----------------------------
        /// <summary>
        /// Hide the opponent port's connected style if it's not connecting to other option port. 
        /// </summary>
        /// <param name="isOpponentEntry">True if opponent port is belong to an entry, false suggests it's belong to a track.</param>
        public void HideOpponentConnectedStyle(bool isOpponentEntry)
        {
            if (PreviousOpponentPort != null && !PreviousOpponentPort.connected)
            {
                if (isOpponentEntry)
                {
                    DSOptionChannelUtility.HideEntryConnectedStyle(PreviousOpponentPort);
                }
                else
                {
                    DSOptionChannelUtility.HideTrackConnectedStyle(PreviousOpponentPort);
                }
            }
        }
    }
}