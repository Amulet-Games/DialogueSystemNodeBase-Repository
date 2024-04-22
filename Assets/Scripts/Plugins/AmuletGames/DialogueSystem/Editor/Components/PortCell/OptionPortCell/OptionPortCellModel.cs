using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortCellModel
    {
        /// <summary>
        /// The direction of the port cell.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// The isIndexDominant value of the port cell.
        /// </summary>
        public bool IsIndexDominant { get; private set; }


        /// <summary>
        /// The index of the port cell.
        /// </summary>
        public int Index { get; private set; }


        /// <summary>
        /// Reference of the edge connector search window view.
        /// </summary>
        public EdgeConnectorSearchWindowView EdgeConnectorSearchWindowView { get; private set; }


        /// <summary>
        /// Constructor of the option port cell model.
        /// </summary>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="isIndexDominant">The isIndexDominant value to set for.</param>
        /// <param name="index">The index to set for.</param>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window view to set for.</param>
        public OptionPortCellModel
        (
            Direction direction,
            bool isIndexDominant,
            int index,
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView
        )
        {
            Direction = direction;
            IsIndexDominant = isIndexDominant;
            Index = index;
            EdgeConnectorSearchWindowView = edgeConnectorSearchWindowView;
        }
    }
}