using UnityEngine.UIElements;

namespace AG
{
    /// <summary>
    /// Dialogue system node presenter base class.
    /// </summary>
    public abstract class DSNodePresenterBase
    {
        /// <summary>
        /// Methods for adding menu items to the node's contextual menu, items are added at the end of the current item list.
        /// <para>This method is used inside the node's DSNodeFrameBase class, "BuildContextualManu" method.</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public abstract void AddContextualManuItems(ContextualMenuPopulateEvent evt);
    }
}