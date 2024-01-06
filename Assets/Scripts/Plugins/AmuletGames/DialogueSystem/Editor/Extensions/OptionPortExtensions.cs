namespace AG.DS
{
    public static class OptionPortExtensions
    {
        /// <summary>
        /// Remove the option port from the connect style class.
        /// </summary>
        /// <param name="port">Extension option port.</param>
        public static void HideConnectStyle(this OptionPort port)
        {
            port.RemoveFromClassList(StyleConfig.Port_Connect);

            port.portName = port.IsInput()
                ? StringConfig.OptionPortGroupCell_Input_Disconnect_LabelText
                : StringConfig.OptionPortGroupCell_Output_Disconnect_LabelText;
        }
    }
}