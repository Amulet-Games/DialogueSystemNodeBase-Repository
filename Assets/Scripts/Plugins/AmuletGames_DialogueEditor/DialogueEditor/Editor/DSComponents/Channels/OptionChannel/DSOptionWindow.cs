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
        [SerializeField] List<DSOptionEntry> optionEntries;


        /// <summary>
        /// The internal option enteries list number count.
        /// </summary>
        int optionEntriesCount;


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
            optionEntries = new List<DSOptionEntry>();
            optionEntriesCount = 0;
            this.node = node;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this entry.
        /// </summary>
        /// <param name="source">The another entry that has the values to this new entry to load from if it's provided.</param>
        public void GetNewOptionEntry(DSOptionEntry source)
        {
            DSOptionEntry newEntry;

            Button entryRemoveButton;

            CreateNewEntry();

            GetNewEntryPort();

            SetupEntryRemoveButton();

            AddButtonToEntryPort();

            EntryAddedAction();

            void CreateNewEntry()
            {
                newEntry = source != null ? new DSOptionEntry(source) : new DSOptionEntry(null);
            }

            void GetNewEntryPort()
            {
                newEntry.Port = DSOptionPort.GetNewEntryPort<Edge>(newEntry, node.GraphView);
            }

            void SetupEntryRemoveButton()
            {
                entryRemoveButton = DSChannelsMaker.GetNewEntryRemoveButton(() => RemoveOptionEntryAction(newEntry));
            }

            void AddButtonToEntryPort()
            {
                newEntry.Port.contentContainer.Add(entryRemoveButton);
            }

            void EntryAddedAction()
            {
                // Add the entry port to the node output container.
                node.outputContainer.Add(newEntry.Port);

                // Add entry to the internal list.
                optionEntries.Add(newEntry);

                // Increase the internal entry list count.
                optionEntriesCount++;

                // Assign new style for node ouput container for the first entry added.
                if (optionEntriesCount == 1)
                {
                    ShowWindowStyle();
                }
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Remove the option entry from the window as well as deleting all its children UI elements.
        /// </summary>
        /// <param name="entry">The selected port that is going to be deleted.</param>
        void RemoveOptionEntryAction(DSOptionEntry entry)
        {
            RemoveEntryFromList();

            RemoveEntryPortFromNode();

            UpdateEntriesLabel();

            UpdateWindowStyle();

            void RemoveEntryFromList()
            {
                // Remove the entry from this window's internal list.
                optionEntries.Remove(entry);

                // Decrement the internal option entries count.
                optionEntriesCount--;
            }

            void RemoveEntryPortFromNode()
            {
                DSOptionPort entryPort = entry.Port;

                // If the entry is in connecting state.
                if (entryPort.connected)
                {
                    // Hide opponent track port connected style.
                    DSOptionChannelUtility.HideTrackConnectedStyle(entryPort.PreviousOpponentPort);

                    // Disconnect the entry and track ports.
                    node.GraphView.DisconnectPorts(entryPort);
                }

                // Remove the entry port from the node output container.
                node.DeletePortElement(entryPort, N_PortContainerType.Output);
            }

            void UpdateEntriesLabel()
            {
                // Check the internal entry list
                for (int i = 0; i < optionEntriesCount; i++)
                {
                    // If any of the entries is connecting to a track.
                    if (optionEntries[i].Port.connected)
                    {
                        // Entry port reference.
                        Port entryPort = optionEntries[i].Port;

                        // Get their sibiling index.
                        int sibilingIndex = entryPort.GetSiblingIndex();

                        // Set their label with the index.
                        entryPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelEntryLabelText, sibilingIndex.ToString()).ToString();

                        // Set the track port's label with the index.
                        entryPort.connections.First().input.portName = DSStringUtility.New(DSStringsConfig.OptionChannelTrackLabelText, sibilingIndex.ToString()).ToString();
                    }
                }
            }

            void UpdateWindowStyle()
            {
                if (optionEntriesCount == 0)
                {
                    HideWindowStyle();
                }
            }
        }


        /// <summary>
        /// Check if entry port is connected and if so add connected style to it, 
        /// <br>and register MouseMoveEvent to the edge that were created during the loading phrase.</br>
        /// </summary>
        public void PostLoadingSetupElementsAction()
        {
            for (int i = 0; i < optionEntriesCount; i++)
            {
                optionEntries[i].PostLoadingSetup();
            }
        }


        /// <summary>
        /// Action that called when a node that has the option window is added on the graph by users,
        /// <br>when a option channel edge was dropped in a empty space on the graph.</br>
        /// </summary>
        /// <param name="connectorTrackPort">Reference of the option track that started the node creation.</param>
        public void NodeManualCreationSetupAction(Port connectorTrackPort)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = node.localBound.position;

                // Height offset.
                result.y -= (node.titleContainer.worldBound.height + optionEntries[0].Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / node.GraphView.scale;

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
                    node.GraphView.DisconnectPorts(optionPort);
                }

                // Create an new edge.
                Edge edge = new Edge()
                {
                    output = optionEntries[0].Port,
                    input = optionPort
                };

                // Connect to the edge.
                optionEntries[0].Port.Connect(edge);
                optionPort.Connect(edge);

                // Add the edge to the graph.
                node.GraphView.Add(edge);

                // Add connected styles.
                if (optionPort.connected)
                {
                    DSOptionChannelUtility.ShowEntryConnectedStyle(optionEntries[0].Port, optionEntries[0].Port.GetSiblingIndex());
                }
                else
                {
                    DSOptionChannelUtility.ShowBothConnectedStyle(edge);
                }

                // Register MouseMoveEvent to the edge.
                DSChannelEdgeEventRegister.RegisterMouseEvents(edge);

                // Register previous opponent port references.
                optionEntries[0].Port.PreviousOpponentPort = optionPort;
                optionPort.PreviousOpponentPort = optionEntries[0].Port;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save entry's value from another previously created entry.
        /// </summary>
        /// <param name="source">The entry to save its values from.</param>
        public void SaveWindowValues(DSOptionWindow source)
        {
            List<DSOptionEntry> sourceOptionEntries = source.optionEntries;

            // Save channel's entries
            for (int i = 0; i < source.optionEntriesCount; i++)
            {
                DSOptionEntry newOptionEntry = new DSOptionEntry();
                newOptionEntry.SaveEntryValues(sourceOptionEntries[i]);
                optionEntries.Add(newOptionEntry);
            }

            // Save the internal option entries' count.
            optionEntriesCount = source.optionEntriesCount;
        }


        /// <summary>
        /// Load entry's value from another previously saved entry.
        /// </summary>
        /// <param name="source">The entry to load its values from.</param>
        public void LoadWindowValues(DSOptionWindow source)
        {
            List<DSOptionEntry> sourceOptionEntries = source.optionEntries;
            for (int i = 0; i < source.optionEntriesCount; i++)
            {
                GetNewOptionEntry(sourceOptionEntries[i]);
            }
        }


        // ----------------------------- Check Window's Opponent Connected Style -----------------------------
        /// <summary>
        /// Check the current window's entries connecting status and if they're not connecting,
        /// <br>hide their previous opponent track's connected style.</br>
        /// </summary>
        public void CheckOpponentTracksConnectedStyle()
        {
            for (int i = 0; i < optionEntriesCount; i++)
            {
                optionEntries[i].CheckOpponentConnectedStyle();
            }
        }


        // ----------------------------- Set Window Style Tasks -----------------------------
        /// <summary>
        /// Assign the window style for the node output container when it has one option entry.
        /// </summary>
        void ShowWindowStyle()
        {
            node.outputContainer.AddToClassList(DSStylesConfig.Node_Output_Container_Window);
        }


        /// <summary>
        /// Hide the assigned window style from the node output container when it has no option entry.
        /// </summary>
        void HideWindowStyle()
        {
            node.outputContainer.RemoveFromClassList(DSStylesConfig.Node_Output_Container_Window);
        }
    }
}