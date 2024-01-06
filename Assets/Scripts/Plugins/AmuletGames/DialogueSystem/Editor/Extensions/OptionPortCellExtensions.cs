namespace AG.DS
{
    public static class OptionPortCellExtensions
    {
        /// <summary>
        /// Add the option port cell to the connect style class if the cell's opponent cell exists,
        /// <br>Otherwise remove the cell from the connect style class.</br>
        /// </summary>
        /// <param name="cell">Extension option port cell.</param>
        public static void ToggleConnectStyle(this OptionPortCell cell)
        {
            if (cell.OpponentCell != null)
            {
                cell.ShowConnectStyle();
            }
            else
            {
                cell.HideConnectStyle();
            }
        }


        /// <summary>
        /// Remove the option port cell from the connect style class.
        /// </summary>
        /// <param name="cell">Extension option port cell.</param>
        public static void HideConnectStyle(this OptionPortCell cell)
        {
            cell.Port.RemoveFromClassList(StyleConfig.Port_Connect);
            cell.UpdatePortName();
        }


        /// <summary>
        /// Add the option port cell to the connect style class.
        /// </summary>
        /// <param name="cell">Extension option port cell.</param>
        public static void ShowConnectStyle(this OptionPortCell cell)
        {
            cell.Port.AddToClassList(StyleConfig.Port_Connect);
            cell.UpdatePortName();
        }


        /// <summary>
        /// Update the option port cell's port name.
        /// </summary>
        /// <param name="cell">Extension option port cell.</param>
        public static void UpdatePortName(this OptionPortCell cell)
        {
            var port = cell.Port;

            if (port.IsInput())
            {
                port.portName = cell.OpponentCell != null
                    ? StringConfig.OptionPortGroupCell_Input_Connect_LabelText.Append(cell.Index.ToString())
                    : StringConfig.OptionPortGroupCell_Input_Disconnect_LabelText;

            }
            else
            {
                port.portName = cell.OpponentCell != null
                    ? StringConfig.OptionPortGroupCell_Output_Connect_LabelText.Append(cell.Index.ToString())
                    : StringConfig.OptionPortGroupCell_Output_Disconnect_LabelText;
            }
        }


        /// <summary>
        /// Retrieve the disconnecting cell port's contextual menu item label.
        /// </summary>
        /// <param name="cell">Extension option port cell.</param>
        /// <returns>The disconnecting cell port's contextual menu item label.</returns>
        public static string DisconnectCellPortContextualMenuItemLabel(this OptionPortCell cell)
        {
            var port = cell.Port;

            if (port.IsInput())
            {
                return port.connected
                    ? StringConfig.ContextualMenuItem_DisconnectOptionCellPort_Input_LabelText.Append(port.portName)
                    : StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText;
            }
            else
            {
                return port.connected
                    ? StringConfig.ContextualMenuItem_DisconnectOptionCellPort_Output_LabelText.Append(port.portName)
                    : StringConfig.ContextualMenuItem_DisconnectOutputPort_LabelText;
            }
        }
    }
}