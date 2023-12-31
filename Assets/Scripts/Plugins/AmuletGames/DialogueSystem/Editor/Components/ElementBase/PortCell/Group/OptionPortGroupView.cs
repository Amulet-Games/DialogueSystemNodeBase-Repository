using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupView
    {
        /// <summary>
        /// The option port cells cache.
        /// </summary>
        public List<OptionPortGroupCell> Cells;


        /// <summary>
        /// The port direction type.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// Returns true if any of the option port cell's port is connecting.
        /// </summary>
        public bool Connected
        {
            get
            {
                for (int i = 0; i < Cells.Count; i++)
                {
                    if (Cells[i].Port.connected)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        /// <summary>
        /// Constructor of the option port group view.
        /// </summary>
        /// <param name="direction">The direction type to set for.</param>
        public OptionPortGroupView(Direction direction)
        {
            Direction = direction;
            Cells = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the group view values.
        /// </summary>
        /// <param name="data">The option port group data to set for.</param>
        public void Save(OptionPortGroupData data)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                var cellData = new OptionPortGroupCellData
                {
                    OptionPortData = PortManager.Instance.Save(Cells[i].Port)
                };

                data.GroupCellsData.Add(cellData);
            }
        }


        /// <summary>
        /// Load the group view values.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="data">The option port group data to set for.</param>
        public void Load
        (
            NodeBase node,
            OptionPortGroupData data
        )
        {
            for (int i = 0; i < data.GroupCellsData.Count; i++)
            {
                var cell = new OptionPortGroupCellSeeder().Generate(
                    node,
                    groupView: this,
                    data: data.GroupCellsData[i]
                );

                Add(cell, node);
            }
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Remove the given option port group cell from the group.
        /// </summary>
        /// <param name="cell">The option port group cell to set for.</param>
        /// <param name="node">The node base element to set for.</param>
        public void Remove(OptionPortGroupCell cell, NodeBase node)
        {
            Cells.Remove(cell);
            node.Remove(cell);
        }


        /// <summary>
        /// Add the given option port group cell to the group.
        /// </summary>
        /// <param name="cell">The option port group cell to set for.</param>
        /// <param name="node">The node base element to set for.</param>
        public void Add(OptionPortGroupCell cell, NodeBase node)
        {
            Cells.Add(cell);
            node.Add(cell);
        }


        /// <summary>
        /// Disconnect every option port group cell's port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void DisconnectAll(GraphViewer graphViewer)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                Cells[i].Port.Disconnect(graphViewer);
            }
        }


        /// <summary>
        /// Methods for adding menu items to the node's contextual menu, items are added at the end of the current item list.
        /// <para>This method is used inside the node frame base class, "BuildContextualManu" method.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="evt">The event holding the menu to populate.</param>
        public void AddContextualMenuItems
        (
            GraphViewer graphViewer,
            ContextualMenuPopulateEvent evt
        )
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].Port.connected)
                {
                    evt.menu.AppendAction
                    (
                        actionName: Cells[i].Port.GetDisconnectPortContextualMenuItemLabel(),
                        action: action => Cells[i].Port.Disconnect(graphViewer),
                        status: DropdownMenuAction.Status.Normal
                    );
                }
            }
        }
    }
}