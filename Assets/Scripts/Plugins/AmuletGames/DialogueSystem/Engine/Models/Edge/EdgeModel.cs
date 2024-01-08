using UnityEngine.UIElements;

namespace AG.DS
{
    public class EdgeModel
    {
        /// <summary>
        /// Is the edge element focusable.
        /// </summary>
        public bool Focusable { get; private set; }


        /// <summary>
        /// The stylesheet of the edge.
        /// </summary>
        public StyleSheet StyleSheet { get; private set; }


        /// <summary>
        /// Constructor of the edge model class.
        /// </summary>
        /// <param name="focusable">The focusable value to set for.</param>
        /// <param name="styleSheet">The style sheet to set for.</param>
        public EdgeModel
        (
            bool focusable,
            StyleSheet styleSheet
        )
        {
            Focusable = focusable;
            StyleSheet = styleSheet;
        }
    }
}