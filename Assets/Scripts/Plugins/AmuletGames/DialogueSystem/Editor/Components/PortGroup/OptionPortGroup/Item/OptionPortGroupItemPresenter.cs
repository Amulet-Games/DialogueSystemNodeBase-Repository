namespace AG.DS
{
    public class OptionPortGroupItemPresenter
    {
        /// <summary>
        /// Create a new option port group item element.
        /// </summary>
        /// <param name="model">The option port group item model to set for.</param>
        /// <returns>A new option port group item element.</returns>
        public static OptionPortGroupItem CreateElement(OptionPortGroupItemModel model)
        {
            OptionPortGroupItem item;

            CreateItem();

            CreatePortCell();

            CreateRemoveButton();

            AddElementsToItem();

            AddStyleSheet();

            return item;

            void CreateItem()
            {
                item = new();
                item.AddToClassList(StyleConfig.OptionPortGroupItem);
            }

            void CreatePortCell()
            {
                var cellModel = new OptionPortCellModel
                (
                    direction: model.Group.Direction,
                    index: model.Group.NextItemIndex,
                    isIndexDominant: true,
                    edgeConnectorSearchWindowView: model.Group.GraphViewer.OptionEdgeConnectorSearchWindowView
                );;

                item.PortCell = OptionPortCellFactory.Generate(cellModel);
            }

            void CreateRemoveButton()
            {
                item.RemoveButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.OptionPortGroupItem_RemoveButton
                );
            }

            void AddElementsToItem()
            {
                item.Add(item.PortCell);
                item.Add(item.RemoveButton);
            }

            void AddStyleSheet()
            {
                item.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortGroupItemStyle);
            }
        }
    }
}