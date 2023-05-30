using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeModel,
        TNodePresenter,
        TNodeSerializer,
        TNodeCallback,
        TNodeData
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeModel : NodeModelFrameBase<TNode>
        where TNodePresenter : NodePresenterFrameBase<TNode, TNodeModel>
        where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeModel, TNodeData>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeModel>
        where TNodeData : NodeDataBase
    {
        /// <summary>
        /// Reference of the node model.
        /// </summary>
        protected TNodeModel Model;


        /// <summary>
        /// Reference of the node presenter.
        /// </summary>
        public TNodePresenter Presenter;


        /// <summary>
        /// Reference of the node callback.
        /// </summary>
        protected TNodeCallback Callback;


        /// <summary>
        /// Reference of the node serializer.
        /// </summary>
        public TNodeSerializer Serializer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node frame base class.
        /// </summary>
        /// <param name="nodeTitle">The node title to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public NodeFrameBase()
        {
            // Setup details
            {
                NodeGUID = Guid.NewGuid().ToString();
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodesShareStyle);
            }

            // Override border default style
            {
                // Get the node border from node's children.
                NodeBorder = ElementAt(0);

                // Brings the it to the front of any children element's under this nodes.
                NodeBorder.BringToFront();

                // Override default properties.
                NodeBorder.style.overflow = Overflow.Visible;
                NodeBorder.focusable = true;

                // Remove the default USS names and add to custom class.
                NodeBorder.name = "";
                NodeBorder.AddToClassList(StyleConfig.Node_Border);
            }

            // Override containers default style
            {
                // Title
                titleContainer.pickingMode = PickingMode.Position;

                // Top
                NodeBorder.Insert(index: 1, element: topContainer);

                // Input
                inputContainer.name = "";
                inputContainer.AddToClassList(StyleConfig.Node_Input_Container);

                // Output
                outputContainer.name = "";
                outputContainer.AddToClassList(StyleConfig.Node_Output_Container);

                // Main
                mainContainer.pickingMode = PickingMode.Position;
            }

            // Remove unused elements
            {
                // Remove #selection-border from the node.
                Remove(ElementAt(0));

                // Remove #title-label from the title container.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove #title-button-container from the title container.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove the #divider visual element from the top container.
                topContainer.Remove(topContainer.ElementAt(1));

                // Remove the #contents visual element from the node's border
                NodeBorder.Remove(NodeBorder.ElementAt(2));
            }

            // Add custom elements
            {
                // Add content container to main container.
                ContentContainer = new();
                ContentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                mainContainer.Add(ContentContainer);
            }
        }


        // ----------------------------- Action -----------------------------
        /// <inheritdoc />
        public override void CreatedAction()
        {
            Callback.RegisterEvents();
        }


        /// <inheritdoc />
        public override void PreManualRemoveAction()
        {
            Model.RemovePortsAll();
            Model.DisconnectPortsAll();

            Callback.UnregisterEvents();
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData) => Serializer.Save(dsData);


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
    }
}