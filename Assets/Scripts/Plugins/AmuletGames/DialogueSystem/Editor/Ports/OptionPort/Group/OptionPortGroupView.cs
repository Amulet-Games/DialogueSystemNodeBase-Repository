using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupView
    {
        public class CellView
        {
            /// <summary>
            /// The option port.
            /// </summary>
            public OptionPort Port;


            /// <summary>
            /// Button to remove the cell view from the group. 
            /// </summary>
            public Button RemoveButton;
        }


        /// <summary>
        /// The cell views of the group.
        /// </summary>
        public List<CellView> Cells;


        /// <summary>
        /// The port direction type.
        /// </summary>
        Direction direction;


        /// <summary>
        /// Returns true if any of the cell view's port is connecting.
        /// </summary>
        public bool connected
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


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option port group view.
        /// </summary>
        /// <param name="direction">The direction type to set for.</param>
        public OptionPortGroupView(Direction direction)
        {
            this.direction = direction;
            Cells = new();
        }


        /// <summary>
        /// Add a new cell view to the group.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="data">The option port group cell data to load from if provided.</param>
        public void AddCell
        (
            NodeBase node,
            OptionPortGroupData.CellData data = null
        )
        {
            CellView cell;

            // Create new cell view.
            {
                cell = new();
                Cells.Add(cell);

                OptionPortGroupCellPresenter.CreateElement
                (
                    view: cell,
                    connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                    direction: direction
                );

                new OptionPortGroupCellCallback
                (
                    cell: cell,
                    group: this,
                    graphViewer: node.GraphViewer
                )
                .RegisterEvents();

                node.Add(port: cell.Port, isRefresh: true);
            }

            // Load port data.
            {
                if (data != null)
                {
                    cell.Port.Load(data.OptionPortData);
                }
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the group values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public void Save(OptionPortGroupData data)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                var cellData = new OptionPortGroupData.CellData();

                Cells[i].Port.Save(cellData.OptionPortData);

                data.m_CellData.Add(cellData);
            }
        }


        /// <summary>
        /// Load the group values from the given data.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="data">The data to load from.</param>
        public void Load(NodeBase node, OptionPortGroupData data)
        {
            for (int i = 0; i < data.m_CellData.Count; i++)
            {
                AddCell(node, data.m_CellData[i]);
            }
        }


        // ----------------------------- Disconnect -----------------------------
        /// <summary>
        /// Disconnect every cell view's port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void Disconnect(GraphViewer graphViewer)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                Cells[i].Port.Disconnect(graphViewer);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
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