using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view node element.
    /// </summary>
    public abstract class NodeBase : Node
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the node border visual element.
        /// </summary>
        public VisualElement NodeBorder;


        /// <summary>
        /// Reference of the node port container visual element.
        /// </summary>
        public VisualElement PortContainer;


        /// <summary>
        /// Reference of the node input container visual element.
        /// </summary>
        public VisualElement InputContainer;


        /// <summary>
        /// Reference of the node output container visual element.
        /// </summary>
        public VisualElement OutputContainer;


        /// <summary>
        /// Reference of the node callback.
        /// </summary>
        public INodeCallback Callback;


        /// <summary>
        /// Node element Guid.
        /// </summary>
        public Guid Guid;


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            AddContextualMenuItems(evt);
            evt.menu.AppendSeparator();
        }


        /// <summary>
        /// Methods for adding menu items to the node contextual menu, items are added at the end of the current item list.
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        protected abstract void AddContextualMenuItems(ContextualMenuPopulateEvent evt);


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Add the given port to the node.
        /// </summary>
        /// <param name="port">The port base to set for.</param>
        public void Add(PortBase port)
        {
            if (port.direction == Direction.Input)
            {
                InputContainer.Add(port);
            }
            else
            {
                OutputContainer.Add(port);
            }

            GraphViewer.Add(port);
        }


        /// <summary>
        /// Add the given option port group cell to the node.
        /// </summary>
        /// <param name="cell">The option port group cell to set for.</param>
        public void Add(OptionPortGroupCell cell)
        {
            if (cell.Port.direction == Direction.Input)
            {
                InputContainer.Add(cell);
            }
            else
            {
                OutputContainer.Add(cell);
            }

            GraphViewer.Add(cell.Port);
        }


        /// <summary>
        /// Remove the given port from the node.
        /// </summary>
        /// <param name="port">The port base to set for.</param>
        public void Remove(PortBase port)
        {
            if (port.direction == Direction.Input)
            {
                InputContainer.Remove(port);
            }
            else
            {
                OutputContainer.Remove(port);
            }

            GraphViewer.Remove(port);
        }


        /// <summary>
        /// Remove the given option port group cell from the node.
        /// </summary>
        /// <param name="cell">The option port group cell to set for.</param>
        public void Remove(OptionPortGroupCell cell)
        {
            if (cell.Port.direction == Direction.Input)
            {
                InputContainer.Remove(cell);
            }
            else
            {
                OutputContainer.Remove(cell);
            }

            GraphViewer.Remove(cell.Port);
        }
    }
}