using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
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


        /// <summary>
        /// Reference of the dialogue system's node that the track is created for.
        /// </summary>
        public DSNodeBase Node;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system's option track component.
        /// </summary>
        public DSOptionTrack()
        {
            SavedPortGuid = Guid.NewGuid().ToString();
            SavedPortLabelText = DSStringsConfig.OptionChannelEmptyTrackLabelText;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this track.
        /// </summary>
        /// <param name="node">Reference of the node that creating this track.</param>
        /// <returns>A new track that has its port set up.</returns>
        public void SetupTrack(DSNodeBase node)
        {
            SetupRefs();

            GetNewTrackPort();

            AddTrackToContainer();

            void SetupRefs()
            {
                Node = node;
            }

            void GetNewTrackPort()
            {
                Port = DSOptionPort.GetNewTrackPort<Edge>(this);
            }

            void AddTrackToContainer()
            {
                node.inputContainer.Add(Port);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called when the connecting node is created manually by an opponent option
        /// <br>channel entry's connector and after a few frames has passed.</br>
        /// </summary>
        /// <param name="connectorEntryPort">Reference of the opponent option entry that started the node creation.</param>
        public void NodeDelayedManualCreatedAction(Port connectorEntryPort)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                // Apply the final position result to the node.
                Node.SetPosition(new Rect(result, DSVector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // Create local reference for the connector port as a dialogue system's option port.
                DSOptionPort optionPort = (DSOptionPort)connectorEntryPort;

                // If the option port is connecting to another entry,
                // disconnect them and hide that entry connected style.
                if (optionPort.connected)
                {
                    DSOptionChannelUtility.HideTrackConnectedStyle(optionPort.PreviousOpponentPort);
                    Node.GraphView.DisconnectPort(optionPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge = Node.GraphView.ConnectPorts(optionPort, Port);

                // Add connected styles.
                DSOptionChannelUtility.ShowBothConnectedStyle(edge);

                // Register channel edge callbacks to the edge.
                DSChannelEdgeCallbacks.Register(edge);

                // Register previous opponent port references.
                Port.PreviousOpponentPort = optionPort;
                optionPort.PreviousOpponentPort = Port;
            }
        }


        /// <summary>
        /// Action that called when the connecting node is going to be deleted by users from the graph manually.
        /// </summary>
        public void NodePreManualRemovedAction()
        {
            // If the track port is connecting to an opponent entry, disconnect them.
            if (Port.connected)
            {
                DisconnectPort();
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


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <summary>
        /// Methods for adding menu items to the connecting node's contextual menu, 
        /// <br>items are added at the end of the current item list.</br>
        /// <para>This method is used inside the node's DSNodeFrameBase class, "BuildContextualManu" method.</para>
        /// </summary>
        /// <param name="evt">The event holding the connecting node's contextual menu to populate.</param>
        public void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectTrackPortAction();

            void AppendDisconnectTrackPortAction()
            {
                evt.menu.AppendAction
                (
                    // Menu item name.
                    Port.connected ? DSStringUtility.New(DSStringsConfig.DisconnectTrackPortLabelText, Port.portName).ToString() : DSStringsConfig.DisconnectInputPortLabelText,
                    // Menu item action.
                    actionEvent => DisconnectPort(),
                    // Menu item status.
                    Port.connected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );
            }
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect track port from its current opponent entry port.
        /// </summary>
        public void DisconnectPort()
        {
            // Hide both entry and track port's connected style.
            DSOptionChannelUtility.HideBothConnectedStyle(Port, Port.PreviousOpponentPort);

            // Disconnect the ports.
            Node.GraphView.DisconnectPort(Port);
        }
    }
}