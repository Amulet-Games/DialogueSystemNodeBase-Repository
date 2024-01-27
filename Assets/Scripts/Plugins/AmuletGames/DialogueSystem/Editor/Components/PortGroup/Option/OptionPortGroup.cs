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
                GraphViewer.Add(value);
            }
        }


        /// <summary>
        /// The base option port cell of the group.
        /// </summary>
        OptionPortCell m_baseOptionPortCell;


        /// <summary>
        /// The first option port group item index.
        /// </summary>
        public const int FIRST_ITEM_INDEX = 1;


        /// <summary>
        /// The option port group cell cache.
        /// </summary>
        public List<OptionPortGroupCell> GroupCells;


        /// <summary>
        /// The next port cell index.
        /// </summary>
        public int NextCellIndex => childCount + 1;


        /// <summary>
        /// The direction type.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// Returns true if any of the group cell's port is connecting.
        /// </summary>
        public bool Connected
        {
            get
            {
                if (BaseOptionPortCell.Port.connected)
                {
                    return true;
                }

                for (int i = 0; i < GroupCells.Count; i++)
                {
                    if (GroupCells[i].PortCell.Port.connected)
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
            GroupCells = new();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Remove the given option port group cell from the group.
        /// </summary>
        /// <param name="groupCell">The option port group cell to set for.</param>
        public void Remove(OptionPortGroupCell groupCell)
        {
            Remove(element: groupCell);
            GroupCells.Remove(groupCell);
            GraphViewer.Remove(groupCell.PortCell.Port);

            groupCell.PortCell.Port.Disconnect(GraphViewer);
        }


        /// <summary>
        /// Add the given option port group cell to the group.
        /// </summary>
        /// <param name="groupCell">The option port group cell to set for.</param>
        public void Add(OptionPortGroupCell groupCell)
        {
            Add(child: groupCell);
            GroupCells.Add(groupCell);
            GraphViewer.Add(groupCell.PortCell.Port);
        }


        /// <summary>
        /// Disconnect every option port group cell's port.
        /// </summary>
        public void DisconnectAll()
        {
            BaseOptionPortCell.Port.Disconnect(GraphViewer);

            for (int i = 0; i < GroupCells.Count; i++)
            {
                GroupCells[i].PortCell.Port.Disconnect(GraphViewer);
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

            for (int i = 0; i < GroupCells.Count; i++)
            {
                var port = GroupCells[i].PortCell.Port;
                if (port.connected)
                {
                    evt.menu.AppendAction
                    (
                        actionName: GroupCells[i].PortCell.DisconnectCellPortContextualMenuItemLabel(),
                        action: action => port.Disconnect(GraphViewer),
                        status: DropdownMenuAction.Status.Normal
                    );
                }
            }
        }
    }
}