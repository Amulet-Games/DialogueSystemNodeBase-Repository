using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortCellFactory
    {
        /// <summary>
        /// Create a new option port cell.
        /// </summary>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="isIndexDominant">The isIndexDominant value to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        /// <returns>A new option port cell.</returns>
        public static OptionPortCell Create
        (
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            Direction direction,
            bool isIndexDominant,
            int index = OptionPortGroup.FIRST_PORT_CELL_INDEX,
            OptionPortCellData data = null
        )
        {
            var portCell = OptionPortCellPresenter.CreateElement
            (
                edgeConnectorSearchWindowView,
                direction,
                isIndexDominant: isIndexDominant,
                index
            );

            new OptionPortCellObserver(portCell).RegisterEvents();

            if (data != null)
            {
                new OptionPortCellSerializer().Load(portCell, data);
            }

            return portCell;
        }
    }
}