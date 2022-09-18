using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DSOptionTrack
    {
        /// <summary>
        /// The serialized port's Guid id of the track.
        /// </summary>
        public string SavedPortGuid;


        /// <summary>
        /// The serialized port's label text of the track.
        /// </summary>
        public string SavedPortLabelText;


        /// <summary>
        /// Port that can connect to the other same channel type of entry.
        /// </summary>
        public DSOptionPort Port;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option track.
        /// </summary>
        public DSOptionTrack()
        {
            SavedPortGuid = "";
            SavedPortLabelText = "";
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this track.
        /// </summary>
        /// <param name="node">Reference of the node that creating this track.</param>
        /// <returns>A new track that has its port set up.</returns>
        public void SetupTrack(DSNodeBase node)
        {
            GetNewTrackPort();

            AddTrackToContainer();

            void GetNewTrackPort()
            {
                Port = DSOptionPort.GetNewTrackPort<Edge>(node.GraphView);
            }

            void AddTrackToContainer()
            {
                node.inputContainer.Add(Port);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called when a node that has the option track is added on the graph by users,
        /// <br>when a option channel edge was dropped in a empty space on the graph.</br>
        /// </summary>
        /// <param name="node">Reference of the node that owns this track.</param>
        /// <param name="connectorEntryPort">Reference of the option entry that started the node creation.</param>
        public void NodeManualCreationSetupAction(DSNodeBase node, Port connectorEntryPort)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = node.localBound.position;

                // Height offset.
                result.y -= (node.titleContainer.worldBound.height + Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / node.GraphView.scale;

                // Apply the final position result to the node.
                node.SetPosition(new Rect(result, DSVector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // Create local reference for the connector port as a dialogue system's option port.
                DSOptionPort optionPort = (DSOptionPort)connectorEntryPort;

                // If the option port is connecting to another entry,
                // disconnect them and hide that entry connected style.
                if (optionPort.connected)
                {
                    DSOptionChannelUtility.HideEntryConnectedStyle(optionPort.PreviousOpponentPort);
                    node.GraphView.DisconnectPorts(optionPort);
                }

                // Create an new edge.
                Edge edge = new Edge()
                {
                    input = Port,
                    output = optionPort
                };

                // Connect to the edge.
                Port.Connect(edge);
                optionPort.Connect(edge);

                // Add the edge to the graph.
                node.GraphView.Add(edge);

                // Add connected styles.
                if (optionPort.connected)
                {
                    DSOptionChannelUtility.ShowTrackConnectedStyle(Port, optionPort.GetSiblingIndex());
                }
                else
                {
                    DSOptionChannelUtility.ShowBothConnectedStyle(edge);
                }

                // Register MouseMoveEvent to the edge.
                DSChannelEdgeEventRegister.RegisterMouseEvents(edge);

                // Register previous opponent port references.
                Port.PreviousOpponentPort = optionPort;
                optionPort.PreviousOpponentPort = Port;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the track port values from the source.
        /// </summary>
        /// <param name="source">The track to save its values from.</param>
        public void SaveTrackValues(DSOptionTrack source)
        {
            // Save track port's Guid Id.
            SavedPortGuid = source.Port.name;

            // Save track port's label text.
            SavedPortLabelText = source.Port.portName;
        }


        /// <summary>
        /// Load the track port values from the previously saved track.
        /// </summary>
        /// <param name="source">The track to load its values from.</param>
        public void LoadTrackValues(DSOptionTrack source)
        {
            // Load track port's Guid Id.
            Port.name = source.SavedPortGuid;

            // Load track port's label text.
            Port.portName = source.SavedPortLabelText;
        }


        // ----------------------------- Check Track's Opponent Connected Style -----------------------------
        /// <summary>
        /// Hide the track's opponent port's connected style if it's not in connecting state anymore. 
        /// </summary>
        public void CheckOpponentConnectedStyle() => Port.CheckOpponentConnectedStyle(true);
    }
}