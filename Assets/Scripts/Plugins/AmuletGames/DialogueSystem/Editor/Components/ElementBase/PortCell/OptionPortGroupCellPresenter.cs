using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Create a new option port group cell element.
        /// </summary>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <returns>A new option port group cell element.</returns>
        public static OptionPortGroupCell CreateElement
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
        {
            OptionPortGroupCell cell;

            CreateCell();

            CreateOptionPort();

            SetupRemoveButton();

            AddElementsToCell();

            AddStyleSheet();

            return cell;

            void CreateCell()
            {
                cell = new();
            }

            void CreateOptionPort()
            {
                cell.Port = OptionPort.CreateElement<OptionEdge>
                (
                    connectorWindow: connectorWindow,
                    direction: direction
                );
            }

            void SetupRemoveButton()
            {
                cell.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.OptionPortGroup_RemoveButton
                );
            }

            void AddElementsToCell()
            {
                cell.Add(cell.Port);
                cell.Add(cell.RemoveButton);
            }

            void AddStyleSheet()
            {
                cell.AddToClassList(StyleConfig.OptionPortGroup_Cell);
            }
        }
    }
}