using System.Linq;
using System;
using UnityEditor.Experimental.GraphView;

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


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option entry. No parameters needed
        /// </summary>
        public DSOptionEntry()
        {
            SavedPortGuid = "";
            SavedPortLabelText = "";
        }


        /// <summary>
        /// Constructor of option entry. Accept previous saved option entry as parameter,
        /// <br>entry'll be initalized as new if it's not provided.</br>
        /// </summary>
        /// <param name="source">The entry that was previosuly saved and now it's used to load from.</param>
        public DSOptionEntry(DSOptionEntry source)
        {
            if (source != null)
            {
                LoadEntryValues(source);
            }
            else
            {
                SavedPortGuid = Guid.NewGuid().ToString();
                SavedPortLabelText = DSStringsConfig.OptionChannelEntryLabelTextEmpty;
            }
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Check if entry port is connected and if so add connected style to it, 
        /// <br>and register MouseMoveEvent to the edge that were created during the loading phrase.</br>
        /// </summary>
        public void PostLoadingSetup()
        {
            if (Port.connected)
            {
                // Get all the necessary references.
                Edge channelEdge = Port.connections.First();
                DSOptionPort opponentTrackPort = (DSOptionPort)channelEdge.input;

                // Add connected style to the internal port and opponent track port.
                DSOptionChannelUtility.AddToEntryConnectedClass(Port);
                DSOptionChannelUtility.AddToTrackConnectedClass(opponentTrackPort);

                // Register MouseMoveEvent to the edge that the ports is connecting with.
                DSChannelEdgeEventRegister.RegisterMouseEvents(channelEdge);

                // Register previous opponent port references to both the internal port and opponent track port.
                Port.PreviousOpponentPort = opponentTrackPort;
                opponentTrackPort.PreviousOpponentPort = Port;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the entry port values from the source.
        /// </summary>
        /// <param name="source">The entry of which its values are going to be saved in</param>
        public void SaveEntryValues(DSOptionEntry source)
        {
            // Save entry port's Guid Id.
            SavedPortGuid = source.Port.name;

            // Save entry port's label text.
            SavedPortLabelText = source.Port.portName;
        }


        /// <summary>
        /// Load the entry port values from the previously saved entry.
        /// </summary>
        /// <param name="source">The entry that was previosuly saved and now it's used to load from.</param>
        public void LoadEntryValues(DSOptionEntry source)
        {
            // Load entry port's Guid Id.
            SavedPortGuid = source.SavedPortGuid;

            // Load entry port's label text.
            SavedPortLabelText = source.SavedPortLabelText;
        }


        // ----------------------------- Check Entry's Opponent Connected Style -----------------------------
        /// <summary>
        /// Hide the entry's opponent port's connected style if it's not in connecting state anymore. 
        /// </summary>
        public void CheckOpponentConnectedStyle() => Port.CheckOpponentConnectedStyle(false);
    }
}