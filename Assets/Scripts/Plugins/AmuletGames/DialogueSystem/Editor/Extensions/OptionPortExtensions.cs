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
                                        ? StringConfig.Instance.OptionPort_Connect_Input_LabelText
                                        : StringConfig.Instance.OptionPort_Connect_Output_LabelText,

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
                port.portName = StringConfig.Instance.OptionPort_Disconnect_Input_LabelText;
            }
            else
            {
                port.RemoveFromClassList(StyleConfig.Instance.Port_Connect);
                port.portName = StringConfig.Instance.OptionPort_Disconnect_Output_LabelText;
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
                          text01: StringConfig.Instance.OptionPort_Connect_Input_LabelText,
                          text02: siblingIndex.ToString()
                      )
                      .ToString()

                    : StringConfig.Instance.OptionPort_Disconnect_Input_LabelText;

            }
            else
            {
                port.portName = port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.Instance.OptionPort_Connect_Output_LabelText,
                          text02: siblingIndex.ToString()
                      )
                      .ToString()

                    : StringConfig.Instance.OptionPort_Disconnect_Output_LabelText;
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
                          text01: StringConfig.Instance.ContextualMenuItem_DisconnectOptionInputPort_LabelText,
                          text02: port.portName
                      )
                      .ToString()

                    : StringConfig.Instance.ContextualMenuItem_DisconnectInputPort_LabelText;
            }
            else
            {
                return port.connected
                    ? StringUtility.New
                      (
                          text01: StringConfig.Instance.ContextualMenuItem_DisconnectOptionOutputPort_LabelText,
                          text02: port.portName
                      )
                      .ToString()

                    : StringConfig.Instance.ContextualMenuItem_DisconnectOutputPort_LabelText;
            }
        }
    }
}