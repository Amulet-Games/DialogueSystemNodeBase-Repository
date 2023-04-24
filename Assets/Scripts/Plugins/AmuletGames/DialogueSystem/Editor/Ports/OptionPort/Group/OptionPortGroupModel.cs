using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupModel
    {
        public class CellModel
        {
            /// <summary>
            /// The option port of the cell model.
            /// </summary>
            public OptionPort Port;


            /// <summary>
            /// Button to remove the cell model from the gorup. 
            /// </summary>
            public Button RemoveButton;
        }


        /// <summary>
        /// The cell models of the group model.
        /// </summary>
        public List<CellModel> Cells;


        /// <summary>
        /// The input or output direction type of the group model.
        /// </summary>
        Direction direction;


        /// <summary>
        /// Returns true if there's any cell model's port is connecting.
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
        /// Constructor of the option port group model.
        /// </summary>
        /// <param name="direction">The direction type to set for.</param>
        public OptionPortGroupModel(Direction direction)
        {
            this.direction = direction;
            Cells = new();
        }


        /// <summary>
        /// Add a new cell model to the group model.
        /// </summary>
        /// <param name="node">The node base module to set for.</param>
        /// <param name="data">The option port group cell data to load from if provided.</param>
        public void AddCell
        (
            NodeBase node,
            OptionPortGroupData.CellData data = null
        )
        {
            CellModel cell;

            // Create new cell model.
            {
                cell = new();
                Cells.Add(cell);

                OptionPortGroupCellPresenter.CreateElements
                (
                    model: cell,
                    connectorWindow: node.GraphViewer.NodeCreationConnectorWindow,
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
        /// <param name="node">The node base module to set for.</param>
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
        /// Disconnect every cell model's port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
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
        /// <param name="graphViewer">The graph viewer module to set for.</param>
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