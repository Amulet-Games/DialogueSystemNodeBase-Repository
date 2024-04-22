using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupPresenter
    {
        /// <summary>
        /// Create a new option port group element.
        /// </summary>
        /// <param name="direction">The direction type to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new option port group element.</returns>
        public static OptionPortGroup CreateElement
        (
            Direction direction,
            GraphViewer graphViewer
        )
        {
            OptionPortGroup group;

            CreateGroup();

            CreateBaseOptionPortCell();

            return group;

            void CreateGroup()
            {
                group = new(direction, graphViewer);
                group.AddToClassList(StyleConfig.OptionPortGroup);
            }

            void CreateBaseOptionPortCell()
            {
                var portCellModel = new OptionPortCellModel
                (
                    direction: direction,
                    isIndexDominant: true,
                    index: OptionPortGroup.FIRST_ITEM_INDEX,
                    edgeConnectorSearchWindowView: graphViewer.OptionEdgeConnectorSearchWindowView
                );

                group.BaseOptionPortCell = OptionPortCellFactory.Generate(model: portCellModel);
            }
        }
    }
}