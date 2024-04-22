using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class OptionPortCellPresenter
    {
        /// <summary>
        /// Create a new option port cell element.
        /// </summary>
        /// <param name="model">The option port cell model to set for.</param>
        /// <returns>A new option port cell element.</returns>
        public static OptionPortCell CreateElement(OptionPortCellModel model)
        {
            OptionPortCell cell;

            CreateCell();

            CreateOptionPort();

            AddStyleSheet();

            return cell;

            void CreateCell()
            {
                cell = new(model.IsIndexDominant, model.Index);
                cell.AddToClassList(StyleConfig.PortCell);
            }

            void CreateOptionPort()
            {
                var portModel = new PortModel
                (
                    direction: model.Direction,
                    capacity: Capacity.Single,
                    name: model.Direction == Direction.Input
                        ? StringConfig.OptionPortCell_Input_Disconnect_LabelText
                        : StringConfig.OptionPortCell_Output_Disconnect_LabelText,
                    color: PortConfig.OptionPortColor,
                    edgeConnectorSearchWindowView: model.EdgeConnectorSearchWindowView,
                    edgeModel: new(focusable: true, styleSheet: ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle)
                );

                cell.Port = PortFactory.Generate(portModel);
            }

            void AddStyleSheet()
            {
                cell.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortCellStyle);
            }
        }
    }
}