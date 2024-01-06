using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortCellPresenter
    {
        /// <summary>
        /// Create a new option port cell element.
        /// </summary>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <returns>A new option port cell element.</returns>
        public static OptionPortCell CreateElement
        (
            NodeCreateOptionConnectorWindow connectorWindow,
            Direction direction,
            int index = OptionPortGroup.FIRST_PORT_CELL_INDEX
        )
        {
            OptionPortCell cell;

            CreateCell();

            CreateOptionPort();

            AddElementsToCell();

            AddStyleSheet();

            return cell;

            void CreateCell()
            {
                cell = new(index);
                cell.AddToClassList(StyleConfig.OptionPortCell);
            }

            void CreateOptionPort()
            {
                cell.Port = PortManager.Instance.CreateOption
                (
                    connectorWindow: connectorWindow,
                    direction: direction,
                    isGroup: true
                );
            }

            void AddElementsToCell()
            {
                cell.Add(cell.Port);
            }

            void AddStyleSheet()
            {
                cell.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortCellStyle);
            }
        }
    }
}