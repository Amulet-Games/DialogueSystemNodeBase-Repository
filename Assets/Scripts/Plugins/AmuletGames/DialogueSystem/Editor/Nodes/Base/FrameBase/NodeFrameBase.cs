using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeView,
        TNodeObserver,
        TNodeSerializer,
        TNodeCallback,
        TNodeModel
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeView : NodeViewBase
        where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeView, TNodeModel>
        where TNodeObserver : NodeObserverFrameBase<TNode, TNodeView>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView, TNodeObserver>
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Reference of the node observer.
        /// </summary>
        public TNodeObserver Observer;


        /// <summary>
        /// Reference of the node serializer.
        /// </summary>
        public TNodeSerializer Serializer;


        /// <inheritdoc />
        public override INodeCallback Callback
        {
            get
            {
                return m_Callback;
            }
        }


        /// <summary>
        /// Reference of the node callback.
        /// </summary>
        public TNodeCallback m_Callback;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node frame base class.
        /// </summary>
        public NodeFrameBase()
        {
            // Setup details
            {
                NodeGUID = Guid.NewGuid().ToString();
            }

            // Setup node border
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

                // Place the top container inside the node border.
                NodeBorder.Insert(index: 1, element: topContainer);
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

            // Override containers default style
            {
                // Title
                titleContainer.pickingMode = PickingMode.Position;
                titleContainer.name = "";
                titleContainer.AddToClassList(StyleConfig.Node_Title_Container);

                topContainer.name = "";
                topContainer.AddToClassList(StyleConfig.Node_Top_Container);

                // Input
                inputContainer.name = "";
                inputContainer.AddToClassList(StyleConfig.Node_Input_Container);

                // Output
                outputContainer.name = "";
                outputContainer.AddToClassList(StyleConfig.Node_Output_Container);

                // Main
                mainContainer.pickingMode = PickingMode.Position;
            }

            // Setup class list
            {
                ClearClassList();
                AddToClassList(StyleConfig.Node);
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodeCommonStyle);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel) => Serializer.Save(dsModel);


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