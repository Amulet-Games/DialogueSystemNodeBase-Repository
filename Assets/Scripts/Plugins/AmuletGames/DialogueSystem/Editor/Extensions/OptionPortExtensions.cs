namespace AG.DS
{
    public static class OptionPortExtensions
    {
        /// <summary>
        /// Add the option port to the connect style class and update its label with
        /// <br>the sibling index.</br>
        /// </summary>
        /// <param name="port">Extension option port.</param>
        /// <param name="siblingIndex">The index to set for the port label.</param>
        public static void ShowConnectStyle
        (
            this OptionPort port,
            int siblingIndex
        )
        {
            port.AddToClassList(StyleConfig.Instance.Port_Connect);

            port.portName = StringUtility.New
                            (
                                text01: port.IsInput()
                                        ? StringConfig.OptionPort_Input_LabelText_Connect
                                        : StringConfig.OptionPort_Output_LabelText_Connect,

                                text02: siblingIndex.ToString()
                            )
                            .ToString();
        }


        /// <summary>
        /// Remove the option port from the connect style class.
        /// </summary>
        /// <param name="port">Extension option port.</param>
        public static void HideConnectStyle(this OptionPort port)
        {
            if (port.IsInput())
            {
                port.RemoveFromClassList(StyleConfig.Instance.Port_Connect);
                port.portName = StringConfig.OptionPort_Input_LabelText_Disconnect;
            }
            else
            {
                port.RemoveFromClassList(StyleConfig.Instance.Port_Connect);
                port.portName = StringConfig.OptionPort_Output_LabelText_Disconnect;
            }
        }


        /// <summary>
        /// Update the option port label with the given sibling index.
        /// </summary>
        /// <param name="port">Extension option port.</param>
        /// <param name="siblingIndex">The index to set for the port label.</param>
        public static void UpdatePortLabel
        (
            this OptionPort port,
            int siblingIndex
        )
        {
            if (port.IsInput())
            {
                port.portName = port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.OptionPort_Input_LabelText_Connect,
                          text02: siblingIndex.ToString()
                      )
                      .ToString()

                    : StringConfig.OptionPort_Input_LabelText_Disconnect;

            }
            else
            {
                port.portName = port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.OptionPort_Output_LabelText_Connect,
                          text02: siblingIndex.ToString()
                      )
                      .ToString()

                    : StringConfig.OptionPort_Output_LabelText_Disconnect;
            }
        }


        /// <summary>
        /// Retrieve the contextual menu item label for disconnecting the port.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string GetDisconnectPortContextualMenuItemLabel(this OptionPort port)
        {
            if (port.IsInput())
            {
                return port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.ContextualMenuItem_DisconnectOptionInputPort_LabelText,
                          text02: port.portName
                      )
                      .ToString()

                    : StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText;
            }
            else
            {
                return port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.ContextualMenuItem_DisconnectOptionOutputPort_LabelText,
                          text02: port.portName
                      )
                      .ToString()

                    : StringConfig.ContextualMenuItem_DisconnectOutputPort_LabelText;
            }
        }
    }
}