using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Create a new option port group cell element.
        /// </summary>
        /// <param name="nodeCreateOptionConnectorWindow">The node create option connector window to set for.</param>
        /// <param name="direction">The option port cell direction to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <returns>A new option port group cell element.</returns>
        public static OptionPortGroupCell CreateElement
        (
            NodeCreateOptionConnectorWindow nodeCreateOptionConnectorWindow,
            Direction direction,
            int index
        )
        {
            OptionPortGroupCell groupCell;

            CreateGroupCell();

            CreatePortCell();

            CreateRemoveCellButton();

            AddElementsToCell();

            AddStyleSheet();

            return groupCell;

            void CreateGroupCell()
            {
                groupCell = new();
                groupCell.AddToClassList(StyleConfig.OptionPortGroupCell);
            }

            void CreatePortCell()
            {
                groupCell.PortCell = OptionPortCellPresenter.CreateElement
                (
                    nodeCreateOptionConnectorWindow: nodeCreateOptionConnectorWindow,
                    direction: direction,
                    index: index,
                    isIndexDominant: true
                );
            }

            void CreateRemoveCellButton()
            {
                groupCell.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.OptionPortGroupCell_RemoveCellButton
                );
            }

            void AddElementsToCell()
            {
                groupCell.Add(groupCell.PortCell);
                groupCell.Add(groupCell.RemoveButton);
            }

            void AddStyleSheet()
            {
                groupCell.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortGroupCellStyle);
            }
        }
    }
}