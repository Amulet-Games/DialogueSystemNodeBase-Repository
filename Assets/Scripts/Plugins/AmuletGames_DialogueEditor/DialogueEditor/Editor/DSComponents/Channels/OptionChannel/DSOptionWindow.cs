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
        readonly DSNodeBase node;


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
                newEntry.Port = DSOptionPort.GetNewEntryPort<Edge>(newEntry);
            }

            void SetupEntryRemoveButton()
            {
                entryRemoveButton = DSChannelsMaker.AddEntryRemoveButton(() => RemoveOptionEntryAction(newEntry));
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
        /// <para>OptionEntryRemovedAction - DSOptionEntry - EntryRemoveButton.</para>
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
                Port entryPort = entry.Port;

                // If the entry is in connecting state.
                if (entryPort.connected)
                {
                    // Get the edge that is used from the connection.
                    Edge firstEdge = entryPort.connections.First();

                    // Disconnect the edge from the track port that it's connecting.
                    firstEdge.input.Disconnect(firstEdge);

                    // Hide track port connected style.
                    DSOptionChannelUtility.HideTrackConnectedStyle(firstEdge.input);

                    // Disconnect the edge from the entry port.
                    entryPort.Disconnect(firstEdge);

                    // Lastly remove the edge from the graph.
                    node.GraphView.RemoveElement(firstEdge);
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
        /// <para>PostLoadingSetupAction - DSDialogueNodeCallback</para>
        /// </summary>
        public void PostLoadingSetupAction()
        {
            for (int i = 0; i < optionEntriesCount; i++)
            {
                optionEntries[i].PostLoadingSetup();
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save entry's value from another previously created entry.
        /// </summary>
        /// <param name="source">The entry of which its values are going to be saved in.</param>
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
        /// <param name="source">The entry that was previosuly saved and now it's used to load from.</param>
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
        /// Check if the entries within the window and hide each of their previous opponent
        /// <br>port's connected style if it's not in connecting state anymore.</br>
        /// </summary>
        public void CheckMultiOpponentsConnectedStyle()
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