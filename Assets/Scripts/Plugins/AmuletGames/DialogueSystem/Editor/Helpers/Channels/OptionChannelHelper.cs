using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public static class OptionChannelHelper
    {
        // ----------------------------- Set Connected Style Services -----------------------------
        /// <summary>
        /// Add the connected USS style class to both input and output option channel port,
        /// <br>and update their port label.</br>
        /// </summary>
        /// <param name="targetEdge">The edge that was created during the OnDrop Listener.</param>
        public static void ShowConnectedStyleBoth(Edge targetEdge)
        {
            Port outputPort = targetEdge.output;
            Port inputPort = targetEdge.input;
            string siblingIndexText = outputPort.GetSiblingIndexAdd(addByNumber: 1).ToString();

            // Label.
            outputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedOutputLabelText,
                                     text02: siblingIndexText
                                 )
                                 .ToString();

            inputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedInputLabelText,
                                     text02: siblingIndexText
                                 )
                                 .ToString();

            // Connected style.
            outputPort.AddToClassList(StylesConfig.Channel_Option_Output_Port_Connected);
            inputPort.AddToClassList(StylesConfig.Channel_Option_Input_Port_Connected);
        }


        /// <summary>
        /// Add the connected USS style class to the input option channel port,
        /// <br>and update the port label.</br>
        /// </summary>
        /// <param name="outputPort">The input port to add the connected style class to.</param>
        /// <param name="siblingIndex">The index to set for the label.</param>
        public static void ShowConnectedStyleInput(Port inputPort, int siblingIndex)
        {
            // Label.
            inputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedInputLabelText,
                                     text02: siblingIndex.ToString()
                                 )
                                 .ToString();

            // Connected style.
            inputPort.AddToClassList(StylesConfig.Channel_Option_Input_Port_Connected);
        }


        /// <summary>
        /// Add the connected USS style class to the output option channel port,
        /// <br>and update the port label.</br>
        /// </summary>
        /// <param name="outputPort">The output port to add the connected style class to.</param>
        /// <param name="siblingIndex">The index to set for the label.</param>
        public static void ShowConnectedStyleOutput(Port outputPort, int siblingIndex)
        {
            // Label.
            outputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedOutputLabelText,
                                     text02: siblingIndex.ToString()
                                 )
                                 .ToString();

            // Connected style.
            outputPort.AddToClassList(StylesConfig.Channel_Option_Output_Port_Connected);
        }


        /// <summary>
        /// Add the connected USS style class to the input option channel's port.
        /// </summary>
        /// <param name="inputPort">The input port to add to.</param>
        public static void AddConnectedClassInput(Port inputPort)
        {
            inputPort.AddToClassList(StylesConfig.Channel_Option_Input_Port_Connected);
        }


        /// <summary>
        /// Add the connected USS style class to the output option channel's port.
        /// </summary>
        /// <param name="outputPort">The output port to add to.</param>
        public static void AddConnectedClassOutput(Port outputPort)
        {
            outputPort.AddToClassList(StylesConfig.Channel_Option_Output_Port_Connected);
        }


        /// <summary>
        /// Update the input option port's label with the given sibling index.
        /// </summary>
        /// <param name="inputPort">The input port to change with.</param>
        /// <param name="siblingIndex">The index to set for the label.</param>
        public static void UpdateLabelInput(Port inputPort, int siblingIndex)
        {
            inputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedInputLabelText,
                                     text02: siblingIndex.ToString()
                                 )
                                 .ToString();
        }


        /// <summary>
        /// Update the output option port's label with the given sibling index.
        /// </summary>
        /// <param name="outputPort">The output port to change with.</param>
        /// <param name="siblingIndex">The index to set for the label.</param>
        public static void UpdateLabelOutput(Port outputPort, int siblingIndex)
        {
            outputPort.portName = StringUtility.New
                                 (
                                     text01: StringsConfig.OptionChannelConnectedOutputLabelText,
                                     text02: siblingIndex.ToString()
                                 )
                                 .ToString();
        }


        /// <summary>
        /// Remove the connected USS style class from both input and output option channel ports
        /// <br>And reset their port label.</br>
        /// </summary>
        /// <param name="inputPort">The input port to remove the connected style from.</param>
        /// <param name="outputPort">The output port to remove the connected style from.</param>
        public static void HideConnectedStyleBoth(Port inputPort, Port outputPort)
        {
            inputPort.portName = StringsConfig.OptionChannelEmptyInputLabelText;
            inputPort.RemoveFromClassList(StylesConfig.Channel_Option_Input_Port_Connected);

            outputPort.portName = StringsConfig.OptionChannelEmptyOutputLabelText;
            outputPort.RemoveFromClassList(StylesConfig.Channel_Option_Output_Port_Connected);
        }


        /// <summary>
        /// Remove the connected USS style class from the input option channel port,
        /// <br>and reset the port label.</br>
        /// </summary>
        /// <param name="inputPort">The input port to remove the connected style class from.</param>
        public static void HideConnectedStyleInput(Port inputPort)
        {
            inputPort.portName = StringsConfig.OptionChannelEmptyInputLabelText;
            inputPort.RemoveFromClassList(StylesConfig.Channel_Option_Input_Port_Connected);
        }


        /// <summary>
        /// Remove the connected USS style class from the output option channel port,
        /// <br>and reset the port label.</br>
        /// </summary>
        /// <param name="outputPort">The output port to remove the connected style class from.</param>
        public static void HideConnectedStyleOutput(Port outputPort)
        {
            outputPort.portName = StringsConfig.OptionChannelEmptyOutputLabelText;
            outputPort.RemoveFromClassList(StylesConfig.Channel_Option_Output_Port_Connected);
        }
    }
}