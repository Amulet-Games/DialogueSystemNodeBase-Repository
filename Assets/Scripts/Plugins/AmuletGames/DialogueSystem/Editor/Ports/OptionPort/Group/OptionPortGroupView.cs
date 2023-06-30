using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupView
    {
        /// <summary>
        /// Cache of the option port cells that are from the group.
        /// </summary>
        public List<OptionPortGroupCell> Cells;


        /// <summary>
        /// The port direction type.
        /// </summary>
        Direction direction;


        /// <summary>
        /// Returns true if any of the option port cell's port is connecting.
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
        /// Add a new option port cell to the group.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="model">The option port group cell model to load from if provided.</param>
        public void AddCell
        (
            NodeBase node,
            OptionPortGroupCellModel model = null
        )
        {
            OptionPortGroupCell cell;

            CreateCell();

            RegisterCellCallback();

            AddCellToNode();

            LoadCellModel();

            void CreateCell()
            {
                cell = OptionPortGroupCellPresenter.CreateElement
                (
                    connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                    direction: direction
                );

                Cells.Add(cell);
            }

            void RegisterCellCallback()
            {
                new OptionPortGroupCellCallback(
                    cell,
                    node,
                    group: this).RegisterEvents();
            }

            void AddCellToNode()
            {
                node.Add(cell: cell);
            }

            void LoadCellModel()
            {
                if (model != null)
                {
                    cell.Port.Load(model.OptionPortModel);
                }
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the group values to the option port group model.
        /// </summary>
        /// <param name="model">The option port group model to set for.</param>
        public void Save(OptionPortGroupModel model)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                var cellModel = new OptionPortGroupCellModel();

                Cells[i].Port.Save(cellModel.OptionPortModel);

                model.cellModels.Add(cellModel);
            }
        }


        /// <summary>
        /// Load the group values from the option port group model.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="model">The option port group model to set for.</param>
        public void Load
        (
            NodeBase node,
            OptionPortGroupModel model
        )
        {
            for (int i = 0; i < model.cellModels.Count; i++)
            {
                AddCell(node, model.cellModels[i]);
            }
        }


        // ----------------------------- Disconnect -----------------------------
        /// <summary>
        /// Disconnect every option port group cell's port.
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