using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortCellSeeder
    {
        /// <summary>
        /// Generate a new option port cell.
        /// </summary>
        /// <param name="nodeCreateOptionConnectorWindow">The node create option connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        /// <returns>A new option port cell.</returns>
        public OptionPortCell Generate
        (
            NodeCreateOptionConnectorWindow nodeCreateOptionConnectorWindow,
            Direction direction,
            int index = OptionPortGroup.FIRST_PORT_CELL_INDEX,
            OptionPortCellData data = null
        )
        {
            var portCell = OptionPortCellPresenter.CreateElement
            (
                nodeCreateOptionConnectorWindow,
                direction,
                index
            );

            new OptionPortCellObserver(portCell).RegisterEvents();

            if (data != null)
            {
                PortManager.Instance.Load(portCell.Port, data.OptionPortData);
            }

            return portCell;
        }
    }
}