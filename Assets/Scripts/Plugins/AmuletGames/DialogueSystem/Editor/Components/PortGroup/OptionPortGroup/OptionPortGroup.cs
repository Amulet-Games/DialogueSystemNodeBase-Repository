using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroup : VisualElement
    {
        /// <summary>
        /// The Property of the base option port cell of the group.
        /// </summary>
        public OptionPortCell BaseOptionPortCell
        {
            get
            {
                return m_baseOptionPortCell;
            }
            set
            {
                m_baseOptionPortCell = value;
                
                Add(child: value);
                GraphViewer.Add(value.Port);
            }
        }


        /// <summary>
        /// The base option port cell of the group.
        /// </summary>
        OptionPortCell m_baseOptionPortCell;


        /// <summary>
        /// The first item index.
        /// </summary>
        public const int FIRST_ITEM_INDEX = 1;


        /// <summary>
        /// The option port group items cache.
        /// </summary>
        public List<OptionPortGroupItem> Items;


        /// <summary>
        /// The next item index.
        /// </summary>
        public int NextItemIndex => childCount + 1;


        /// <summary>
        /// The direction type.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// Returns true if any of the group item's port is connecting.
        /// </summary>
        public bool Connected
        {
            get
            {
                if (BaseOptionPortCell.Port.connected)
                {
                    return true;
                }

                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].PortCell.Port.connected)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Constructor of the option port group element.
        /// </summary>
        /// <param name="direction">The direction type to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public OptionPortGroup
        (
            Direction direction,
            GraphViewer graphViewer
        )
        {
            GraphViewer = graphViewer;
            Direction = direction;
            Items = new();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Remove the given option port group item from the group.
        /// </summary>
        /// <param name="item">The option port group item to set for.</param>
        public void Remove(OptionPortGroupItem item)
        {
            Remove(element: item);
            Items.Remove(item);
            GraphViewer.Remove(item.PortCell.Port);

            item.PortCell.Port.Disconnect(GraphViewer);
        }


        /// <summary>
        /// Add the given option port group item to the group.
        /// </summary>
        /// <param name="item">The option port group item to set for.</param>
        public void Add(OptionPortGroupItem item)
        {
            Add(child: item);
            Items.Add(item);
            GraphViewer.Add(item.PortCell.Port);
        }


        /// <summary>
        /// Disconnect every option port group item's port.
        /// </summary>
        public void DisconnectAll()
        {
            BaseOptionPortCell.Port.Disconnect(GraphViewer);

            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].PortCell.Port.Disconnect(GraphViewer);
            }
        }


        /// <summary>
        /// Methods for adding menu items to the node's contextual menu, items are added at the end of the current item list.
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            if (BaseOptionPortCell.Port.connected)
            {
                evt.menu.AppendAction
                (
                    actionName: BaseOptionPortCell.DisconnectCellPortContextualMenuItemLabel(),
                    action: action => BaseOptionPortCell.Port.Disconnect(GraphViewer),
                    status: DropdownMenuAction.Status.Normal
                );
            }

            for (int i = 0; i < Items.Count; i++)
            {
                var port = Items[i].PortCell.Port;
                if (port.connected)
                {
                    evt.menu.AppendAction
                    (
                        actionName: Items[i].PortCell.DisconnectCellPortContextualMenuItemLabel(),
                        action: action => port.Disconnect(GraphViewer),
                        status: DropdownMenuAction.Status.Normal
                    );
                }
            }
        }
    }
}