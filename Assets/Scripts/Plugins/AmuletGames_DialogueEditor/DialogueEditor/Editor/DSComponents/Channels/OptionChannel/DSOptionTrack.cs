using System;
using UnityEditor.Experimental.GraphView;

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
        /// <param name="node">Node of which this track is created for.</param>
        /// <returns>A new track that has its port set up.</returns>
        public void SetupTrack(DSNodeBase node)
        {
            GetNewTrackPort();

            AddTrackToContainer();

            void GetNewTrackPort()
            {
                Port = DSOptionPort.GetNewTrackPort<Edge>();
            }

            void AddTrackToContainer()
            {
                node.inputContainer.Add(Port);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the track port values from the source.
        /// </summary>
        /// <param name="source">The track of which its values are going to be saved in.</param>
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
        /// <param name="source">The track that was previosuly saved and now it's used to load from.</param>
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