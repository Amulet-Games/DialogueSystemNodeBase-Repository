using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class OptionPortCellPresenter
    {
        /// <summary>
        /// Create a new option port cell element.
        /// </summary>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="isIndexDominant">The isIndexDominant value to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <returns>A new option port cell element.</returns>
        public static OptionPortCell CreateElement
        (
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            Direction direction,
            bool isIndexDominant,
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
                cell = new(isIndexDominant, index);
                cell.AddToClassList(StyleConfig.OptionPortCell);
            }

            void CreateOptionPort()
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Option,
                    direction,
                    capacity: Capacity.Single,
                    name: direction == Direction.Input
                        ? StringConfig.OptionPortCell_Input_Disconnect_LabelText
                        : StringConfig.OptionPortCell_Output_Disconnect_LabelText,
                    color: PortConfig.OptionPortColor
                );

                cell.Port = PortFactory.Create(portModel);
                cell.Port.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: edgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle
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