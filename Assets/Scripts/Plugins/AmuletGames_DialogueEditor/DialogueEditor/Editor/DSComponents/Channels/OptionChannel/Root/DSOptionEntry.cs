using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DSOptionEntry
    {
        /// <summary>
        /// The serialized port's Guid id of the entry.
        /// </summary>
        public string SavedPortGuid;


        /// <summary>
        /// The serialized port's label text of the entry.
        /// </summary>
        public string SavedPortLabelText;


        /// <summary>
        /// Port that can connect to the other same channel type of track.
        /// </summary>
        public DSOptionPort Port;


        /// <summary>
        /// Reference of the dialogue system's node that the entry is created for.
        /// </summary>
        public DSNodeBase Node { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system's option entry component.
        /// </summary>
        public DSOptionEntry()
        {
            SavedPortGuid = Guid.NewGuid().ToString();
            SavedPortLabelText = DSStringsConfig.OptionChannelEmptyEntryLabelText;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this entry.
        /// </summary>
        /// <param name="node">Reference of the node that creating this entry.</param>
        /// <returns>A new entry that has its port set up.</returns>
        public void SetupEntry(DSNodeBase node)
        {
            SetupRefs();

            GetNewEntryPort();

            AddEntryToContainer();

            void SetupRefs()
            {
                Node = node;
            }

            void GetNewEntryPort()
            {
                Port = DSOptionPort.GetNewEntryPort<Edge>(this);
            }

            void AddEntryToContainer()
            {
                node.outputContainer.Add(Port);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called when the connecting node is created manually by the opponent option
        /// <br>channel track's connector and after a few frames has passed.</br>
        /// </summary>
        /// <param name="connectorTrackPort">Reference of the opponent option track that started the node creation.</param>
        public void NodeDelayedManualCreatedAction(Port connectorTrackPort)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                // Width offset.
                result.x -= Node.localBound.width;

                // Apply the final position result to the node.
                Node.SetPosition(new Rect(result, DSVector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // Create local reference for the connector port as a dialogue system's option port.
                DSOptionPort optionPort = (DSOptionPort)connectorTrackPort;

                // If the option port is connecting to another entry,
                // disconnect them and hide that entry connected style.
                if (optionPort.connected)
                {
                    DSOptionChannelUtility.HideEntryConnectedStyle(optionPort.PreviousOpponentPort);
                    Node.GraphView.DisconnectPort(optionPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge = Node.GraphView.ConnectPorts(Port, optionPort);

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
            // If the entry port is connecting to an opponent track, disconnect them.
            if (Port.connected)
            {
                DisconnectPort();
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the entry values from the source.
        /// </summary>
        /// <param name="source">The entry of which its values are going to be saved in.</param>
        public void SaveEntryValues(DSOptionEntry source)
        {
            // Save entry port's Guid Id.
            SavedPortGuid = source.Port.name;

            // Save entry port's label text.
            SavedPortLabelText = source.Port.portName;
        }


        /// <summary>
        /// Load the entry values from the previously saved entry.
        /// </summary>
        /// <param name="source">The entry that was previosuly saved and now it's used to load from.</param>
        public void LoadEntryValues(DSOptionEntry source)
        {
            // Load entry port's Guid Id.
            Port.name = source.SavedPortGuid;

            // Load entry port's label text.
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
            AppendDisconnectEntryPortAction();

            void AppendDisconnectEntryPortAction()
            {
                evt.menu.AppendAction
                (
                    // Menu item name.
                    Port.connected ? DSStringUtility.New(DSStringsConfig.DisconnectEntryPortLabelText, Port.portName).ToString() : DSStringsConfig.DisconnectOutputPortLabelText,
                    // Menu item action.
                    actionEvent => DisconnectPort(),
                    // Menu item status.
                    Port.connected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );
            }
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect the entry port from its current opponent track port.
        /// </summary>
        public void DisconnectPort()
        {
            // Hide both entry and track port's connected style.
            DSOptionChannelUtility.HideBothConnectedStyle(Port.PreviousOpponentPort, Port);

            // Disconnect the ports.
            Node.GraphView.DisconnectPort(Port);
        }
    }
}