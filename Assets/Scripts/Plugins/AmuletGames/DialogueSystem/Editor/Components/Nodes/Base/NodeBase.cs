using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view node element.
    /// </summary>
    public abstract class NodeBase : UnityEditor.Experimental.GraphView.Node
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        public LanguageHandler LanguageHandler;


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
        public void Add(Port port)
        {
            (port.direction == Direction.Input ? InputContainer : OutputContainer).Add(port);

            GraphViewer.Add(port);
        }


        /// <summary>
        /// Add the given port cell to the node.
        /// </summary>
        /// <param name="portCell">The port cell base to set for.</param>
        public void Add(OptionPortCell portCell)
        {
            (portCell.Port.direction == Direction.Input ? InputContainer : OutputContainer).Add(portCell);

            GraphViewer.Add(portCell.Port);
        }


        /// <summary>
        /// Remove the given port from the node.
        /// </summary>
        /// <param name="port">The port base to set for.</param>
        public void Remove(Port port)
        {
            (port.direction == Direction.Input ? InputContainer : OutputContainer).Remove(port);

            GraphViewer.Remove(port);
        }
    }
}