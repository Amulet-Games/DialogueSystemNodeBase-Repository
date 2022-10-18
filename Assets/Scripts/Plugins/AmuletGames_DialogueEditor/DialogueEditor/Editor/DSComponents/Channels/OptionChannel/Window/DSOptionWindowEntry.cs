using System;

namespace AG
{
    [Serializable]
    public class DSOptionWindowEntry
    {
        /// <summary>
        /// The serialized port's Guid id of the window entry.
        /// </summary>
        public string SavedPortGuid;


        /// <summary>
        /// The serialized port's label text of the window entry.
        /// </summary>
        public string SavedPortLabelText;


        /// <summary>
        /// Port that can connect to the other same channel type of track.
        /// </summary>
        public DSOptionPort Port;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option window entry component. No parameters needed.
        /// </summary>
        public DSOptionWindowEntry()
        {
            SavedPortGuid = "";
            SavedPortLabelText = "";
        }


        /// <summary>
        /// Constructor of option window entry component. Accept previous saved window entry as parameter.
        /// </summary>
        /// <param name="source">The window entry that was previosuly saved and now it's used to load from.</param>
        public DSOptionWindowEntry(DSOptionWindowEntry source)
        {
            if (source != null)
            {
                // Load the previously saved window entry's values if the source is valid.
                LoadWindowEntryValues(source);
            }
            else
            {
                // Initialize with new values.
                SavedPortGuid = Guid.NewGuid().ToString();
                SavedPortLabelText = DSStringsConfig.OptionChannelEmptyEntryLabelText;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the window entry values from the source.
        /// </summary>
        /// <param name="source">The window entry of which its values are going to be saved in.</param>
        public void SaveEntryValues(DSOptionWindowEntry source)
        {
            // Save window entry port's Guid Id.
            SavedPortGuid = source.Port.name;

            // Save window entry port's label text.
            SavedPortLabelText = source.Port.portName;
        }


        /// <summary>
        /// Load the window entry values from the previously saved window entry.
        /// </summary>
        /// <param name="source">The window entry that was previosuly saved and now it's used to load from.</param>
        public void LoadWindowEntryValues(DSOptionWindowEntry source)
        {
            // Load entry port's Guid Id.
            SavedPortGuid = source.SavedPortGuid;

            // Load entry port's label text.
            SavedPortLabelText = source.SavedPortLabelText;
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect the window entry port from its current opponent track port.
        /// </summary>
        /// <param name="node">Reference of the dialogue system's node base.</param>
        public void DisconnectPort(DSNodeBase node)
        {
            // Hide both entry and track port's connected style.
            DSOptionChannelUtility.HideBothConnectedStyle(Port.PreviousOpponentPort, Port);

            // Disconnect the ports.
            node.GraphView.DisconnectPort(Port);
        }
    }
}