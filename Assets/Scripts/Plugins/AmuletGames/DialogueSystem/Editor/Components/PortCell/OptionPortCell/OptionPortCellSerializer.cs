namespace AG.DS
{
    public class OptionPortCellSerializer
    {
        /// <summary>
        /// Save the option port cell values.
        /// </summary>
        /// <param name="cell">The option port cell to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        public static void Save
        (
            OptionPortCell cell,
            OptionPortCellData data
        )
        {
            data.PortGuid = cell.Port.Guid;
            data.PortName = cell.Port.portName;
        }



        /// <summary>
        /// Load the option port cell values.
        /// </summary>
        /// <param name="cell">The option port cell to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        public static void Load
        (
            OptionPortCell cell,
            OptionPortCellData data
        )
        {
            cell.Port.Guid = data.PortGuid;
            cell.Port.portName = data.PortName;
        }
    }
}