using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Create a new option port group cell element.
        /// </summary>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <returns>A new option port group cell element.</returns>
        public static OptionPortGroupCell CreateElement
        (
            NodeCreateOptionConnectorWindow connectorWindow,
            Direction direction
        )
        {
            OptionPortGroupCell cell;

            CreateCell();

            CreateOptionPort();

            CreateRemoveCellButton();

            AddElementsToCell();

            AddStyleSheet();

            return cell;

            void CreateCell()
            {
                cell = new();
                cell.AddToClassList(StyleConfig.OptionPortGroup_GroupCell);
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

            void CreateRemoveCellButton()
            {
                cell.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.OptionPortGroup_RemoveCell_Button
                );
            }

            void AddElementsToCell()
            {
                cell.Add(cell.Port);
                cell.Add(cell.RemoveButton);
            }

            void AddStyleSheet()
            {
                cell.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortCellStyle);
            }
        }
    }
}