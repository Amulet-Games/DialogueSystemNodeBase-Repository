using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node's frame base class.
    /// </summary>
    /// <typeparam name="TNodePresenter">Node presenter type</typeparam>
    /// <typeparam name="TNodeSerializer">Node serializer type</typeparam>
    /// <typeparam name="TNodeCallback">Node callback type</typeparam>
    public class DSNodeFrameBase<TNodePresenter, TNodeSerializer, TNodeCallback> 
        : DSNodeBase
        where TNodePresenter : DSNodePresenterBase
        where TNodeSerializer : DSNodeSerializerBase
        where TNodeCallback : DSNodeCallbackBase
    {
        /// <summary>
        /// Holds the methods for creating all the visual elements that are required for the node.
        /// <br>And methods that are require to have access to Model class.</br>
        /// </summary>
        public TNodePresenter Presenter;


        /// <summary>
        /// Responsible for serializing the node's data which are located in Model class.
        /// </summary>
        public TNodeSerializer Serializer;


        /// <summary>
        /// Holds the callback methods for the connecting node,
        /// <br>so that other static event classes can invoked them when the time comes.</br>
        /// </summary>
        public TNodeCallback Callback;

        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor for node's frame base class.
        /// </summary>
        /// <param name="name">The title name for this node.</param>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSNodeFrameBase(string name, Vector2 position, DSGraphView graphView)
        {
            SetupBaseFields();

            SetNodePosition();

            AddBaseStyleSheet();

            void SetupBaseFields()
            {
                // Setup node title
                title = name;

                // Setup node GUID.
                NodeGuid = Guid.NewGuid().ToString();

                // Setup default size.
                DefaultNodeSize = new Vector2(200, 250);

                // Setup refs.
                GraphView = graphView;
            }

            void SetNodePosition()
            {
                // Move the node to the specificed location on the graph.
                SetPosition(new Rect(position, DefaultNodeSize));
            }

            void AddBaseStyleSheet()
            {
                // Setup the base node's USS styles.
                styleSheets.Add(DSStylesConfig.dsGlobalStyle);
                styleSheets.Add(DSStylesConfig._nodesShareStyle);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Method that works like a callback when a node is deleted from graph.
        /// <para></para>
        /// <br>Since each derived class may implemented different behaviors, this method is mainly used for calling</br>
        /// <br>the derived classes's NodeRemovedAction instead.</br>
        /// </summary>
        public override void NodeRemovedAction() => Callback.NodeRemovedAction();


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            // Add items that will execute an action in the drop-down menu. The items is added at the end of the current item list.
            evt.menu.AppendAction("Disconnect Input Port", actionEvent => DisconnectInputPorts(), Presenter.IsInputPortConnected() ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);
            evt.menu.AppendAction("Disconnect Output Port", actionEvent => DisconnectOutputPorts(), Presenter.IsOutputPortConnected() ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);

            base.BuildContextualMenu(evt);
        }
    }
}