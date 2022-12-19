using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MultiOptionChannel
    {
        /// <summary>
        /// Reference of the connecting port component.
        /// </summary>
        [NonSerialized] public OptionPort Port;


        /// <summary>
        /// Is the channel contains output port or input port?
        /// </summary>
        [NonSerialized] public bool IsOutput;


        /// <summary>
        /// Constructor of the option multi channel component class.
        /// </summary>
        /// <param name="isOutput">The isOutput value to set for.</param>
        public MultiOptionChannel(bool isOutput)
        {
            IsOutput = isOutput;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the channel values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveChannelValues(MultiOptionChannelData data)
        {
            // Port GUID
            data.PortGUID = Port.name;

            // Port label
            data.PortLabel = Port.portName;
        }


        /// <summary>
        /// Load the channel values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadChannelValues(MultiOptionChannelData data)
        {
            // Port GUID
            Port.name = data.PortGUID;

            // Port label
            Port.portName = data.PortLabel;
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect the internal port element.
        /// </summary>
        /// <param name="node">Reference of the connecting node component.</param>
        public void DisconnectPort(NodeBase node)
        {
            // Hide both the internal and opponent port's connected style.
            if (IsOutput)
            {
                OptionChannelHelper.HideConnectedStyleBoth(
                    inputPort: Port.OpponentPort,
                    outputPort: Port
                );
            }
            else
            {
                OptionChannelHelper.HideConnectedStyleBoth(
                    inputPort: Port,
                    outputPort: Port.OpponentPort
                );
            }

            // Disconnect the ports.
            node.GraphViewer.DisconnectPort(port: Port);
        }
    }
}