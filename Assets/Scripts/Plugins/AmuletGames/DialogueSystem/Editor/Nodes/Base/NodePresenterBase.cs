using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Holds the methods for creating the UIElements of the connecting node modele.
    /// </summary>
    public abstract class NodePresenterBase
    {
        /// <summary>
        /// Methods for adding menu items to the node's contextual menu, items are added at the end of the current item list.
        /// <para>This method is used inside the node frame base class, "BuildContextualManu" method.</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public abstract void AddContextualManuItems(ContextualMenuPopulateEvent evt);
    }
}