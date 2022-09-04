using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSOptionPort : Port
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
        protected DSOptionPort(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type) : base(portOrientation, portDirection, portCapacity, type)
        {
            PreviousOpponentPort = null;
        }


        // ----------------------------- Maker -----------------------------
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

            AddStyleSheet();

            InitalizePortDetail();

            SetupEdgeConnector();

            OverridePortDefaultStyle();

            return newEntryPort;

            void CreateNewInstance()
            {
                newEntryPort = new DSOptionPort(Orientation.Horizontal, Direction.Output, Capacity.Single, typeof(float));
            }

            void AddStyleSheet()
            {
                newEntryPort.styleSheets.Add(DSStylesConfig.DSEntriesStyle);
            }

            void InitalizePortDetail()
            {
                newEntryPort.name = optionEntry.SavedPortGuid;
                newEntryPort.portName = optionEntry.SavedPortLabelText;
                newEntryPort.portColor = DSOptionChannelUtility.ChannelColor;
            }

            void SetupEdgeConnector()
            {
                newEntryPort.m_EdgeConnector = new EdgeConnector<TEdge>(new DSDefaultEdgeConnectorListener());

                // Add default and custom channel's edge connector listener to the port.
                newEntryPort.AddManipulator(newEntryPort.m_EdgeConnector);
                newEntryPort.AddManipulator(new EdgeConnector<TEdge>(new DSChannelEdgeConnectorListener(newEntryPort)));
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
                newEntryPort.AddToClassList(DSStylesConfig.Channel_Entry_Port);
                newEntryPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Channel_Entry_Connector);
                newEntryPort.m_ConnectorText.AddToClassList(DSStylesConfig.Channel_Entry_Label);
                newEntryPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Channel_Entry_Cap);
            }
        }


        /// <summary>
        /// Factory method for creating a new option track port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <returns>A track port that can connect to the same channel of entry from another node, or nodes if capacity is set to multiple.</returns>
        public static DSOptionPort GetNewTrackPort<TEdge>()
            where TEdge : Edge, new()
        {
            DSOptionPort newTrackPort;

            CreateNewInstance();

            AddStyleSheet();

            InitalizePortDetail();

            SetupEdgeConnector();

            OverridePortDefaultStyle();

            return newTrackPort;

            void CreateNewInstance()
            {
                newTrackPort = new DSOptionPort(Orientation.Horizontal, Direction.Input, Capacity.Single, typeof(float));
            }

            void AddStyleSheet()
            {
                newTrackPort.styleSheets.Add(DSStylesConfig.DSTracksStyle);
            }

            void InitalizePortDetail()
            {
                newTrackPort.name = Guid.NewGuid().ToString();
                newTrackPort.portName = DSStringsConfig.OptionChannelTrackLabelTextEmpty;
                newTrackPort.portColor = DSOptionChannelUtility.ChannelColor;
            }

            void SetupEdgeConnector()
            {
                newTrackPort.m_EdgeConnector = new EdgeConnector<TEdge>(new DSDefaultEdgeConnectorListener());

                // Add default and custom channel's edge connector listener to the port.
                newTrackPort.AddManipulator(newTrackPort.m_EdgeConnector);
                newTrackPort.AddManipulator(new EdgeConnector<TEdge>(new DSChannelEdgeConnectorListener(newTrackPort)));
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
                newTrackPort.AddToClassList(DSStylesConfig.Channel_Track_Port);
                newTrackPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Channel_Track_Connector);
                newTrackPort.m_ConnectorText.AddToClassList(DSStylesConfig.Channel_Track_Label);
                newTrackPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Channel_Track_Cap);
            }
        }


        // ----------------------------- Check Opponent Connected Style -----------------------------
        /// <summary>
        /// Hide the opponent port's connected style if it's not in connecting state anymore. 
        /// </summary>
        /// <param name="isOpponentEntry">True if opponent port is belong to an entry, false suggests it's belong to a track.</param>
        public void CheckOpponentConnectedStyle(bool isOpponentEntry)
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