using System.Collections.Generic;
using System.Linq;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DSOptionWindow
    {
        /// <summary>
        /// A special type of output ports that'll only connect with the input port which has the same channel type.
        /// </summary>
        [SerializeField] List<DSOptionWindowEntry> windowEntries;


        /// <summary>
        /// The internal window entry list count.
        /// </summary>
        [SerializeField] int windowEntriesCount;


        /// <summary>
        /// Reference of the dialogue system's node that the window is created for.
        /// </summary>
        DSNodeBase node;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window.
        /// </summary>
        /// <param name="node">Node of which this window is going to be connect upon.</param>
        public DSOptionWindow(DSNodeBase node)
        {
            this.node = node;

            windowEntries = new List<DSOptionWindowEntry>();
            windowEntriesCount = 0;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed for the window entry.
        /// </summary>
        /// <param name="source">The another window entry that has the values to this new window entry to load from if it's provided.</param>
        public void GetNewOptionWindowEntry(DSOptionWindowEntry source)
        {
            DSOptionWindowEntry newWindowEntry;

            Button entryRemoveButton;

            CreateNewEntry();

            GetNewEntryPort();

            SetupEntryRemoveButton();

            AddButtonToEntryPort();

            WindowEntryAddedAction();

            void CreateNewEntry()
            {
                newWindowEntry = new DSOptionWindowEntry(source);
            }

            void GetNewEntryPort()
            {
                newWindowEntry.Port = DSOptionPort.GetNewWindowEntryPort<Edge>(newWindowEntry, node.GraphView);
            }

            void SetupEntryRemoveButton()
            {
                entryRemoveButton = DSChannelsMaker.GetNewEntryRemoveButton(() => RemoveWindowEntryAction(newWindowEntry));
            }

            void AddButtonToEntryPort()
            {
                newWindowEntry.Port.contentContainer.Add(entryRemoveButton);
            }

            void WindowEntryAddedAction()
            {
                // Add the window entry port to the node output container.
                node.outputContainer.Add(newWindowEntry.Port);

                // Add window entry to the internal list.
                windowEntries.Add(newWindowEntry);

                // Increase the internal window entry list count.
                windowEntriesCount++;

                // Assign new style for the node ouput container when added the first window entry.
                if (windowEntriesCount == 1)
                {
                    ShowWindowStyle();
                }
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Remove the window entry from the window as well as deleting all its children UI elements.
        /// </summary>
        /// <param name="windowEntry">The selected port that is going to be deleted.</param>
        void RemoveWindowEntryAction(DSOptionWindowEntry windowEntry)
        {
            RemoveEntryFromList();

            RemoveEntryPortFromNode();

            UpdateEntriesLabel();

            UpdateWindowStyle();

            void RemoveEntryFromList()
            {
                // Remove the window entry from the internal list.
                windowEntries.Remove(windowEntry);

                // Decrement the internal window entries count.
                windowEntriesCount--;
            }

            void RemoveEntryPortFromNode()
            {
                DSOptionPort port = windowEntry.Port;

                // If the window entry port is in connecting state.
                if (port.connected)
                {
                    // Hide opponent track port connected style.
                    DSOptionChannelUtility.HideTrackConnectedStyle(port.PreviousOpponentPort);

                    // Disconnect the window entry and track ports.
                    node.GraphView.DisconnectPort(port);
                }

                // Remove the window entry port from the node output container.
                node.DeletePortElement(port, Direction.Output);
            }

            void UpdateEntriesLabel()
            {
                // Check the internal window entry list
                for (int i = 0; i < windowEntriesCount; i++)
                {
                    // If any of the window entries is connecting to a track.
                    if (windowEntries[i].Port.connected)
                    {
                        // Local window entry port reference.
                        Port port = windowEntries[i].Port;

                        // Get its sibiling index in string.
                        string sibilingIndexText = port.GetSiblingIndexAdd(1).ToString();

                        // Set their label with the index.
                        port.portName = DSStringUtility.New(DSStringsConfig.OptionChannelEntryLabelText, sibilingIndexText).ToString();

                        // Set the track port's label with the index.
                        port.connections.First().input.portName = DSStringUtility.New(DSStringsConfig.OptionChannelTrackLabelText, sibilingIndexText).ToString();
                    }
                }
            }

            void UpdateWindowStyle()
            {
                if (windowEntriesCount == 0)
                {
                    HideWindowStyle();
                }
            }
        }


        /// <summary>
        /// Action that called when the connecting node is created manually by the opponent
        /// <br>option channel track's connector.</br>
        /// </summary>
        public void NodeManualCreatedAction()
        {
            // Create a new window entry within the window.
            GetNewOptionWindowEntry(null);

            // Refresh Ports Layout.
            node.RefreshPorts();
        }


        /// <summary>
        /// Action that a few frames after the "NodeManualCreatedAction".</br>
        /// </summary>
        /// <param name="connectorTrackPort">Reference of the opponent option track that started the node creation.</param>
        public void NodeDelayedManualCreatedAction(Port connectorTrackPort)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = node.localBound.position;

                // Height offset.
                result.y -= (node.titleContainer.worldBound.height + windowEntries[0].Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / node.GraphView.scale;

                // Width offset.
                result.x -= node.localBound.width;

                // Apply the final position result to the node.
                node.SetPosition(new Rect(result, DSVector2Utility.Zero));
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
                    node.GraphView.DisconnectPort(optionPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge = node.GraphView.ConnectPorts(windowEntries[0].Port, optionPort);

                // Add connected styles.
                DSOptionChannelUtility.ShowBothConnectedStyle(edge);

                // Register channel edge callbacks to the edge.
                DSChannelEdgeCallbacks.Register(edge);

                // Register previous opponent port references.
                windowEntries[0].Port.PreviousOpponentPort = optionPort;
                optionPort.PreviousOpponentPort = windowEntries[0].Port;
            }
        }


        /// <summary>
        /// Action that called when the connecting node is going to be deleted by users from the graph manually.
        /// </summary>
        public void NodePreManualRemovedAction()
        {
            for (int i = 0; i < windowEntriesCount; i++)
            {
                // If the window entry port is connecting to an opponent track, disconnect them.
                if (windowEntries[i].Port.connected)
                {
                    windowEntries[i].DisconnectPort(node);
                }
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save window entry's value from another previously created window entry.
        /// </summary>
        /// <param name="source">The window entry to save its values from.</param>
        public void SaveWindowValues(DSOptionWindow source)
        {
            List<DSOptionWindowEntry> sourceOptionEntries = source.windowEntries;

            // Save internal window's entries
            for (int i = 0; i < source.windowEntriesCount; i++)
            {
                DSOptionWindowEntry newWindowEntry = new DSOptionWindowEntry();
                newWindowEntry.SaveEntryValues(sourceOptionEntries[i]);
                windowEntries.Add(newWindowEntry);
            }

            // Save the internal window entries' count.
            windowEntriesCount = source.windowEntriesCount;
        }


        /// <summary>
        /// Load window entry's value from another previously saved window entry.
        /// </summary>
        /// <param name="source">The window entry to load its values from.</param>
        public void LoadWindowValues(DSOptionWindow source)
        {
            List<DSOptionWindowEntry> sourceOptionEntries = source.windowEntries;

            // Load from the source window's entries
            for (int i = 0; i < source.windowEntriesCount; i++)
            {
                GetNewOptionWindowEntry(sourceOptionEntries[i]);
            }
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
            AppendDisconnectEntryPortsAction();

            void AppendDisconnectEntryPortsAction()
            {
                for (int i = 0; i < windowEntriesCount; i++)
                {
                    // Cache a local reference for windowEntries[i]
                    DSOptionWindowEntry windowEntry = windowEntries[i];

                    if (windowEntry.Port.connected)
                    {
                        evt.menu.AppendAction
                        (
                            // Menu item name.
                            DSStringUtility.New(DSStringsConfig.DisconnectEntryPortLabelText, windowEntry.Port.portName).ToString(),
                            // Menu item action.
                            actionEvent => windowEntry.DisconnectPort(node),
                            // Menu item status.
                            DropdownMenuAction.Status.Normal
                        );
                    }
                }
            }
        }


        /// <summary>
        /// Is there any window entry port connecting to the other option tracks within the window?
        /// </summary>
        /// <returns>Returns true if any of the window entry ports within the window are connecting.</returns>
        public bool IsWindowEntriesConnected()
        {
            for (int i = 0; i < windowEntriesCount; i++)
            {
                if (windowEntries[i].Port.connected) return true;
            }

            return false;
        }


        /// <summary>
        /// Disconnect all the window entry ports within the window if they're connecting.
        /// </summary>
        public void DisconnectEntryPorts()
        {
            for (int i = 0; i < windowEntriesCount; i++)
            {
                if (windowEntries[i].Port.connected)
                {
                    windowEntries[i].DisconnectPort(node);
                }
            }
        }


        // ----------------------------- Set Window Style Tasks -----------------------------
        /// <summary>
        /// Assign the window style for the node output container when it has one window entry.
        /// </summary>
        void ShowWindowStyle()
        {
            node.outputContainer.AddToClassList(DSStylesConfig.Node_Output_Container_Window);
        }


        /// <summary>
        /// Hide the assigned window style from the node output container when it has no window entry.
        /// </summary>
        void HideWindowStyle()
        {
            node.outputContainer.RemoveFromClassList(DSStylesConfig.Node_Output_Container_Window);
        }
    }
}