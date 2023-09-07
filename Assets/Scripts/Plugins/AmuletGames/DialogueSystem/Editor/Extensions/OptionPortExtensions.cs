namespace AG.DS
{
    public static class OptionPortExtensions
    {
        /// <summary>
        /// Add the option port to the connect style class if it's connecting to another port,
        /// <br>Otherwise remove the port from the connect style class.</br>
        /// </summary>
        /// <param name="port">Extension option port.</param>
        public static void ToggleConnectStyle(this OptionPort port)
        {
            if (port.OpponentPort != null)
            {
                port.ShowConnectStyle();
            }
            else
            {
                port.HideConnectStyle();
            }
        }


        /// <summary>
        /// Remove the option port from the connect style class.
        /// </summary>
        /// <param name="port">Extension option port.</param>
        public static void HideConnectStyle(this OptionPort port)
        {
            port.RemoveFromClassList(StyleConfig.Port_Connect);

            port.portName = port.IsInput()
                ? StringConfig.OptionPort_Input_LabelText_Disconnect
                : StringConfig.OptionPort_Output_LabelText_Disconnect;
        }


        /// <summary>
        /// Add the option port to the connect style class.
        /// </summary>
        /// <param name="port">Extension option port.</param>
        public static void ShowConnectStyle(this OptionPort port)
        {
            port.AddToClassList(StyleConfig.Port_Connect);

            int siblingIndex;
            if (port.IsInput())
            {
                siblingIndex = port.OpponentPort.GetSiblingIndex();
                port.portName = StringUtility.New
                                (
                                    str01: StringConfig.OptionPort_Input_LabelText_Connect,
                                    str02: siblingIndex.ToString()
                                );
            }
            else
            {
                siblingIndex = port.GetSiblingIndex();
                port.portName = StringUtility.New
                                (
                                    str01: StringConfig.OptionPort_Output_LabelText_Connect,
                                    str02: siblingIndex.ToString()
                                );
            }
        }


        /// <summary>
        /// Update the option port label with the sibling index.
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
                          str01: StringConfig.OptionPort_Input_LabelText_Connect,
                          str02: siblingIndex.ToString()
                      )

                    : StringConfig.OptionPort_Input_LabelText_Disconnect;

            }
            else
            {
                port.portName = port.connected
                    ? StringUtility.New
                      (
                          str01: StringConfig.OptionPort_Output_LabelText_Connect,
                          str02: siblingIndex.ToString()
                      )

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
                          str01: StringConfig.ContextualMenuItem_DisconnectOptionInputPort_LabelText,
                          str02: port.portName
                      )

                    : StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText;
            }
            else
            {
                return port.connected
                    ? StringUtility.New
                      (
                          str01: StringConfig.ContextualMenuItem_DisconnectOptionOutputPort_LabelText,
                          str02: port.portName
                      )

                    : StringConfig.ContextualMenuItem_DisconnectOutputPort_LabelText;
            }
        }
    }
}